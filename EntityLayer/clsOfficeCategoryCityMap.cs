using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class clsOfficeCategoryCityMap: clsMain
    {
        public int id { get; set; }
        public int officeCategoryRelationId { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
    }
}
