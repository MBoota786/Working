using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsNaceSection : clsMain
    { 
        public int id { get; set; }
        public string naceSection  { get; set; }
        public string naceTitle  { get; set; }
        public int accrIndustrialCodeTypeId { get; set; }
        public int officeId { get; set; }
    }
}
