using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsTaxTerm : clsMain
    { 
        public int id { get; set; }
        public string taxTermName  { get; set; }
        public bool isAdd { get; set; }
        public bool isMinus { get; set; }

    }
}
