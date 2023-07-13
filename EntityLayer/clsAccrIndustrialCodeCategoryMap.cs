using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccrIndustrialCodeCategoryMap : clsMain
    { 
        public int id { get; set; }
        public int accrIndustrialCodeId { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public string subCategoryCode { get; set; }
        public string subTitleCode { get; set; }
        public int accrIndustrialCodeTypeId { get; set; }
    }
}
