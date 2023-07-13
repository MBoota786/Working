using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsEmployeeRange : clsMain
    {
        public int id { get; set; }

        public int standardSetupId { get; set; }
        public int auditTypeId { get; set; }
        public int employeeStartRange { get; set; }
        public int employeeEndRange { get; set; }

        public int auditDays { get; set; }
    }
}
