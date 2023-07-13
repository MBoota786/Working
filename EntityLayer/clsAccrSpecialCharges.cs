using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccrSpecialCharges : clsMain
    { 
        public int id { get; set; }
        public int accrId { get; set; }
        public int accreditationStandardId { get; set; }
        public int typeOfInvoiceChargeId { get; set; }
        public string specialChargesName { get; set; }
        public int modeOfPaymentId { get; set; }
        public decimal specialChargesAmount { get; set; }
        public string modeOfPaymentName { get; set; }
    }
}
