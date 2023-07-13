using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditRequiredDocDetail : clsMain
    {
        public int id { get; set; }
        public int auditRequiredDocId { get; set; }
        public int requiredDocVersionNo { get; set; }
        public string requiredDocSrNo { get; set; }
        public string requiredDocPath { get; set; }

    }
}
