using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsPaymentStatusMapping : clsMain
    { 
        public int id { get; set; }
        public int paymentStatusId { get; set; }
        public int paymentStatusTypeId { get; set; }
        public string paymentStatusType { get; set; }
        public string paymentStatus { get; set; }
    }
}
