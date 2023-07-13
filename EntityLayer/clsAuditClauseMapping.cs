using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditClauseMapping : clsMain
    {
        public int id { get; set; }
        public int auditClauseId { get; set; }
        public int standardSetupId { get; set; }
    }
}
