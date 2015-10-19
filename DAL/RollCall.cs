using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RollCall
    {
        public int RollCallID { get; set; }
        public string TimeOfRollCall { get; set; }
        public int ModuleID { get; set; }
        public string Status { get; set; }//enabled, disabled
        public string AutoDisable { get; set; }
    }
}
