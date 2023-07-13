using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAssignmentAuditorInstruction : clsMain
    {
        public int id { get; set; }
        public int clientAuditAssignmentId { get; set; }
        public string instructionDetail { get; set; }
        public int instructionForAuditorId { get; set; }
    }
}
