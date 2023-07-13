using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
 public   class clsCity : clsMain
    {
        public int id { get; set; }
        public int countryId  { get; set; }
        public int stateProvinceId { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }
        public string stateProvinceName { get; set; }
        public string cityLatitude { get; set; }
        public string cityLongitude { get; set; }
    }
}
