using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsDormitoriesEmployee : clsMain
    {
        public int id { get; set; }

        public int standardSetupId { get; set; }
        public int auditTypeId { get; set; }
        public int dormitoriesEmployeeStartRange { get; set; }
        public int dormitoriesEmployeeEndRange { get; set; }
        public int dormitoriesAuditDays { get; set; }
    }
}
