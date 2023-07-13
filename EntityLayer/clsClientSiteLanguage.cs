using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public   class clsClientSiteLanguage : clsMain
    {
        public int id { get; set; }
        public int clientSiteId { get; set; }
        public int siteLanguageId { get; set; }
        public decimal percentSpoken { get; set; }
        public int employeeTypeId { get; set; }
        public string siteLanguage { get; set; }
    }
}
