using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
   // [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class applicationQuotationController : ControllerBase
    {
        applicationQuotationDAL _activeDAL = new applicationQuotationDAL();
        applicationQuotationDtlDAL dtlDAL = new applicationQuotationDtlDAL();
        appQuotationFeesDAL quotationFeesDAL = new appQuotationFeesDAL();
        appQuotationFeesDtlDAL feesDtlDAL = new appQuotationFeesDtlDAL();
        appQuotationFeesTaxDAL feesTaxDAL = new appQuotationFeesTaxDAL();
        appQuotationOtherChargesDAL otherChargesDAL = new appQuotationOtherChargesDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsApplicationQuotation> offList = _activeDAL.SelectAllApplicationQuotation(dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

       
        [HttpGet("GetQuotationPrintByQuotationId")]
        public clsResult GetQuotationPrintByQuotationId(int quotationId, string dbName)
        {
            try
            {
                clsQuotationPrint quotationPrint = new clsQuotationPrint();
                if (quotationId > 0)
                {
                    clsApplicationQuotation applicationQuotation = _activeDAL.SelectApplicationQuotationById(quotationId,dbName).FirstOrDefault();
                    clientMasterDAL _clientDAL = new clientMasterDAL();
                    clientSitesDAL _sitesDAL = new clientSitesDAL();
                    clientContactPersonDAL _clientContactPersonDAL = new clientContactPersonDAL();
                    clsClientMaster clientMaster = _clientDAL.spSelectClientMasterByQuotationId(quotationId, dbName).FirstOrDefault();
                    clientMaster.serviceAcquired = clientMaster.serviceAcquired.ToUpper();
                    List<clsClientSites> listSites = new List<clsClientSites>();
                    listSites = _sitesDAL.SelectClientSitesByClientIdAndAppId(applicationQuotation.clientId, applicationQuotation.appId, dbName);
                    clsClientContactPersons siteClientContactPersons = new clsClientContactPersons();
                    bool hasContactPersonSite = false;
                    bool hasSiteRepresentative = false;
                    if (listSites != null)
                    {
                        clientSiteLanguageDAL _siteLanguageDAL = new clientSiteLanguageDAL();
                        appClientProcessDAL _processDAL = new appClientProcessDAL();
                        appClientProductDAL _productDAL = new appClientProductDAL();
                        appSiteShiftsDAL _shiftDAL = new appSiteShiftsDAL();
                        siteInfrastructureMasterDAL _infrastructureDAL = new siteInfrastructureMasterDAL();
                        applicationDetailDAL _applicationDetail = new applicationDetailDAL();
                        appQuotationFeesDtlDAL _feesDAL = new appQuotationFeesDtlDAL();
                        foreach (var item in listSites)
                        {
                            var siteLang = _siteLanguageDAL.SelectClientSiteLanguageByClientSiteId(item.id, dbName);
                            foreach (var itemLang in siteLang)
                            {
                                item.siteLanguages += itemLang.siteLanguage + ", ";
                            }
                            var siteProcess = _processDAL.SelectAppClientProcessByAppIdClientSiteId(item.appId, item.id, dbName);
                            foreach (var itemProc in siteProcess)
                            {
                                item.siteProcess += itemProc.appClientProcess + ", ";
                            }
                            var siteProduct = _productDAL.SelectAllAppClientProductByAppIdAndClientSiteId(item.appId, item.id, dbName);
                            foreach (var itemProd in siteProduct)
                            {
                                item.siteProduct += itemProd.appClientProduct+ ", ";
                            }
                            item.totalSiteShift = _shiftDAL.SelectAppSiteShiftsByAppIdClientSiteId(item.appId, item.id, dbName).Count;
                            var infraStruct = _infrastructureDAL.SelectSiteInfrastructureMasterByClientSiteId(item.id,dbName).FirstOrDefault();
                            if (infraStruct != null)
                            {
                                item.facilityCoverArea = infraStruct.siteFacilityCoverArea +" "+ infraStruct.siteFacilityCoverAreaUnitName;
                                item.facilityPlotArea = infraStruct.siteFacilityPlotArea +" "+ infraStruct.siteFacilityPlotAreaUnitName;
                            }
                            var applicationDtl = _applicationDetail.SelectApplicationDetailByAppIdAndClientSiteId(applicationQuotation.appId, item.id, dbName).FirstOrDefault();
                            if (applicationDtl != null)
                            {
                                item.totalSiteEmployees = applicationDtl.totalSiteEmployees;
                            }
                            item.siteServiceAcquired = clientMaster.serviceAcquired;
                            hasContactPersonSite = _clientContactPersonDAL.SelectClientContactPersonsByClientSite(clientMaster.id,item.id, dbName).Any(x => x.cmcForInvoice == true);
                            siteClientContactPersons = hasContactPersonSite ? _clientContactPersonDAL.SelectClientContactPersonsByClientSite(clientMaster.id, item.id, dbName).Where(x => x.cmcForInvoice == true).FirstOrDefault() : null;
                            item.contactPersonName = hasContactPersonSite ? siteClientContactPersons.salutationName + " " + siteClientContactPersons.cntPrsnFirstName+" "+ siteClientContactPersons.cntPrsnMiddleName + " " + siteClientContactPersons.cntPrsnLastName:string.Empty;
                            item.sitefeeDtl = new List<clsAppQuotationFeesForPrint>();
                            item.sitefeeDtl = _feesDAL.SelectQuotationFeesForPrintByClientSiteIdAndQuotationId(item.id, quotationId, dbName);  
                            item.sitefeeTaxDtl = new List<clsAppQuotationFeesForPrint>();
                            item.sitefeeTaxDtl = _feesDAL.SelectQuotationFeesTaxForPrintByClientSiteIdAndQuotationId(item.id, quotationId, dbName);
                            hasSiteRepresentative = _clientContactPersonDAL.SelectClientContactPersonsByClientSite(clientMaster.id, item.id, dbName).Any(x => x.contactPersonGroupId == 6);
                            var siteRepresentative = hasContactPersonSite ? _clientContactPersonDAL.SelectClientContactPersonsByClientSite(clientMaster.id, item.id, dbName).Where(x => x.contactPersonGroupId == 6).FirstOrDefault() : null;
                            item.siteRepresentative = hasSiteRepresentative ? siteRepresentative.salutationName + " " + siteRepresentative.cntPrsnFirstName + " " + siteRepresentative.cntPrsnMiddleName + " " + siteRepresentative.cntPrsnLastName : string.Empty;
                            item.sitefeeOtherCharges = new List<clsAppQuotationOtherCharges>();
                            item.sitefeeOtherCharges = otherChargesDAL.SelectAppQuotationOtherChargesForPrintByClientSiteIdAndQuotationId(item.id, quotationId, dbName);
                        }

                    }
                    bool hasContactPerson = _clientContactPersonDAL.SelectClientContactPersonsByClient(clientMaster.id, dbName).Any(x => x.cmcForInvoice == true);
                    clsClientContactPersons clientContactPersons = hasContactPerson ? _clientContactPersonDAL.SelectClientContactPersonsByClient(clientMaster.id, dbName).Where(x => x.cmcForInvoice == true).FirstOrDefault():null;
                    //add in print
                    quotationPrint.quotation = applicationQuotation;
                    quotationPrint.quoSubject = "Quotation for " + clientMaster.serviceAcquired + " Certification Services";
                    quotationPrint.client = clientMaster;
                    quotationPrint.clientContactPerson = clientContactPersons;
                    quotationPrint.clientSites = listSites;
                    quotationPrint.listInterviewSampling = new List<clsStandardInterviewRequirement>();
                    standardInterviewRequirementDAL _interviewDAL = new standardInterviewRequirementDAL();
                    quotationPrint.listInterviewSampling = _interviewDAL.SelectStandardInterviewRequirementByQuotationId(quotationId, dbName);
                    quotationPrint.listAuditMandays = new List<clsManDaysFormula>();
                    manDaysFormulaDAL _mandayDAL = new manDaysFormulaDAL();
                    quotationPrint.listAuditMandays = _mandayDAL.SelectMandaysFormulaByQuotationId(quotationId,dbName);
                    quotationPrint.mandaysColumn = quotationPrint.listAuditMandays.Select(x => x.auditTypeName).Distinct().ToList();
                }
                else
                {
                    result.message = General.messageModel.idEmpMessage;
                    result.isSuccess = true;
                }
              //  List<clsApplicationQuotation> activeList = _activeDAL.SelectApplicationQuotationByAppIdClientSiteId(appId, clientSiteId, dbName);
                result.Data = new List<object>();
                result.Data.Add(quotationPrint);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        } 
        [HttpGet("GetForQuotationById")]
        public clsResult GetForQuotationById(int appId,int clientSiteId, string dbName)
        {
            try
            {
                List<clsApplicationQuotation> activeList = _activeDAL.SelectApplicationQuotationByAppIdClientSiteId(appId, clientSiteId, dbName);
                result.Data = new List<object>();
                result.Data.AddRange(activeList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }  
        [HttpGet("GetByAppIdClientSiteId/{appId,clientSiteId}")]
        public clsResult GetByAppIdClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                List<clsApplicationQuotation> activeList = _activeDAL.SelectApplicationQuotationByAppIdClientSiteId(appId, clientSiteId, dbName);
                result.Data = new List<object>();
                result.Data.AddRange(activeList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("GetForQuotationListByOfficeId")]
        public clsResult GetForQuotationListByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsApplicationQuotationList> activeList = _activeDAL.SelectQuotationApplicationForListByOfficeId(officeId, dbName);
                result.Data = new List<object>();
                result.Data.AddRange(activeList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
      
        [HttpPost]
        public clsResult Post([FromBody] clsApplicationQuotation value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateApplicationQuotation(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    log(value, "Update", value.dbName, "Application Quotation");
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertApplicationQuotation(ValidateData(value));
                    result.id = Id;
                    value.id = Id;
                    InsertQuotationDtl(value);
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    log(value, "Insert", value.dbName, "Application Quotation");
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private void log(clsApplicationQuotation obj, string actionName, string dbName, string formName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = formName;
            _logsDAL.InsertLogs(clsLog);
        }
        private void InsertQuotationDtl(clsApplicationQuotation obj)
        {
            try
            {
            if (obj.id > 0 && obj.quotationDtl != null)
            {
                foreach (var item in obj.quotationDtl)
                {
                    item.dbName = obj.dbName;
                    item.createdBy = obj.userId;
                    item.createdOn = DateTime.Now;
                    item.applicationQuotationId = obj.id;
                int QDtlId = dtlDAL.InsertApplicationQuotationDtl(item);
                        if (item.listQuotationFees != null)
                        {
                            foreach (var feeItem in item.listQuotationFees)
                            {
                                feeItem.dbName = obj.dbName;
                                feeItem.createdBy = obj.userId;
                                feeItem.createdOn = DateTime.Now;
                                feeItem.applicationQuotationDtlId = QDtlId;
                                int feeId = quotationFeesDAL.InsertAppQuotationFees(feeItem);
                               if (feeItem.listFeesDtl != null)
                                {
                                    foreach (var feeDtlItem in feeItem.listFeesDtl)
                                    {
                                        feeDtlItem.dbName = obj.dbName;
                                        feeDtlItem.createdBy = obj.userId;
                                        feeDtlItem.createdOn = DateTime.Now;
                                        feeDtlItem.appQuotationFeesId = feeId;
                                        //Insert Fees Detail
                                        feesDtlDAL.InsertAppQuotationFeesDtl(feeDtlItem);
                                    }
                                }  
                                if (feeItem.listTaxFees != null)
                                {
                                    foreach (var feeTax in feeItem.listTaxFees)
                                    {
                                        feeTax.dbName = obj.dbName;
                                        feeTax.createdBy = obj.userId;
                                        feeTax.createdOn = DateTime.Now;
                                        feeTax.appQuotationFeesId = feeId;
                                        //Insert Fee Tax
                                        feesTaxDAL.InsertAppQuotationFeesTax(feeTax);
                                    }
                                }

                            }
                        }
                        if (item.listQuotationOtherCharges != null)
                        {
                            foreach (var otherCharges in item.listQuotationOtherCharges)
                            {
                                otherCharges.dbName = obj.dbName;
                                otherCharges.createdBy = obj.userId;
                                otherCharges.createdOn = DateTime.Now;
                                otherCharges.applicationQuotationDtlId = QDtlId;
                                //Insert Other Charge
                                otherChargesDAL.InsertAppQuotationOtherCharges(otherCharges);
                            }
                        }
                }
            }
            }
            catch (Exception)
            {
                _activeDAL.spDeleteQuotationById(obj.id, obj.dbName);
                throw new ArgumentException("Error In Quotation Detail Insert.Quotation Not Created.");
            }
        }
        private clsApplicationQuotation ValidateData(clsApplicationQuotation value)
        {
            //Add Logic For Insert And Update
            clsApplicationQuotation obj = new clsApplicationQuotation();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.quotationNo = InitializeCode(value.dbName, value.officeId);
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
        private string InitializeCode(string dbName, int officeId)
        {
            string Code = "QOU-001";
            try
            {
                officeStationaryPrefixDAL _offPrefixDAL = new officeStationaryPrefixDAL();
                clsOfficeStationaryPrefix objPre = new clsOfficeStationaryPrefix();
                objPre = _offPrefixDAL.SelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId(officeId, Convert.ToInt32(enumStationaryType.Quotation), dbName).FirstOrDefault();
                if (objPre == null)
                {
                    objPre = new clsOfficeStationaryPrefix();
                }
                string prefix = objPre.officeStationaryPrefix != "" ? objPre.officeStationaryPrefix : "QOU";
                int startNum = objPre.startFrom > 0 ? objPre.startFrom : 1;
                int incrementNum = objPre.incrementNo > 0 ? objPre.incrementNo : 1;
                Code = prefix + "-" + startNum;
                string MaxCode = _activeDAL.GetMaxCode(dbName);
                if (!string.IsNullOrEmpty(MaxCode))
                {
                    var substring = MaxCode.Substring(MaxCode.LastIndexOf('-') + 1);
                    int Add = Convert.ToInt32(substring);
                    Add = Add + incrementNum;
                    substring = Regex.Replace(substring, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
                    Code = prefix + "-" + substring;
                }
                else
                {
                    // Code = "APP-1";
                }

                return Code;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
