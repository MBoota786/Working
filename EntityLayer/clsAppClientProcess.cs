using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppClientProcess : clsMain
    { 
        public int id { get; set; }
        public int appId { get; set; }
        public string appClientProcess {set;get;}
        public int clientSiteId { set;get;}
    }
}
