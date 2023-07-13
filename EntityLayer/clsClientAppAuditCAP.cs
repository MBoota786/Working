using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientAppAuditCAP : clsMain
    { 
        public int id { get; set; }
        public int clientAppAuditNcsId { get; set; }
        public string capCategory { get; set; }
    }
}
