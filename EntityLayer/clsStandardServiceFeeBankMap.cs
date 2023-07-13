using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardServiceFeeBankMap : clsMain
    { 
        public int id { get; set; }
        public int standardServiceFeeId { get; set; }
        public int officeBankDetailId { get; set; }
        public string bankName { get; set; }
    }
}
