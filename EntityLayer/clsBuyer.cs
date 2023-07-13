using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsBuyer : clsMain
    {
        public int id { get; set; }
        public string code { get; set; }
        public int buyerOfficeTypeId { get; set; }
        public string buyerCompanyName { get; set; }
        public string buyerAddressLine1 { get; set; }
        public string buyerAddressLine2 { get; set; }
        public string buyerAddressLine3 { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }
        public int cityId { get; set; }
        public string buyerPostalCode { get; set; }
        public string buyerPhone { get; set; }
        public string phoneExt { get; set; }
        public string buyerCell { get; set; }
        public string buyerEmail { get; set; }
        public string buyerWebsite { get; set; }
        public string buyerVatNo { get; set; }
        public int businessTypeId { get; set; }
        public int officeId { get; set; }
        public string businessTypeName { get; set; }
        public string countryName { get; set; }
        public string stateProvinceName { get; set; }
        public string cityName { get; set; }
        public string buyerOfficeTypeName { get; set; }
        public override string ToString()
        {
            return $"id: {id}, code: {code}, buyerOfficeTypeId: {buyerOfficeTypeId}, buyerCompanyName: {buyerCompanyName}, buyerAddressLine1: {buyerAddressLine1}, buyerAddressLine2: {buyerAddressLine2}, buyerAddressLine3: {buyerAddressLine3}, countryId: {countryId}" +
                $", stateProvinceId: {stateProvinceId}, cityId: {cityId}, buyerPostalCode: {buyerPostalCode}, buyerPhone: {buyerPhone}, phoneExt: {phoneExt}, buyerCell: {buyerCell}, buyerEmail: {buyerEmail}, buyerWebsite: {buyerWebsite}, buyerVatNo: {buyerVatNo}, businessTypeId: {businessTypeId}";
        }
    }
}
