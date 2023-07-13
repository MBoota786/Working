using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsNonConformaties : clsMain
    {
        public int id { get; set; }

        public int accreditationStandardId { get; set; }
        public int nonConformitiesTypeId { get; set; }
        public bool nonConformatiesClosureRequired { get; set; }
        public string nonConformatiesClosureDuration { get; set; }
        public string nonConformatiesFollowUpAudit { get; set; }
    }
}
