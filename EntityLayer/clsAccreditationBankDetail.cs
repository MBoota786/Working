using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccreditationBankDetail : clsMain
    {
        public int id { get; set; }
        public int accreditationId { get; set; }
        public string accrBankName { get; set; }
        public string accrAccountNumber { get; set; }
        public string accrAccountTitle { get; set; }
        public int contactTypeid { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }
        public int cityId { get; set; }
        public string accrBankAddress { get; set; }
        public string accrSwiftCode { get; set; }
        public string accrIban { get; set; }
        public string accrLocalWireTransferDetail { get; set; }
        public string accrInternationalWireTransferDetail { get; set; }
        public int currencyId { get; set; }
    }
}
