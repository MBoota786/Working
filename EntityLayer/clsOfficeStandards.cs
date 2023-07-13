using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsOfficeStandards :clsMain
   {
        public int id { get; set; }
        public int officeId { get; set; }
        public int accreditationStandardId { get; set; }
        public string standardName { get; set; }
    }
}
