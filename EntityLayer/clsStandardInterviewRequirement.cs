using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardInterviewRequirement : clsMain
    {
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int interviewTypeId { get; set; }
        public int employeesFrom { get; set; }
        public int employeesTo { get; set; }
        public int requiredInterview { get; set; }
        public decimal estimatedTime { get; set; }
        public int reviewRecord { get; set; }
        public int groupOfEmployee { get; set; }
        public int noOfGroup { get; set; }
        public string standardName { get; set; }
    }
}
