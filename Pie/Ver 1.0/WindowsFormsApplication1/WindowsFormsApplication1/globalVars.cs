using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class globalVars
    {
        private static string robotCommand_ = string.Empty;
        private static string robotName_ = string.Empty;
        public static string robotCommand
        {
            get { return robotCommand_; }
            set { robotCommand_ = value; }
        }
        public static string robotName
        {
            get { return robotName_; }
            set { robotName_ = value; }
        }

    }
}
