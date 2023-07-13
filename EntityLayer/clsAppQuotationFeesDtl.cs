using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppQuotationFeesDtl : clsMain
    { 
        public int id { get; set; }
        public int appQuotationFeesId { get; set; }
        public int standardServiceFeeDetailId { get; set; }
        public decimal calculateFeeValue { get; set; }
        public decimal finalFeeValue  { get; set; }
        public decimal finalRate { get; set; }
    }
    public class clsAppQuotationFeesForPrint 
    {
        public int id { get; set; }
        public int appId { get; set; }
        public int clientSiteId { get; set; }
        public int standardServiceFeeDetailId { get; set; }
        public string feeName { get; set; }
        public decimal calculateFeeValue { get; set; }
        public decimal finalFeeValue { get; set; }
        public string currencyShortName { get; set; }
        public string symbol { get; set; }
        public decimal finalRate { get; set; }
        public decimal feeValue { get; set; }
        public int auditTimePeriod { get; set; }


    }
}
