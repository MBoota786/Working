using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsManDaysFormula : clsMain
    { 
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int employyesFrom { get; set; }
        public int employeesTo { get; set; }
        public decimal auditDays { get; set; }
        public string standardName { get; set; }
        public string auditTypeName { get; set; }
    }
}
