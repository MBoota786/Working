using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientMaster : clsMain
    { 
        public int id { get; set; }
        public string clientCompanyName {set;get;}
        public int clientTypeId {set;get;}
        public int countryId {set;get;}
        public int stateProvinceId {set;get;}
        public int cityId  {set;get;}
        public string clientAddressLine1 {set;get;}
        public string clientAddressLine2 {set;get;}
        public string clientAddressLine3 {set;get;}
        public string clientEmail {set;get;}
        public string clientPhone {set;get;}
        public string clientWebsite { set; get; }
        public int businessTypeId { set; get; }
        public string otherBusinessType { set; get; }
        public string clientVatNo { set; get; }
        public int clientActivateBy { set; get; }
        public DateTime? activeDate { set; get; }
        public string serviceAcquired { set; get; }
        public int clientStatusId { set; get; }
        public string clientFolderName { set; get; }
        public int officeId { set; get; }
        public string clientPostalCode { set; get; }
        public string clientCode { set; get; }
        public string clientPhoneIsoCode { set; get; }
        public string clientPhoneExt { set; get; }
        public string clientTypeName { get; set; }
        public string businessTypeName { get; set; }
        public string siteName { get; set; }
        public string stateProvinceName { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }
    }
}
