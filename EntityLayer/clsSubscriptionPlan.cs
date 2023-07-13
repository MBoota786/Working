using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsSubscriptionPlan : clsMain
    {
        public int id { get; set; }
        public int packageId { get; set; }
        public int subscriptionTypeId { get; set; }
        public int currencyId { get; set; }
        public decimal totalAmount { get; set; }
        public int paymentTermId { get; set; }
        public decimal subscriptionAmount { get; set; }
        public string packageName { get; set; }
        public string timePeriodUnit { get; set; }
        public int subscriptionDuration { get; set; }
        public int noOfUser { get; set; }
        public int noOfStandard { get; set; }
        public int noOfOffice { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? validityDate { get; set; }
        public bool isFeatured { get; set; }
        public string featuredTitle { get; set; }
        public string paymentTerm { get; set; }
        public string currencyName { get; set; }
        public string currencySymbol { get; set; }
        public List<clsPackageStandard> packageStandard { get; set; }
    }
}
