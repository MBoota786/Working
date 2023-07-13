using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsServiceFeeType : clsMain
    { 
        public int id { get; set; }
        public int serviceTypeId { get; set; }
        public string serviceFeeTypeName  { get; set; }
    }
}
