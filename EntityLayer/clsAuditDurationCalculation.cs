using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditDurationCalculation : clsMain
    {
        public int id { get; set; }
        public int standardSetupId { get; set; }
        public int auditTypeId { get; set; }
        public string auditDurationParameters { get; set; }
    }
}
