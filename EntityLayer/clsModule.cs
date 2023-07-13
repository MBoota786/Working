using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsModule : clsMain
    { 
        public int id { get; set; }
        public string moduleName { get; set; }
        public bool isModule { get; set; }
        public bool isSubModule { get; set; }
        public bool isForm { get; set; }
        public string subForm { get; set; }
        public int parentModuleId { get; set; }
        public string moduleUrl { get; set; }
        public string modulePath { get; set; }
        public string RightType { get; set; }
        public bool isTab { get; set; }
    }
}
