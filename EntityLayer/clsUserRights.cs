using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsUserRights : clsMain
    { 
        public int id { get; set; }
        public int moduleId {set;get;}
        public int userLoginId {set;get;}
        public bool rightEnter {set;get;}
        public bool rightVerify {set;get;}
        public bool rightCheck {set;get;}
        public bool rightApprove {set;get;}
        public bool rightPrint {set;get;}
        public bool rightDelete {set;get;}
        public bool rightEdit {set;get;}
        public bool rightExtend {set;get;}
        
    }
}
