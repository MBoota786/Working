using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppClientProduct : clsMain
    { 
        public int id { get; set; }
        public int appId { get; set; }
        public int clientSiteId { get; set; }
        public string appClientProduct {set;get;}
    }
}
