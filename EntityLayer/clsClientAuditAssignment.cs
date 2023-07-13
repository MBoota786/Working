using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAuditAssignment : clsMain
    {
        public int id { get; set; }
        public int clientApplicationAuditId { get; set; }
        public int standardProcessStageId { get; set; }
        public string assignmentSummary { get; set; }
        public int assignById { get; set; }
        public int assignByRoleId { get; set; }
        public Nullable<DateTime> assignProposedDateFrom { get; set; }
        public Nullable<DateTime> assignProposedDateTo { get; set; }
        public int assignToId { get; set; }
        public int assignToRoleId { get; set; }
        public int acceptStatusId { get; set; }
        public Nullable<DateTime> acceptedDateFrom { get; set; }
        public Nullable<DateTime> acceptedDateTo { get; set; }
        public Nullable<DateTime> assignmentFinalDateFrom { get; set; }
        public Nullable<DateTime> assignmentFinalDateTo { get; set; }
        public string assignByInstruction { get; set; }
        public string assignToReply { get; set; }
        public Nullable<DateTime> assignmentActualDateFrom { get; set; }
        public Nullable<DateTime> assignmentActualDateTo { get; set; }
        public int clientAuditAssignmentStatusId { get; set; }
        public int clientOfficeIdForVisit { get; set; }
    }
}
