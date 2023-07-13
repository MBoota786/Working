using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsSiteInfrastructure : clsMain
    { 
        public int id { get; set; }
        public int clientSiteId { get; set; }
        public string buildingName { get; set; }
        public int noOfBuildingId { get; set; }
        public int sizeOfFacility { get; set; }
        public string noOfBuilding { get; set; }
        public string buildingType { get; set; }
        public int numberOfFloors { get; set; }
    }
}
