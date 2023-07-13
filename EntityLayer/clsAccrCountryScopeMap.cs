using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccrCountryScopeMap : clsMain
    { 
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int countryId { get; set; }
        public string countryName { get; set; }
    }
}
