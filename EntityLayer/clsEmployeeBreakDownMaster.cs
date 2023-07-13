using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsEmployeeBreakDownMaster:clsMain
    {
        public int id { get; set; }

        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public bool isShiftWiseBreakDown { get; set; }
        public int noOfShifts { get; set; }
       
    }
}
