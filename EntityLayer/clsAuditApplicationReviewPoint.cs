using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAuditApplicationReviewPoint : clsMain
    { 
        public int id { get; set; }
        public int accreditationStandardId { get; set; }
        public int auditTypeId { get; set; }
        public string reviewPoint { get; set; }
    }
}
