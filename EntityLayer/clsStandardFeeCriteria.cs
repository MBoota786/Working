using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardFeeCriteria : clsMain
    { 
        public int id { get; set; }
        public string criteriaName { get; set; }
        public bool isForPercentage { get; set; }
    }
}
