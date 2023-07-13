using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientSiteWorkingDay : clsMain
    { 
        public int id { get; set; }
        public int clientSiteId { get; set; }
        public int weekDayFromId { get; set; }
        public int weekDayToId { get; set; }
        public string WeekDayFromName { get; set; }
        public string WeekDayToName { get; set; }
        public List<clsClientSiteHoliday> clientSiteHoliday { get; set; }
    }
}
