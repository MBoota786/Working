using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeTaxMaster : clsMain
    { 
        public int id { get; set; }
        public string officeTaxName { get; set; }
        public int officeId { get; set; }
        public int serviceId { get; set; }
        public bool isParentOfficePayable { get; set; }
        public bool isClientReceivable { get; set; }
        public string serviceName { get; set; }
        public List<clsOfficeTaxDetail> officeTaxDetail { get; set; }
        public string officeName { get; set; }
        public string taxName { get; set; }
    }
}
