using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WindowsFormsApplication1;

namespace testhttpserve
{
    class ProgramHttp
    {
        static void Main(string[] args)
        {
            Thread hServThread;
            HttpServer hServ = new HttpServer(10001, TestCallback);   //calling testCallback function when a message is recieved from SL
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
            //Calling thge pie project and setting values for the command
            globalVars.robotName=parms["command"];
            globalVars.robotCommand = string.Empty;
            Program.Main(); 
            //  Console.WriteLine("Got request " + parms["command"]);
            if (globalVars.robotCommand.Equals(""))
            {
                return "No command chosen";//message sent when user confirms without chosing any opetions
            }
            else
            {
                return globalVars.robotCommand; //built command is sent
            }
           
        }
    }
}
