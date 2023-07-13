using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsPackageMaster : clsMain
    { 
        public int id { get; set; }
        public int noOfStandard { get; set; }
        public int noOfUser { get; set; }
        public int noOfOffice { get; set; }
        public DateTime? validityDate { get; set; }
        public DateTime? startDate { get; set; }
        public string packageName { get; set; }
        public List<clsPackageStandard> packageStandard { get; set; }
    }
}
