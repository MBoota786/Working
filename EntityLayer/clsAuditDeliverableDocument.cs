using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditDeliverableDocument : clsMain
    {
        public int id { get; set; }
        public int accreditationStandardId { get; set; }
        public int auditTypeId { get; set; }
        public string deliverableDocName { get; set; }
        public bool isDocUploadRequired { get; set; }
        public string deliverableTemplatePath { get; set; }
        public bool isCertificate { get; set; }
    }
}
