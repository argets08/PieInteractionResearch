using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WindowsFormsApplication1;
using System.Windows.Forms;

namespace testhttpserve
{
   static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RobotPie());
            
            Thread hServThread;
            HttpServer hServ = new HttpServer(10001, TestCallback);
            globalVars.programDone = false;
            
            hServThread = new Thread(new ThreadStart(hServ.listen));
            hServThread.Start();
            while (globalVars.programDone==false)
            {
                //keep looping
            }
                hServThread.Abort();
                hServThread.Join();
            
        }
        
        public static string TestCallback(string url, Dictionary<string, string> parms)
        {
            globalVars.robotName=parms["command"];
            return globalVars.robotCommand;
        }
       
    }
}

