using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsSubscriptionTypeMaster : clsMain
    {
        public int id { get; set; }
        public int timePeriodUnitId { get; set; }
        public int SubscriptionDuration { get; set; }
    }
}
