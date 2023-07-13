using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOffice : clsMain
    {
        public int id { get; set; }
        public int officeTypeId { get; set; }
        public string officeName { get; set; }
        public int legalStatusId { get; set; }
        public string taxNo { get; set; }
        public string businessLicenseNumber { get; set; }
        public int businessTypeId { get; set; }
        public string otherBusinessType { get; set; }
        public int reportingOfficeId { get; set; }
        public int companyTypeId { get; set; }
        public int officeActiveStsId { get; set; }
        public int officeActivateBy { get; set; }
        public DateTime activeDate { get; set; }
        public int baseCurrencyId { get; set; }
        public string legalStatusName { get; set; }
        public string businessTypeName { get; set; }
        public string reportingOfficeName { get; set; }
        public string companyTypeName { get; set; }
        public string currencyName { get; set; }
        public string officeFolderPath { get; set; }
        //New Addition 03082022
        public string officeCode { get; set; }
        public bool isEmailSent { get; set; }
        public bool isExclusive { get; set; }
        public int categoryRelationId { get; set; }
        public string categoryRelation { get; set; }
        public string officeWebsite { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }
        public int cityId { get; set; }
        public string officeAddressLine1 { get; set; }
        public string officeAddressLine2 { get; set; }
        public string officeAddressLine3 { get; set; }
        public string officePostalCode { get; set; }
        public string officePoBox { get; set; }
        public string officeCountryAreaCode { get; set; }
        public string officeCellNumber { get; set; }
        public string extention { get; set; }
        public string officePhoneIsoCode { get; set; }
        public string officePhoneNumber { get; set; }
        public string officeTypeName { get; set; }
        public string countryName { get; set; }
        public string cityName { get; set; }
        public string perStatus { get; set; }
        public string stateProvinceName { get; set; }
    }
}
