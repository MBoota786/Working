using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientSiteSeason : clsMain
    { 
        public int id { get; set; }
        public int clientSiteId { set;get;}
        public int seasonTypeId { set;get;}
        public int fromSeasonMonthId { set;get;}
        public int toSeasonMonthId { set;get;}
        public string fromMonthName { get; set; }
        public string toMonthName { get; set; }
    }
}
