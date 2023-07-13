using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsCountry : clsMain
    {
        public int id { get; set; }
        public string countryName { get; set; }
        public string countryIso2 { get; set; }
        public string countryIso3 { get; set; }
        public string currency { get; set; }
        public string currencyName { get; set; }
        public string currencySymbol { get; set; }
        public string region { get; set; }
        public string subRegion { get; set; }
        public string countryLongitude { get; set; }
        public string countryLatitude { get; set; }
    }
}
