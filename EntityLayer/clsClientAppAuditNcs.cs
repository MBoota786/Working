using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAppAuditNcs : clsMain
    { 
        public int id { get; set; }
        public int clientApplicationAuditId { get; set; }
        public string ncCategory { get; set; }
    }
}
