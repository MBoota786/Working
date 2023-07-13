using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccreditationAddresses : clsMain
    { 
        public int id { get; set; }
        public int accreditationId {set;get;}
        public int adressTypeId {set;get;}
        public int countryID {set;get;}
        public int stateID {set;get;}
        public int cityID  {set;get;}
        public string accrAddress {set;get;}
        public string accrPostalCode {set;get;}
        public string accrPoBoxNo { set; get; }
        //talha
    }
}
