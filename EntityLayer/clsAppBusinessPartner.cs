using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppBusinessPartner : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public string appBusinessPartnerName {set;get;}
        public bool isBrand {set;get;}
        public bool isBuyer {set;get;}
        public bool isCustomer {set;get;}
    }
}
