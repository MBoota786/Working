using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsApplicationOfficeSites : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int clientSiteId {set;get;}
        public string shiftWiseStatus {set;get;}
        public bool isAllianceInspected {set;get;}
        public int totalAuditDaysCalculated { set;get;}
        public int totalAuditDaysFinal { set;get;}
        public string siteCertificationScope { get; set; }
        public bool isSiteEngagedWithConsultant { get; set; }
    }
}
