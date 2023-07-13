using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsLedgerDetail : clsMain
    { 
        public int id { get; set; }
        public int ledgerMasterId { set;get;}
        public int srNo { set;get;}
        public int payableId { set;get;}
        public int trTypeId { set;get;}
        public decimal debitAmount { set;get;}
        public decimal creditAmount { set;get;}
        public bool isClient { set;get;}
        public bool isParentOffice { set;get;}
        public bool isBuyer { set;get;}
        public bool isChildOffice { set;get;}
        public int feeId { set;get;}
        public bool IsFeeId { set; get; }
        public bool IsTaxId { set; get; }
        public decimal refLedgerMasterId { set;get;}
    }
}
