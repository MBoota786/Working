using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStateProvince : clsMain
    {
        public int id { get; set; }
        public int countryId { get; set; }
        public string stateProvinceName { get; set; }
        public string countryName { get; set; }
        public string stateProvinceCode { get; set; }
        public string stateProvinceLatitude { get; set; }
        public string stateProvinceLongitude { get; set; }
    }
}
