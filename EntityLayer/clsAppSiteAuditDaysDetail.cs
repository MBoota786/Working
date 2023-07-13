using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppSiteAuditDaysDetail : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int clientSiteId {set;get;}
        public int accredationStandardId {set;get;}
        public int totalNoOfEmp {set;get;}
        public int minAuditDays {set;get;}
        public int calculatedAuditDays {set;get;}
        public int finalAuditDays {set;get;}
    }
}
