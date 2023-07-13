using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppSiteShiftsDayMap : clsMain
    { 
        public int id { get; set; }
        public int appSiteShiftsId { get; set; }
        public int weekDayId { get; set; }
        public string dayName { get; set; }
    }
}
