using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientApplicationAudit : clsMain
    {
        public int id { get; set; }
        public int appId { get; set; }
        public int clientId { get; set; }
        public int clientSiteId { get; set; }
        public string leadAuditor { get; set; }
        public int reviewBy { get; set; }
        public Nullable<DateTime> startDate { get; set; }
        public Nullable<DateTime> endDate { get; set; }
        public string assignmentFolder { get; set; }
        public bool isActive { get; set; }
        public bool isPasaSend { get; set; }
        public bool isDocSend { get; set; }
        public bool isAuditAccepted { get; set; }
        public string clientAppTimeLine { get; set; }
        public int auditStageId { get; set; }

    }
}
