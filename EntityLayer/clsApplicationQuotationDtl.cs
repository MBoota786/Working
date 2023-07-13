using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsApplicationQuotationDtl : clsMain
    { 
        public int id { get; set; }
        public int applicationQuotationId  { get; set; }
        public int clientSiteId  { get; set; }
        public List<clsAppQuotationFees> listQuotationFees  { get; set; }
        public List<clsAppQuotationOtherCharges> listQuotationOtherCharges  { get; set; }
    }
}
