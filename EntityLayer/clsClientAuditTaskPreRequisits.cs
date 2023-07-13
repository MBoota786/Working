using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAuditTaskPreRequisits : clsMain
    {
        public int id { get; set; }
        public string clientAuditTaskPreRequisitsCode { get; set; }
        public int clientAuditAssignmentTaskId { get; set; }
        public int auditPreRequisitesMasterId { get; set; }
        public string downloadPath { get; set; }
        public string uploadPath { get; set; }
        public bool isDownload { get; set; }
        public bool isUpload { get; set; }
    }
}
