using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardSetup : clsMain
    { 
        public int id { get; set; }
        public int accreditationStandardsId { get; set; }
        public int auditCycleId { get; set; }
        public int industryCategoryId { get; set; }
        public bool preRequisitesDocumentStatus { get; set; }
        public bool auditRequiredDocumentStatus { get; set; }
        public string interviewSampling { get; set; }
        public bool auditReportReviewCheckListStatus { get; set; }
        public bool openingMeetingCheckListStatus { get; set; }
        public bool closingMeetingCheckListStatus { get; set; }
        public bool RiskTableStatus { get; set; }
    }
}
