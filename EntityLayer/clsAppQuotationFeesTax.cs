using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppQuotationFeesTax : clsMain
    { 
        public int id { get; set; }
        public int appQuotationFeesId { get; set; }
        public int officeTaxDtlId { get; set; }
        public decimal feesTaxRate { get; set; }
        public decimal feesTaxValue { get; set; }
    }
}
