using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppSiteShifts : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int clientSiteId {set;get;}
        public string siteShiftName {set;get;}
        public string shiftFrom {set;get;}
        public string shiftTo {set;get;}
        public string shiftDescription { set;get;}
        public int totalShiftEmployee { set;get;}
        public List<clsAppSiteShiftsDayMap> DayMap { set;get;}
        
    }
}
