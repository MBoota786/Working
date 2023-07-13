using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsLeadCompanyCreditCardDetail : clsMain
    {
        public int id { get; set; }
        public int leadCompanyId { get; set; }
        public string nameOnCard { get; set; }
        public string creditCardNumber { get; set; }
        public string expMonth { get; set; }
        public string expYear { get; set; }
        public string cvv { get; set; }
    }
}
