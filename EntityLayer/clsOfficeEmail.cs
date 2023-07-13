using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOfficeEmail : clsMain
    {
        public int id { get; set; }
        public int officeID { get; set; }
        public int emailTypeId { get; set; }
        public string emailAddress { get; set; }
        public string officeName { get; set; }
    }
}
