using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsClientSites : clsMain
    {
        public string siteLongitude;

        public int id { get; set; }
        public string clientSiteCode { set;get;}
        public int appId {set;get;}
        public int clientId {set;get;}
        public int siteTypeId {set;get;}
        public string siteName {set;get;}
        public int countryId {set;get;}
        public int stateProvinceId {set;get;}
        public int cityId  {set;get;}
        public string siteEmail {set;get;}
        public string sitePhone {set;get;}
        public string siteVatNo {set;get;}
        public bool isDormitoriesAllow { set; get; }
        public bool isMigrantWorkersAllow { set; get; }
        public int siteSubTypeId { set; get; }
        public string sitePostalCode { set; get; }
        public string siteWebsite { set; get; }
        public string phoneIsoCode { set; get; }
        public bool isEngagedConsultant { set; get; }
        public string sitePhoneExt { set; get; }
        public string siteAddressLine1 { set; get; }
        public string siteAddressLine2 { set; get; }
        public string siteAddressLine3 { set; get; }
        public string siteLatitude { get; set; }
        public string siteFacilityPlotArea { get; set; }
        public string siteFacilityCoverArea { get; set; }
        public int siteNumberOfBuilding { get; set; }
        public string siteTypeName { get; set; }
        public string serviceAcquired { get; set; }
        public string siteCertificationScope { get; set; }
        public string countryName { get; set; }
        public string stateProvinceName { get; set; }
        public string cityName { get; set; }
        //Quotation Extra Parameter
        public int totalSiteEmployees { get; set; }
        public int totalSiteShift { get; set; }
        public string siteProduct { get; set; }
        public string siteProcess { get; set; }
        public string facilityPlotArea { get; set; }
        public string facilityCoverArea { get; set; }
        public string siteLanguages { get; set; }
        public string contactPersonName { get; set; }
        public string siteRepresentative { get; set; }
        public string siteServiceAcquired { get; set; }
        public List<clsAppQuotationFeesForPrint> sitefeeDtl { get; set; }
        public List<clsAppQuotationFeesForPrint> sitefeeTaxDtl { get; set; }
        public List<clsAppQuotationOtherCharges> sitefeeOtherCharges { get; set; }
        //End
    }
}
