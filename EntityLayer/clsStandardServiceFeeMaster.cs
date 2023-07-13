using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardServiceFeeMaster : clsMain
    { 
        public int id { get; set; }
        public string serviceFeeName { get; set; }
        public int officeId { get; set; }
        public int accreditationStandardId { get; set; }
        public int auditTypeId { get; set; }
        public bool isActive { get; set; }
        public bool isClientRecievable { get; set; }
        public bool isParentOfficePayable { get; set; }
        public int payableOfficeId { get; set; }
        public int receivableOfficeId { get; set; }
        public string standardName { get; set; }
        public string auditTypeName { get; set; }
        public string feeName { get; set; }
        public string serviceName { get; set; }
        public string criteriaName { get; set; }
        public int clientSiteId { get; set; }
        public decimal feeValue { get; set; }
        public int auditTimePeriod { get; set; }
        public decimal auditFee { get; set; }
        public int tariffTypeId { get; set; }
        public int serviceFeeTypeId { get; set; }
        public DateTime? applicableFromDate { get; set; }
        public List<clsStandardServiceFeeDetail> feeDetail { get; set; }
        public List<clsStandardServiceFeeDetail> otherFeeDetail { get; set; }
        public List<clsStandardServiceFeeBankMap> bankMap { get; set; }
        public string currencySymbol { get; set; }
        public decimal actualFeeValue { get; set; }
        public decimal actualAuditFee { get; set; }
        public int standardServiceFeeId { get; set; }
        public int standardServiceFeeDtlId { get; set; }
        public string tariffTypeName { get; set; }
    }
}
