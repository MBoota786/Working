using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsBankAccountPurposeMap : clsMain
    { 
        public int id { get; set; }
        public int bankAccountPurposeId { get; set; }
        public int officeBankDetailsId { get; set; }
        public string bankAccountPurpose { get; set; }
    }
}
