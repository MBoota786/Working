using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditDuration : clsMain
    {
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int timePeriodUnitId { get; set; }
        public int minDurationValue { get; set; }
        public int maxDurationValue { get; set; }
    }
}
