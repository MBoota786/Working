using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAuditAssignmentTask : clsMain
    {
        public int id { get; set; }
        public int clientAuditAssignmentId { get; set; }
        public string taskDescription { get; set; }
        public string taskCategory { get; set; }
        public string taskResponce { get; set; }
        public string taskEvaluateBy { get; set; }
        public string taskPerformance { get; set; }
        public string taskRemarks { get; set; }
        public string taskCompletion { get; set; }
    }
}
