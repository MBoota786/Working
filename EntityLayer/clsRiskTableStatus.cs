using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsRiskTableStatus :clsMain
    {
        public int id { get; set; }

        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public string riskName { get; set; }
        public string riskLevel { get; set; }
    }
}
