using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsNaceGroup : clsMain
    { 
        public int id { get; set; }
        public int naceDivisionId { get; set; }
        public string naceGroup { get; set; }
        public string groupTitle { get; set; }
        public string groupDescription { get; set; }
    }
}
