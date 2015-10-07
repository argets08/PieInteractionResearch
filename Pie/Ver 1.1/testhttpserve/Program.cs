using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WindowsFormsApplication1;

namespace testhttpserve
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread hServThread;
            HttpServer hServ = new HttpServer(10001, TestCallback);
            bool done = false;

            hServThread = new Thread(new ThreadStart(hServ.listen));
            hServThread.Start();
            while (!done)
            {
                char chr = Console.ReadKey().KeyChar;
                if (chr.Equals('X')) done = true;
            }
            hServThread.Abort();
            hServThread.Join();
        }

        public static string TestCallback(string url, Dictionary<string, string> parms)
        {
            globalVars.robotName=parms["command"];
            //  Console.WriteLine("Got request " + parms["command"]);
            
            return globalVars.robotCommand;
        }
    }
}
