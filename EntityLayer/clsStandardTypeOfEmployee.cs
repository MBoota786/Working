using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardTypeOfEmployee : clsMain
    { 
        public int id { get; set; }
        public string empTypeName {set;get;}
        public int parentEmpTypeId {set;get;}
    }
}
