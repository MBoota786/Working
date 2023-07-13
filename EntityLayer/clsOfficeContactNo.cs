using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOfficeContactNo : clsMain
    {
        public int  id { get; set; }
        public int officeAddressId { get; set; }
        public int contactTypeid { get; set; }
        public string countryAreaCode { get; set; }
        public string contactNumber { get; set; }
        public string extention { get; set; }
        public string contactTypeName { get; set; }
        public string phoneIsoCode { get; set; }
        public string phoneNumber { get; set; }
    }
}
