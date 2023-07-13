using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardProcess : clsMain
    { 
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public string processName { get; set; }
        public bool isExclusivePerDay { get; set; }
    }
}
