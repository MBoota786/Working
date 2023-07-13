using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOfficeAddresses : clsMain
    {
        public int  id { get; set; }
        public int officeID { get; set; }
        public int adressTypeId { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }

        public int cityId { get; set; }
        public string officeAddressLine1 { get; set; }
        public string officeAddressLine2 { get; set; }
        public string officeAddressLine3 { get; set; }
        public string postalCode { get; set; }
        public string pOBox { get; set; }
        public string officeName { get; set; }
    }
}
