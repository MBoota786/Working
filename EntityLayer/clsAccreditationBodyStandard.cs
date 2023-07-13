using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsAccreditationBodyStandard : clsMain
    {
        public int  id { get; set; }
        public int accreditationId { get; set; }
        public int auditStandardsId { get; set; }
        public string standardName { get; set; }
        public int accreditationIndstrCodeId { get; set; }
        public DateTime accreditationDurationFrom { get; set; }
        public DateTime accreditationDurationTo { get; set; }
    }
}
