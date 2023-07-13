using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAppAuditAssignmentDocumentDtl : clsMain
    {
        public int id { get; set; }
        public int clientAppAuditAssignmentDocumentMasterId { get; set; }
        public bool isExpiry { get; set; }
        public Nullable<DateTime> expiryDate { get; set; }
        public string documentSrNo { get; set; }
        public string documentPath { get; set; }
        public Nullable<DateTime> documentDate { get; set; }
    }
}
