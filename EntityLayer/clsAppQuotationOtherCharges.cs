using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppQuotationOtherCharges : clsMain
    { 
        public int id { get; set; }
        public int applicationQuotationDtlId { get; set; }
        public int serviceFeeTypeId { get; set; }
        public decimal chargeValue { get; set; }
        public bool isTBD { get; set; }
        public int officeTaxDetailId { get; set; }
        public decimal taxRate { get; set; }
        public decimal taxValue { get; set; }
        public int currencyId { get; set; }
        public string serviceFeeTypeName { get; set; }
        public string currencyShortName { get; set; }
        public string symbol { get; set; }
        //_____ saqib  : 6/20/2023 byHuzafa _____
        public string expenseTypeTax { get; set; }
    }
}
