using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsSiteInfrastructureMaster : clsMain
    { 
        public int id { get; set; }
        public int clientSiteId { get; set; }
        public string siteFacilityPlotArea { get; set; }
        public int siteFacilityPlotAreaUnitId { get; set; }
        public string siteFacilityPlotAreaUnitName { get; set; }
        public string siteFacilityCoverArea { get; set; }
        public int siteFacilityCoverAreaUnitId { get; set; }
        public string siteFacilityCoverAreaUnitName { get; set; }
        public int siteNumberOfBuilding { get; set; }
    }
}
