using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsRoleRights : clsMain
    { 
        public int id { get; set; }
        public int roleId { get; set; }
        public int moduleId { get; set; }
        public bool permEnter { get; set; }
        public bool permVerify { get; set; }
        public bool permCheck { get; set; }
        public bool permApprove { get; set; }
        public bool permPrint { get; set; }
        public bool permDelete { get; set; }
        public bool permEdit { get; set; }
        public bool permExtend { get; set; }
        public string moduleName { get; set; }
        public string RightType { get; set; }
    }
}
