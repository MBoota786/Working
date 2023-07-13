using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOfficeBanksDetail : clsMain
    {
        public int id { get; set; }
        public int officeID { get; set; }
        public string bankName { get; set; }
        public string accountNumber { get; set; }
        public string accountTitle { get; set; }
        public int contactTypeid { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }
        public int cityId { get; set; }
        public string bankAddress { get; set; }
        public string swiftCode { get; set; }
        public string iban { get; set; }
        public string localWireTransferDetail { get; set; }
        public string internationalWireTransferDetail { get; set; }
        public int currencyId { get; set; }
        public string stateProvinceName { get; set; }
        public string cityName { get; set; }
        public string sortCode { get; set; }
        public string transitNo { get; set; }
        public List<clsBankAccountPurpose> bankPurposeList { get;set;}

    }
}
