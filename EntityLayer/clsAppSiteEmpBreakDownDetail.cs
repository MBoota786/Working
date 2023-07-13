using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppSiteEmpBreakDownDetail : clsMain
    { 
        public int id { get; set; }
        public int appId { get; set; }
        public int clientSiteId { get; set; }
        public bool isMigrant { get; set; }
        public bool isLocal { get; set; }
        public int permEmpMale { get; set; }
        public int tempEmpMale { get; set; }
        public int agencyEmpMale { get; set; }
        public int contractEmpMale { get; set; }
        public int homeWokerMale { get; set; }
        public int permEmpFemale { get; set; }
        public int tempEmpFemale { get; set; }
        public int agencyEmpFemale { get; set; }
        public int contractEmpFemale { get; set; }
        public int homeWorkerFemale { get; set; }
        public int totalEmp { get; set; }
    }
}
