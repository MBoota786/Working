using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
 public   class clsSiteSubType : clsMain
    {
        public int id { get; set; }
        public int siteTypeId { get; set; }
        public string subSiteTypeName { get; set; }
    }
}
