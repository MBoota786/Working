using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsCompanyStandards :clsMain
    {
        public int id { get; set; }
        public int companyId { get; set; }
        public int accreditationStandardId { get; set; }
        public string standardName { get; set; }
    }
}
