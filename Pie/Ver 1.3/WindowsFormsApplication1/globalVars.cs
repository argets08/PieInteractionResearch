using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public static class globalVars //basically a  class of global variables, used of r setting the robots names and commnds
    {
        private static string robotCommand_ = string.Empty;
        private static string robotName_ = string.Empty;
  //      private static bool programDone_ = false;
       

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
/*        public static bool programDone
        {
            get { return programDone_; }
            set { programDone_ = value; }
        }
 */

    }
}
