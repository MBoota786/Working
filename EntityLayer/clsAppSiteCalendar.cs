using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppSiteCalendar : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int clientSiteId {set;get;}
        public DateTime? siteCalendarDate {set;get;}
        public bool isWorkingDay {set;get;}
    }
}
