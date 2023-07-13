using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsNaceDivision : clsMain
    { 
        public int id { get; set; }
        public int naceSectionId { get; set; }
        public string divisionNo { get; set; }
        public string divisionTitle { get; set; }
    }
}
