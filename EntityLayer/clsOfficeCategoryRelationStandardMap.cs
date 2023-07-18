using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOfficeCategoryRelationStandardMap : clsMain
    {
        public int id { get; set; }
        public int officeCategoryRelationId { get; set; }
        public int accreditationStandardId { get; set; }
        public object standardName { get; set; }
    }
}
