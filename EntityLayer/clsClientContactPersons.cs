using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsClientContactPersons 
    {
        public int  id { get; set; }
        public int clientId { get; set; }
        public int clientSiteId { get; set; }
        public int contactPersonGroupId { get; set; }
        public string salutationName { get; set; }
        public string cntPrsnFirstName { get; set; }
        public string cntPrsnMiddleName { get; set; }
        public string cntPrsnLastName { get; set; }
        public string cntPrsnEmail { get; set; }
        public string cntPrsnPhone { get; set; }
        public string cntPrsnCellNo { get; set; }
        public bool cmcForAuditReport { get; set; }
        public bool cmcForInvoice { get; set; }
        public bool cmcForCAP { get; set; }
        public bool cmcForClientPortalAccess { get; set; }
        public bool isAccessAllowed { get; set; }
        public string userId { get; set; }
        public string userPassword { get; set; }
        public string cntPrsnCellNoIsoCode { get; set; }
        public string cntPrsnPhoneIsoCode { get; set; }
        public int siteBillingInfoId { get; set; }
        public string cntPrsnPhoneExt { get; set; }
        public string cntPrsnAltEmail { get; set; }
        public string clientDesignationName { get; set; }
        public bool active { get; set; }
        public int createdBy { get; set; }
        public DateTime? createdOn { get; set; }
        public int modifiedBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string dbName { get; set; }
        public string cntPrsnGroupName { get; set; }
        public string OtherCntPrsnGroup { get; set; }
    }
}
