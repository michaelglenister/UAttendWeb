using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Business
    {
        public int BusinessID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public string EmailServer { get; set; }
        public int EmailPort { get; set; }
    }
}
