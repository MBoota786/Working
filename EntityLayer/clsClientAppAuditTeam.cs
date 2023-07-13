using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAppAuditTeam : clsMain
    {
        public int id { get; set; }
        public int clientApplicationAuditId { get; set; }
        public int teamMemberId { get; set; }
        public int teamMemberRoleId { get; set; }
        public bool auditWindowStart { get; set; }
        public bool auditWindowEnd { get; set; }
        public string windowStatus { get; set; }
    }
}
