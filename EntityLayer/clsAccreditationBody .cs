using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccreditationBody : clsMain
    { 
        public int id { get; set; }
        public string accreditationName { get; set; }
        public int accreditationCategoryId { get; set; }
        public string accreditationOtherCategory { get; set; }
        public string accreditationVatNo { get; set; }
        public string accreditationCategory { get; set; }
        public string accreditationWebsite { get; set; }
        public string standardName { get; set; }
      //  public clsAccreditationAddresses accrAddress { get; set; }
      //  public clsAccreditationCompanyContactsInformation accrContactInformation { get; set; }
       // public clsAccreditationOfficeEmail accrOfficeEmail { get; set; }
        public string PerShow { get; set; }
        //talha
    }
}
