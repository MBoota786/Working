using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditExecutionProcessStep : clsMain
    {
        public int id { get; set; }

        public int standardSetupId { get; set; }
        public string processSetup { get; set; }
        public string auditExecutionProcessStepDuration { get; set; }
    }
}
