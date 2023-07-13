using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsSiteDormitories : clsMain
    { 
        public int id { get; set; }
        public int clientSiteId { get; set; }
        public bool isAccommodationFacilityToWorker { get; set; }
        public decimal perOfWorkerLiving { get; set; }
        public bool isWorkerOnSite { get; set; }
        public bool isWorkerOffSite { get; set; }
        public bool isWorkerOnOffBoth { get; set; }
        public bool isAccommodationFacilityToEmployees { get; set; }
        public decimal perOfManagementLiving { get; set; }
        public bool isManagementOnSite { get; set; }
        public bool isManagementOffSite { get; set; }
        public bool isManagementWorkerOnOffBoth { get; set; }
    }
}
