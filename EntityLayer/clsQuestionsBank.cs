using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsQuestionBank : clsMain
    {
        public int id { get; set; }
        public int accreditationBodyStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int questionTypeId { get; set; }
        public string auditquestion { get; set; }
        public int parentQuestionId { get; set; }
        public bool isEffectManDays { get; set; }
        public bool isEffectAuditPlanning { get; set; }
        public bool isEffectAuditReporting { get; set; }
        public bool isForInformationUsage { get; set; }
        public int questionGroupId { get; set; }
        public int officeId { get; set; }
        public int countryId { get; set; }
        public int stateProvinceId { get; set; }
        public bool isForOffice { get; set; }
        public bool isForStandard { get; set; }
        public string questionType { get; set; }
    }
}
