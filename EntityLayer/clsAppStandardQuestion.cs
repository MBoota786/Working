using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppStandardQuestion : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int questionId {set;get;}
        public int questionTypeId {set;get;}
        public string standardQuestion { set; get; }
    }
}
