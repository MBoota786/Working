using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccreditationCharges : clsMain
    { 
        public int id { get; set; }
        public int accreditationId {set;get;}
        public int accreditationStandardId {set;get;}
        public int typeOfInvoiceChargeId {set;get;}
        public int timePeriodUnitId { set;get;}
        public int noOfAudits {set;get;}
        public int currencyId {set;get;}
        public int disbursementFrequency { set;get;}
        public bool isPeriodic { set;get;}
        public bool isPerAudit { set;get;}
    }
}
