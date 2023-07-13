using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsInvoiceLedger : clsMain
    { 
        public int id { get; set; }
        public int invoiceId {set;get;}
        public int officeId {set;get;}
        public int clientId {set;get;}
        public int buyerId {set;get;}
        public int chargesId  {set;get;}
        public decimal chargesAmount {set;get;}
        public decimal afterDueDateAmount {set;get;}
        public decimal paidAmount {set;get;}
        public decimal balanceAmount {set;get;}
        public decimal reInvoiceNo {set;get;}
        public string chargesDetail { set; get; }
        public string paymentDetail { set; get; }
        public string paymentRemarks { set; get; }
        public DateTime? paymentDate { set; get; }
    }
}
