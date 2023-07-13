using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAuditTaskCheckList : clsMain
    {
        public int id { get; set; }
        public string clientAuditCheckListCode { get; set; }
        public int clientAuditAssignmentTaskId { get; set; }
        public int standardReqCheckListId { get; set; }
        public string downloadPath { get; set; }
        public string uploadPath { get; set; }
        public bool isDownloaded { get; set; }
        public bool isUploaded { get; set; }
    }
}
