using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsLogs : clsMain
    { 
        public int id { get; set; }
        public string logDetail { get; set; }
        public string formName { get; set; }
        public string actionName { get; set; } 
        public int recordId { get; set; } 
    }
}
