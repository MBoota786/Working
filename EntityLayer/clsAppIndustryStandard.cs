using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppIndustryStandard : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int industryStandardId {set;get;}
        public string industryStandardName { get; set; }
    }
}
