using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppSiteEmpBreakDown : clsMain
    { 
        public int id { get; set; }
        public int appId { get; set; }
        public int clientSiteId { get; set; }
        public int managementEmp { get; set; }
        public int noOfWorkers { get; set; }
        public int workerMale { get; set; }
        public int workerFemale { get; set; }
        public int totalEmployee { get; set; }
        public int managementMale { get; set; }
        public int managementFemale { get; set; }
    }
}
