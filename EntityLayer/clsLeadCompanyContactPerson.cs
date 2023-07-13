using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsLeadCompanyContactPerson : clsMain
    {
        public int id { get; set; }
        public int leadCompanyId { get; set; }
        public string adminUserFirstName { get; set; }
        public string adminUserMiddleName { get; set; }
        public string adminUserLastName { get; set; }
        public string adminCountryCode { get; set; }
        public string adminAreaCode { get; set; }
        public string adminContactNumber { get; set; }
        public string adminExtension { get; set; }
        public string adminCellNumber { get; set; }
        public string adminCellCountryCode { get; set; }
        public string adminEmailAddress { get; set; }
        public bool isAdminEmailSent { get; set; }
        public string setupUserFirstName { get; set; }
        public string setupUserMiddleName { get; set; }
        public string setupUserLastName { get; set; }
        public string setupCountryCode { get; set; }
        public string setupAreaCode { get; set; }
        public string setupContactNumber { get; set; }
        public string setupExtension { get; set; }
        public string setupCellNumber { get; set; }
        public string setupCellCountryCode { get; set; }
        public string setupEmailAddress { get; set; }
        public bool isSetupEmailSent { get; set; }
    }
}
