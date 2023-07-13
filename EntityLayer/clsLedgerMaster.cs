using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsLedgerMaster : clsMain
    { 
        public int id { get; set; }
        public int trTypeId { set;get;}
        public int invoiceTypeId { set;get;}
        public string invoiceNo { set;get;}
        public int payableId { set;get;}
        public DateTime? invoiceDate { set;get;}
        public DateTime? dueDate { set;get;}
        public bool isClient { set;get;}
        public bool isParentOffice { set;get;}
        public bool isBuyer { set;get;}
        public bool isChildOffice { set;get;}
        public int invoiceStatusId { set;get;}
        public int nextInvoiceNumber { set;get;}
        public bool isFeeId { set;get;}
        public bool isTaxId { set;get;}
    }
}
