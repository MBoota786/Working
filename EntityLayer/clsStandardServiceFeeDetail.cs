using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardServiceFeeDetail : clsMain
    { 
        public int id { get; set; }
        public int standardServiceFeeId { get; set; }
        public int serviceId { get; set; }
        public string feeName { get; set; }
        public bool isAmount { get; set; }
        public decimal feeValue { get; set; }
        public int currencyId { get; set; }
        public int standardFeeCriteriaId { get; set; }
        public bool isPercent { get; set; }
        public int standardServiceFeeDetailId { get; set; }
        public int auditTypeId { get; set; }
        public string auditTypeName { get; set; }
        public bool isOtherCharge { get; set; }
        public string criteriaName { get; set; }
        public string symbol { get; set; }
    }
}
