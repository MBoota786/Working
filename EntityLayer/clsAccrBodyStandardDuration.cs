using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAccrBodyStandardDuration : clsMain
    { 
        public int id { get; set; }
        public int accrBodyStandardId { get; set; }
        public DateTime? accrDurationFrom { get; set; }
        public DateTime? accrDurationTo { get; set; }  
    }
}
