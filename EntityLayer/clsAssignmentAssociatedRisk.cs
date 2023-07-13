using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAssignmentAssociatedRisk : clsMain
    {
        public int id { get; set; }
        public int clientAuditAssignmentId { get; set; }
        public string riskDetail { get; set; }
        public int instructionForAuditorId { get; set; }
        public string auditAssignmentTask { get; set; }
    }
}
