using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsBuyerContactPerson : clsMain
    {
        public int id { get; set; }
        public int buyerId { get; set; }
        public int contactPersonGroupId { get; set; }
        public string salutationName { get; set; }
        public string cntPrsnFirstName { get; set; }
        public string cntPrsnMiddleName { get; set; }
        public string cntPrsnLastName { get; set; }
        public string buyerDesignationName { get; set; }
        public string cntPrsnEmail { get; set; }
        public string cntPrsnPhone { get; set; }
        public string cntPrsnCellNo { get; set; }
        public bool cmcForAuditReport { get; set; }
        public bool cmcForInvoice { get; set; }
        public bool cmcForCAP { get; set; }
        public bool cmcForClientPortalAccess { get; set; }
        public bool isAccessAllowed { get; set; }
        public string buyerUserId { get; set; }
        public string userPassword { get; set; }
        public string cntPrsnCellNoIsoCode { get; set; }
        public string cntPrsnPhoneIsoCode { get; set; }
        public string cntPrsnPhoneExt { get; set; }
        public string cntPrsnAltEmail { get; set; }
        public string cntPrsnGroupName { get; set; }
        public override string ToString()
        {
            return $"id: {id}, buyerId: {buyerId}, contactPersonGroupId: {contactPersonGroupId}, salutationName: {salutationName}, cntPrsnFirstName: {cntPrsnFirstName}, cntPrsnMiddleName: {cntPrsnMiddleName}, cntPrsnLastName: {cntPrsnLastName}, buyerDesignationName: {buyerDesignationName}" +
                $", cntPrsnEmail: {cntPrsnEmail}, cntPrsnPhone: {cntPrsnPhone}, cntPrsnCellNo: {cntPrsnCellNo}, cmcForAuditReport: {cmcForAuditReport}, cmcForInvoice: {cmcForInvoice}, cmcForCAP: {cmcForCAP}, cmcForClientPortalAccess: {cmcForClientPortalAccess}, isAccessAllowed: {isAccessAllowed}" +
                $", buyerUserId: {buyerUserId}, userPassword: {userPassword}, cntPrsnPhoneExt: {cntPrsnPhoneExt}, cntPrsnAltEmail: {cntPrsnAltEmail}";
        }
    }
}
