using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsTaxMaster : clsMain
    { 
        public int id { get; set; }
        public int moneyReceivingOriginId { get; set; }
        public int taxTypeId { get; set; }
        public string taxName { get; set; }
        public string taxPercentage { get; set; }
        public int serviceId { get; set; }
        public int stateProvinceId { get; set; }
        public int officeId { get; set; }
    }
}
