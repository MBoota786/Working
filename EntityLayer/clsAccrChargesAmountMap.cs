using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccrChargesAmountMap : clsMain
    { 
        public int id { get; set; }
        public int accreditationChargesId { get; set; }
        public int countryId { get; set; }
        public int amountValueTypeId { get; set; }
        public decimal accrCharges { get; set; }
        public DateTime? validityFrom { get; set; }
        public DateTime? validityTill { get; set; }
        public string amountType { get; set; }
        public string countryName { get; set; }
    }
}
