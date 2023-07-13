using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccreditationServiceFee : clsMain
    { 
        public int id { get; set; }
        public int serviceId { set;get;}
        public int accreditationStandardId { set;get;}
        public string feeName { set;get;}
        public decimal feeAmount { set;get;}
    }
}
