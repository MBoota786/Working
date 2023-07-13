using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppQuotationFees : clsMain
    { 
        public int id { get; set; }
        public int applicationQuotationDtlId { get; set; }
        public int standardServiceFeeId { get; set; }
        public decimal calculateFeeValueInUSD { get; set; }
        public decimal finalFeeValueInUSD { get; set; }
        public decimal taxValue { get; set; }
        public decimal totalAfterTax { get; set; }
        public List<clsAppQuotationFeesDtl> listFeesDtl { get; set; }
        public List<clsAppQuotationFeesTax> listTaxFees { get; set; }
    }
}
