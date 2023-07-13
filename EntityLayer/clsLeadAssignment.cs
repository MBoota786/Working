using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsLeadAssignment : clsMain
    {
        public int id { get; set; }
        public int leadCompanyId { get; set; }
        public int assignBy { get; set; }
        public int assignTo { get; set; }
        public string assignByRemarks { get; set; }
        public string assignToRemarks { get; set; }
        public int leadStatusId { get; set; }
        public System.DateTime? assignDate { get; set; }
    }
}
