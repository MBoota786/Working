using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsInvoice : clsMain
    { 
        public int id { get; set; }
        public string code { set;get;}
        public int applicationQuotationId { set;get;}
        public int payToOfficeId { set;get;}
        public int siteBillingInfoId { set;get;}
        public DateTime? invDate { set;get;}
        public DateTime? invDueDate { set;get;}
        public int invoiceTypeId  {set;get;}
        public int invoiceStatusId  {set;get;}
        public int invCheckBy  {set;get;}
        public int invApprovedBy { set;get;}
        public int invSentBy { set;get;}
        public int officeId  {set;get;}
        public string invBankName { set;get;}
        public string invBankAccount { set;get;}
        public string invBankTitle { set;get;}
        public string invBankIban { set;get;}
        public string invBankSwiftCode { set;get;}
        public string invBankSoftCode { set;get;}
        public string invBankTransitNo { set;get;}
        public string invBankAddress { set;get;}
        public int appId { set;get;}
        public int clientId { set;get;}
        public string quotationNo { set;get;}
        public string payToOfficeName { set;get;}
        public string officeName { set;get;}
        public string invoiceTypeName { set;get;}
        public string invoiceStatusName { set;get;}
        public string userName { set;get;}
        public string clientCompanyName { set;get;}
    }
}
