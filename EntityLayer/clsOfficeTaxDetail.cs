using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsOfficeTaxDetail : clsMain
    { 
        public int id { get; set; }
        public int officeTaxId { get; set; }
        public string taxName { get; set; }
        public int taxTypeId { get; set; }
        public int taxCountryCategoryId { get; set; }
        public int countryId { get; set; }
        public int costTypeId { get; set; }
        public decimal taxRate { get; set; }
        public bool isTaxStateOther { get; set; }
        public int serviceFeeTypeId { get; set; }
        public int taxTermId { get; set; }
        public List<clsOfficeTaxStateMap> officeTaxStateMap { get; set; }
        public string taxTermName { get; set; }
        public string taxType { get; set; }
        public string serviceFeeTypeName { get; set; }
        public string countryName { get; set; }
    }
}
