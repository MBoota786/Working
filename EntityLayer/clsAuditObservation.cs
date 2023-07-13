using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditObservation : clsMain
    { 
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int auditObservationTypeId { get; set; }
        public bool clouserRequired { get; set; }
        public int clouserDuration { get; set; }
    }
}
