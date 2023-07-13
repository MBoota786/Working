using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsBankCharges : clsMain
    {
        public int  id { get; set; }
        public int officeID { get; set; }
        public string chargeName { get; set; }
        public string chargeShortCode { get; set; }
        public int currencyId { get; set; }
        public int calculationInput { get; set; }
        public int criteriaId { get; set; }
        public string currencyName { get; set; }
        public string officeName { get; set; }
    }
}
