using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditPreRequisitesDetail : clsMain
    {
        public int id { get; set; }
        public string auditPreRequisitesVersionNo { get; set; }
        public string auditPreRequisitesSrNo { get; set; }
        public string auditPreRequisitesPath { get; set; }
        public int auditPreRequisitesId { get; set; }
    }
}
