/**
 * Code based on the following...
 * Source URL: http://www.sampullara.com/http.cs
 * EXE URL:    http://www.sampullara.com/httpd.exe
 * (c) 2001 Sam Pullara  sam@sampullara.com
 * 
 * Modified extensively to work with Second Life HTTP - strictly
 * as a communications protocol that does not server web pages.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace testhttpserve
{
    class HttpProcessor
    {
        private const int NUMSIMUL = 20;

        private static int threads = 0;
        private Socket s;
        private NetworkStream ns;
        private StreamReader sr;
        private StreamWriter sw;
        private string method;
        private string url;
        private string body;
        private Dictionary<string, string> parameters;
        private string protocol;
        private Hashtable headers;
        private string request;
        private bool keepAlive = false;
        private int numRequests = 0;
        private bool verbose = HttpServer.verbose;
        private byte[] bytes = new byte[4096];
        private HttpServer.httpCallback doCallback;

        /**
		 * Each HTTP processor object handles one client.  If Keep-Alive is enabled then this
		 * object will be reused for subsequent requests until the client breaks keep-alive.
		 * This usually happens when it times out.  Because this could easily lead to a DoS
		 * attack, we keep track of the number of open processors and only allow 100 to be
		 * persistent active at any one time.  Additionally, we do not allow more than 500
		 * outstanding requests.
		 */
        public HttpProcessor(Socket s, HttpServer.httpCallback hcb)
        {
            this.s = s;
            headers = new Hashtable();
            doCallback = hcb;
        }

        /**
         * This is the main method of each thread of HTTP processing.  We pass this method
         * to the thread constructor when starting a new connection.
         */
        public void process()
        {
            try
            {
                // Increment the number of current connections
                Interlocked.Increment(ref threads);
                // Bundle up our sockets nice and tight in various streams
                ns = new NetworkStream(s, FileAccess.ReadWrite);
                // It looks like these streams buffer
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                // Parse the request, if that succeeds, read the headers, if that
                // succeeds, then write the given URL to the stream, if possible.
                while (parseRequest())
                {
                    if (readHeaders())
                    {
                        if (method == "POST")
                        {
                            bool tmp = readBody();
                            //Console.WriteLine(tmp.ToString() + ": " + url + " - " + body);
                            if (tmp)
                                ParseParams(body, ref parameters);
                            else
                            {
                                writeError(400, "_FAILEDSEND_" + url + "_");
                                return;
                            }
                        }
                        // This makes sure we don't have too many persistent connections and also
                        // checks to see if the client can maintain keep-alive, if so then we will
                        // keep this http processor around to process again.
                        if (threads <= NUMSIMUL && "Keep-Alive".Equals(headers["Connection"]))
                        {
                            keepAlive = true;
                        }

                        DoResponse();

                        // If keep alive is not active then we want to close down the streams
                        // and shutdown the socket
                        if (!keepAlive)
                        {
                            ns.Close();
                            s.Shutdown(SocketShutdown.Both);
                            break;
                        }
                    }
                }
            }
            finally
            {
                // Always decrement the number of connections
                Interlocked.Decrement(ref threads);
                doCallback = null;
            }
        }

        public bool parseRequest()
        {
            // The number of requests handled by this persistent connection
            numRequests++;
            // Here is where we ensure that we are not overloaded
            if (threads > NUMSIMUL)
            {
                writeError(502, "Server temporarily overloaded");
                return false;
            }
            // FIXME: This could conceivably used to DoS us if we never finish reading the
            // line and they never hang up.  We could set the socket options to limit
            // the amount of time before reading a request.
            try
            {
                request = null;
                request = sr.ReadLine();
            }
            catch (IOException)
            {
            }
            // If the request line is null, then the other end has hung up on us.  A well
            // behaved client will do this after 15-60 seconds of inactivity.
            if (request == null)
            {
                if (verbose)
                {
                    Console.WriteLine("Keep-alive broken after " + numRequests + " requests");
                }
                return false;
            }
            // HTTP request lines are of the form:
            // [METHOD] [Encoded URL] HTTP/1.?
            string[] tokens = request.Split(new char[] { ' ' });
            if (tokens.Length != 3)
            {
                writeError(400, "Bad request");
                return false;
            }
            // We currently only handle GET/POST requests
            method = tokens[0];
            if (!method.Equals("GET") && !method.Equals("POST"))
            {
                writeError(501, method + " not implemented");
                return false;
            }
            url = tokens[1];
            // Only accept valid urls
            if (!url.StartsWith("/"))
            {
                writeError(400, "Bad URL");
                return false;
            }
            // Lets just make sure we are using HTTP, thats about all I care about
            protocol = tokens[2];
            if (!protocol.StartsWith("HTTP/"))
            {
                writeError(400, "Bad protocol: " + protocol);
                return false;
            }

            // Decode all encoded parts of the URL using the built in URI processing class
            int ii = 0;
            int tmp;
            while ((ii = url.IndexOf("%", ++ii)) != -1)
            {
                tmp = ii;
                url = url.Substring(0, ii) + Uri.HexUnescape(url, ref tmp) + url.Substring(ii + 3);
            }

            parameters = null;
            if ((ii = url.IndexOf("?", 0)) != -1)
            {
                ParseParams(url.Substring(ii + 1), ref parameters);
                url = url.Substring(0, ii);
            }
            url = url.Substring(1);
            return true;
        }

        public bool readHeaders()
        {
            string line;
            string name = null;
            // The headers end with either a socket close (!) or an empty line
            while ((line = sr.ReadLine()) != null && line != "")
            {
                // If the value begins with a space or a hard tab then this
                // is an extension of the value of the previous header and
                // should be appended
                if (name != null && Char.IsWhiteSpace(line[0]))
                {
                    headers[name] += line;
                    continue;
                }
                // Headers consist of [NAME]: [VALUE] + possible extension lines
                int firstColon = line.IndexOf(":");
                if (firstColon != -1)
                {
                    name = line.Substring(0, firstColon);
                    String value = line.Substring(firstColon + 1).Trim();
                    if (verbose) Console.WriteLine(name + ": " + value);
                    headers[name] = value;
                }
                else
                {
                    writeError(400, "Bad header: " + line);
                    return false;
                }
            }
            return line != null;
        }

        public bool readBody()
        {
            var tmp = new StringBuilder(256);
            char chr = char.MinValue;
            // The body ends with a socket close
            while (sr.Peek() >= 0)
            {
                chr = (char)sr.Read();
                switch (chr)
                {
                    case '\r':
                        break;
                    case '\n':
                        chr = '&';
                        goto default;//fall through
                    default:
                        tmp.Append(chr);
                        break;
                }
            }
            body = tmp.ToString();
            return chr != char.MinValue;
        }

        public void DoResponse()
        {
            try
            {
                string msg = doCallback(url, parameters);

                bytes = StrToByteArray(msg);
                writeSuccess(bytes.Length);
                ns.Write(bytes, 0, bytes.Length);
                ns.Flush();
            }
            catch (System.IO.IOException)
            {
                writeFailure();
            }
        }

        /**
         * These write out the various HTTP responses that are possible with this
         * very simple web server.
         */

        public void writeSuccess(long length)
        {
            writeResult(200, "OK", length);
        }

        public void writeFailure()
        {
            writeError(404, "File not found");
        }

        public void writeForbidden()
        {
            writeError(403, "Forbidden");
        }

        public void writeError(int status, string message)
        {
            string output = "<h1>HTTP/1.0 " + status + " " + message + "</h1>";
            writeResult(status, message, (long)output.Length);
            sw.Write(output);
            sw.Flush();
        }

        public void writeResult(int status, string message, long length)
        {
            if (verbose) Console.WriteLine(request + " " + status + " " + numRequests);
            sw.Write("HTTP/1.0 " + status + " " + message + "\r\n");
            sw.Write("Content-Length: " + length + "\r\n");
            sw.Write("Content-Type: text/html; charset=utf-8\r\n");
            if (keepAlive)
            {
                sw.Write("Connection: Keep-Alive\r\n");
            }
            else
            {
                sw.Write("Connection: close\r\n");
            }
            sw.Write("\r\n");
            sw.Flush();
        }

        public static void ParseParams(string str, ref Dictionary<string, string> ret)
        {
            string key;
            string val;
            int ii = 0;
            string[] tokens = str.Split(new char[] { '&' });

            if (ret == null) ret = new Dictionary<string, string>();
            for (int xx = 0; xx < tokens.Length; xx++)
            {
                if ((ii = tokens[xx].IndexOf("=", 0)) != -1)
                {
                    key = tokens[xx].Substring(0, ii).Trim();
                    val = tokens[xx].Substring(ii + 1);
                }
                else
                {
                    key = tokens[xx].Trim();
                    val = string.Empty;
                }
                if (key.Length > 0) ret.Add(key, val);
            }
        }

        // C# to convert a string to a byte array.
        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
    }

    public class HttpServer
    {
        // ============================================================
        // Data
        internal static bool verbose = false; //For debugging true

        public delegate string httpCallback(string url, Dictionary<string, string> parms);

        private string SERVIP;
        private string EXTERNSERVIP;
        private int port;
        private httpCallback doCallBack = delegate { return string.Empty; };

        // ============================================================
        // Constructor
        public HttpServer(int port, httpCallback myCallback)
        {
            this.port = port;
            string hostname = Dns.GetHostName();
            foreach (IPAddress tmp in Dns.GetHostAddresses(hostname))
            {
                if (tmp.AddressFamily == AddressFamily.InterNetwork)
                {
                    SERVIP = tmp.ToString();
                    EXTERNSERVIP = SERVIP;
                    break;
                }
            }
            Console.WriteLine("Hostname: " + hostname + " - IP: " + SERVIP);
            if (myCallback != null) doCallBack = myCallback;
        }

        public string GetListenURL()
        {
            return "http://" + EXTERNSERVIP + ":" + port.ToString() + "/";
        }

        // ============================================================
        // Listener
        public void listen()
        {
            // Create a new server socket, set up all the endpoints, bind the socket and then listen
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse(SERVIP);
            IPEndPoint endpoint = new IPEndPoint(ipaddress, port);
            try
            {
                listener.Bind(endpoint);
                listener.Blocking = true;
                listener.Listen(-1);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: " + e.ErrorCode + " - " + e.Message);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Other exception: " + e.Message);
                return;
            }
            Console.WriteLine("Http server listening on port " + port);
            bool quit;
            do
            {
                quit = true;
                try
                {
                    // Because connection is blocking, only accept when one is present
                    // Poll every 10ms for new connection
                    if (listener.Poll(10000, SelectMode.SelectRead))
                    {
                        // Accept a new connection from the net, blocking till one comes in
                        Socket s = listener.Accept();
                        // Create a new processor for this request
                        HttpProcessor processor = new HttpProcessor(s, doCallBack);
                        // Dispatch that processor in its own thread
                        Thread thread = new Thread(new ThreadStart(processor.process));
                        thread.Start();
                    }
                    quit = false;
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: " + e.ErrorCode + " - " + e.Message);
                }
                catch (ThreadAbortException)
                {
                    //Server going down
                    System.Threading.Thread.ResetAbort(); //allow cleanup code below loop
                }
                catch (Exception e)
                {
                    Console.WriteLine("Other exception: " + e.Message);
                }
            } while (!quit);
            listener.Close();
            doCallBack = null;
            Console.WriteLine("Http server is shut down");
        }
    }
}