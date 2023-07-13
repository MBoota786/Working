using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeScopeStateMap : clsMain
    { 
        public int id { get; set; }
        public int officeScopeId { get; set; }
        public int stateProvinceId { get; set; }
        public string stateProvinceName { get; set; }
    }
}
