using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsBankAdditionalDetails : clsMain
    {
        public int  id { get; set; }
        public int officeBankId { get; set; }
        public string fieldTitle { get; set; }
        public string fieldInformation { get; set; }
        public string bankName { get; set; }
    }
}
