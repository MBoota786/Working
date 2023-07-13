using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsCompanySubscription : clsMain
    {
        public int id { get; set; }
        public int subscriptionPlanId { get; set; }
        public int companyId { get; set; }
        public DateTime? subscriptionStartDate { get; set; }
        public DateTime? subscriptionEndDate { get; set; }
        public int modeOfPaymentId { get; set; }
        public string transactionReference { get; set; }
        public int userLimit { get; set; }
        public int officeLimit { get; set; }
    }
}
