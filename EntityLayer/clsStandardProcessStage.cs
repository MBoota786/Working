using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardProcessStage : clsMain
    { 
        public int id { get; set; }
        public int standardProcessId { get; set; }
        public string processStageName { get; set; }
        public int kpiTimeInHour { get; set; }
    }
}
