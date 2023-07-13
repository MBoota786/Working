using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditPreRequisitesMaster : clsMain
    {
        public int id { get; set; }
        public int accreditationStandardId { get; set; }
        public string preRequisitesName { get; set; }
        public bool docUploadRequired { get; set; }
        public bool isAnswerRequired { get; set; }
        public int auditTypeId { get; set; }
    }
}
