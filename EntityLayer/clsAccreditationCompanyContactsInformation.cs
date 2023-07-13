using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccreditationCompanyContactsInformation : clsMain
    { 
        public int id { get; set; }
        public int accreditationId{set;get;}
        public string countryCode  {set;get;}
        public string contactNumber{set;get;}
        public string extentionNo { set; get; }
        public string contactNumberIsoCode { set; get; }
    }
}
