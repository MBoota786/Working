using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAppAuditAssignmentDocumentMaster : clsMain
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public int appId { get; set; }
        public int clientAuditAssignmentId { get; set; }
        public int documentTypeId { get; set; }
        public string documentTitle { get; set; }
    }
}
