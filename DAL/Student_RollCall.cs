using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Student_RollCall
    {
        public int StudentID { get; set; }
        public int RollCallID { get; set; }
        public string Status { get; set; }//present, absent, excused
        public string TimeOfSignIn { get; set; }
    }
}
