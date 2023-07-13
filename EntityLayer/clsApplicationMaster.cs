using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsApplicationMaster : clsMain
    { 
        public int id { get; set; }
        public string appCode { set;get;}
        public int clientId {set;get;}
        public bool isEmailSent { set;get;}
        public int reportWrapId { set;get;}
        public string certificationScope { set;get;}
        public bool isCombineQuotation { set;get;}
        public int officeId { set;get;}
        public string serviceAcquired { set;get;}
        public DateTime? nextAuditDue { set;get;}
        public int appCertificationStatusId { set;get;}
        public bool isForwardFromOtherOffice { set;get;}
        public int applicationFromOfficeId { set;get;}
        public bool isBuyerRequest { set;get;}
        public int buyerId { set;get;}
        public bool isSponsored { set;get;}
        public int contactPersonSponsoredId { set;get;}
        public string primarySecondaryProcess { get; set; }
        public string clientCompanyName { get; set; }
        public string siteName { get; set; }
        public string perShow { get; set; }
        public bool isSiteEngagedWithConsultant { get; set; }
        public int rowNumber { get; set; }
    }
}
