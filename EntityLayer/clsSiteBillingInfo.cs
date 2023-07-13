using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsSiteBillingInfo : clsMain
    { 
        public int id { get; set; }
        public int appId { get; set; }
        public int clientSiteId { get; set; }
        public string billingCompanyName { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }
        public int cityId { get; set; }
        public string billingAddressLine1 { get; set; }
        public string billingAddressLine2 { get; set; }
        public string billingAddressLine3 { get; set; }
        public string billingEmail { get; set; }
        public string billingPhone { get; set; }
        public string billingPhoneIsoCode { get; set; }
        public string billingWebsite { get; set; }
        public string billingPostalCode { get; set; }
        public string billingVatNo { get; set; }
        public string billingPhoneExt { get; set; }
        public List<clsClientContactPersons> contactPersonList { get; set; }
        public string countryName { get; set; }
        public string stateProvinceName { get; set; }
        public string cityName { get; set; }

        public override string ToString()
        {
            return $"id: {id}, appId: {appId}, clientSiteId: {clientSiteId}, billingCompanyName: {billingCompanyName}, countryId: {countryId}, stateProvinceId: {stateProvinceId}" +
                $", cityId: {cityId}, billingAddressLine1: {billingAddressLine1}, billingAddressLine2: {billingAddressLine2}, billingAddressLine3: {billingAddressLine3}, billingEmail: {billingEmail}" +
                $", billingPhone: {billingPhone}, billingWebsite: {billingWebsite}, billingPostalCode: {billingPostalCode}, billingVatNo: {billingVatNo}, billingPhoneExt: {billingPhoneExt}";
        }
    }
}
