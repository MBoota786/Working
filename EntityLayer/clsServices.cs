using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsServices : clsMain
    { 
        public int id { get; set; }
        public int costTypeId { get; set; }
        public int serviceTypeId { get; set; }
        public string serviceName { get; set; }
        public string serviceDetail { get; set; } 
    }
}
