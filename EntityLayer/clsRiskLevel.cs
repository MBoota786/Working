using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsRiskLevel : clsMain
    { 
        public int id { get; set; }
        public string riskLevelName { get; set; }
        public string priorityLevel { get; set; }
    }
}
