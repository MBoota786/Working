using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeScopeCityMap : clsMain
    { 
        public int id { get; set; }
        public int officeScopeId { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
    }
}
