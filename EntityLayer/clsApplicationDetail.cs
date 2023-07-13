using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsApplicationDetail : clsMain
    {
        public int id { get; set; }
        public int appId { get; set; }
        public int accreditationStandardId { get; set; }
        public int auditTypeId { get; set; }
        public int auditAnnouncementTypeId { get; set; }
        public int timePeriodUnitId { get; set; }
        public int auditTimePeriod { get; set; }
        public int totalSiteEmployees { get; set; }
        public int clientSiteId { get; set; }
        public string regulatoryAuthority { get; set; }
        public DateTime? certificationExpiresOn { get; set; }
        public string appSerialNo { get; set; }
        public string timePeriodUnit { get; set; }
        public string standardName { get; set; }
        public string siteName { get; set; }
        public string auditTypeName { get; set; }
        public string announcementTypeName { get; set; }
        public bool isSiteEngagedWithConsultant { get; set; }
        public string siteCertificationScope { get; set; }
    }
}
