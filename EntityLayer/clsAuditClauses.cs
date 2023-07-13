using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditClauses : clsMain
    {
        public int id { get; set; }
        public string auditClauseSerialNumber { get; set; }
        public string auditClauses { get; set; }
        public int auditClauseParentId { get; set; }
        public int accreditationStandardId { get; set; }
        public int clauseTypeId { get; set; }
        public string clauseStatement { get; set; }
        public string clauseDescription { get; set; }
    }
}
