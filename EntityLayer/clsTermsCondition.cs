using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsTermsCondition : clsMain
    { 
        public int id { get; set; }
        public int accreditationStandardId { get; set; }
        public int officeId { get; set; }
        public int termsConditionCategoryId { get; set; }
        public string termsCondition { get; set; }
    }
}
