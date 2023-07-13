using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardAuditsTypes : clsMain
    { 
        public int id { get; set; }
        public int accreditationStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int auditAnnouncementTypeId { get; set; }
        public int timePeriodUnitId { get; set; }
        public int timePeriod { get; set; }
        public string auditTypeName { get; set; }
    }
}
