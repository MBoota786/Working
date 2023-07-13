using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsQuotationPaymentTerm : clsMain
    { 
        public int id { get; set; }
        public string paymentTerm { get; set; }
        public int paymentTermDays { get; set; }
    }
}
