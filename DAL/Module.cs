using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Module
    {
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
        public int LecturerID { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
