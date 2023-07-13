using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppSiteEmpDetail : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int clientSiteId {set;get;}
        public int accreditationStandardId { set;get;}
        public int clientSiteShiftId { set;get;}
        public int standardEmpTypeId {set;get;}
        public int noOfEmp {set;get;}
    }
}
