using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsApplicationEditReason : clsMain
    { 
        public int id { get; set; }
        public int applicationDetailId { get; set; }
        public string fieldName { get; set; }
        public DateTime editDate { get; set; }
        public string editReason { get; set; }
        public string oldValue { get; set; }
        public string newValue { get; set; }
    }
}
