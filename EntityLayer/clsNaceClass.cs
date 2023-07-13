using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsNaceClass : clsMain
    { 
        public int id { get; set; }
        public int naceGroupId { get; set; }
        public string naceClass { get; set; }
        public string classTitle { get; set; }
        public string classDescription { get; set; }
    }
}
