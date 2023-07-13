using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsApplicationQuotation : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int clientId {set;get;}
        public string quotationNo {set;get;}
        public bool isQuotationApprovedLocalOffice { set;get;}
        public DateTime? quotationApprovalDate { set;get;}
        public int? quotationApprovalBy { set;get;}
        public bool quotationSentToEmail { set;get;}
        public int quotationSentToPersonId { set;get;}
        public int quotationStatusId { set;get;}
        public string uploadQuotationPath { set;get;}
        public int quotationPaymentStatusId { set;get;}
        public int quotationPaymentTermId { set;get;}
        public DateTime? quotationDate { set;get;}
        public DateTime? quotationValidityUpto { set;get;}
        public int quotationSentByUserId { set;get;}
        public int officeId { set;get;}
        public List<clsApplicationQuotationDtl> quotationDtl { set;get;}
        public override string ToString()
        {
            return $"id: {id}, appId: {appId}, clientId: {clientId}, quotationNo: {quotationNo}, isQuotationApprovedLocalOffice: {isQuotationApprovedLocalOffice}, quotationApprovalDate: {quotationApprovalDate}, quotationApprovalBy: {quotationApprovalBy}" +
                $", quotationSentToEmail: {quotationSentToEmail}, quotationSentToPersonId: {quotationSentToPersonId}, quotationStatusId: {quotationStatusId}, uploadQuotationPath: {uploadQuotationPath}, quotationPaymentStatusId: {quotationPaymentStatusId}" +
                $", quotationPaymentStatusId: {quotationPaymentStatusId}, officeId: {officeId}";
        }
    }
    public class clsApplicationQuotationList : clsMain
    {
        public int id { get; set; }
        public int appId { set; get; }
        public int clientSiteId { set; get; }
        public string appCode { set; get; }
        public int officeId { set; get; }
        public int clientId { set; get; }
        public string clientCompanyName { set; get; }
        public string siteName { set; get; }
        public string appCertificationStatus { set; get; }
        public string quotationStatusName { set; get; }
        public string officeName { get; set; }
        public string quotationNo { get; set; }
    }
    public class clsQuotationPrint
    {
        public clsApplicationQuotation quotation { set; get; }
        public clsClientMaster client { set; get; }
        public clsClientContactPersons clientContactPerson { set; get; }
        public string quoSubject { set; get; }
        public List<clsClientSites> clientSites { set; get; }
        public List<clsApplicationQuotationDtl> quotationDtl { set; get; }
        public List<clsStandardInterviewRequirement> listInterviewSampling { set; get; }
        public List<string> mandaysColumn { set; get; }
        public List<clsManDaysFormula> listAuditMandays { set; get; }
    }
}
