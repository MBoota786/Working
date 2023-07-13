using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppBusinessActivity : clsMain
    { 
        public List<clsAppClientProcess> primaryProcessList { get; set; }
        public List<clsAppClientSecondaryProcess> secondaryProcessList { get; set; }
        public List<clsAppClientProduct> productList { get; set; }
     //   public List<clsAppClientBuyer> buyerList { get; set; }
    }
}
