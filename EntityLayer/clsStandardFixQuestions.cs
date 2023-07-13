using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardFixQuestions : clsMain
    { 
        public int id { get; set; }
        public int appId                          { get; set; }
        public int clientSiteId                   { get; set; }
        public int accreditationBodyStandardId    { get; set; }
        public bool isWrapFirstTimeAudit           { get; set; }
        public bool isWrapReCertification          { get; set; }
        public bool isLapsedAudit                  { get; set; }
        public string wrapFacilityId                 { get; set; }
        public DateTime? wrapLastAuditDate              { get; set; }
        public DateTime? wrapCertificateExpiryDate      { get; set; }
        public bool isWrapPcaConductedFacility     { get; set; }
        public DateTime? wrapPcaDate                    { get; set; }
        public bool isWrapOpenPcaFinded            { get; set; }
        public string wrapWhoConductPca              { get; set; }
        public DateTime? wrapExpectedAuditDate          { get; set; }
        public bool isSmetaFullInitial             { get; set; }
        public bool isSmetaPeriodic                { get; set; }
        public bool isSmetaFullFollowup            { get; set; }
        public bool isSmetaPartialFollowup         { get; set; }
        public bool isSmetaRegisterSedex           { get; set; }
        public string smetaSedexRegNumber            { get; set; }
        public string smetaSedexRegId                { get; set; }
        public DateTime? smetaExpectedAuditDate         { get; set; }

        //Question
        public string auditType { get; set; }
        public string WrapPca { get; set; }
        public string wrapOpenPca { get; set; }
        public string smetaRegSedex { get; set; }
        public string CtpatFullInitial { get; set; }
        public bool isCtpatFullInitial { get; set; }
        public int announcementTypeId { get; set; }
        public int auditWindowInWeek { get; set; }
        public DateTime? ctpatExpectedAuditDate { get; set; }
        public int auditTypeId { get; set; }
    }
}
