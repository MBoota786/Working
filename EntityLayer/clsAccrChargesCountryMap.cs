using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccrChargesCountryMap : clsMain
    { 
        public int id { get; set; }
        public int countryId { get; set; }
        public int accrChargesAmountMapId { get; set; }
        public string countryName { get; set; }
    }
}
