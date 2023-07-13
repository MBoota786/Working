using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditRequiredDocMaster : clsMain
    {
        public int id { get; set; }
        public int accreditationStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int auditRequiredDocTypeId { get; set; }
        public string requiredDocName { get; set; }
        public bool docUploadRequired { get; set; }
        public bool isAnswerRequired { get; set; }
    }
}
