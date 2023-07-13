using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsLeadCompany : clsMain
    {
        public int id { get; set; }
        public int leadStatusId { get; set; }
        public int subscriptionPlanId { get; set; }
        public string leadUserName { get; set; }
        public string leadCompanyName { get; set; }
        public string leadEmailAddress { get; set; }
        public string leadUserPassword { get; set; }
        public string leadCompanyAddress { get; set; }
        public int countryId { get; set; }
        public int stateProviceId { get; set; }
        public int cityId { get; set; }
        public string leadCompanyWebsite { get; set; }
        public string leadCompanyPoBox { get; set; }
        public string leadCompanyPostalCode { get; set; }
        public string leadCompanyCountryCode { get; set; }
        public string leadCompanyAreaCode { get; set; }
        public string leadCompanyCellNo { get; set; }
        public string leadCompanyPhone { get; set; }
        public string leadCompanyExtension { get; set; }
        public string leadCompanyCellCountryCode { get; set; }
        public int companyTypeId { get; set; }
        public System.DateTime? leadDate { get; set; }
        public bool isEmailSent { get; set; }
        public int assignUser { get; set; }
        public int assignBy { get; set; }
        public System.DateTime? paymentDate { get; set; }
        public string paymentRefNo { get; set; }
    }
}
