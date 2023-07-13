using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppBusinessScope : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public bool isProduct {set;get;}
        public bool isService {set;get;}
        public string scopeDescription { set; get; }
        public string scopeRemarks { set; get; }
    }
}
