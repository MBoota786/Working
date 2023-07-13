using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class siteBillingInfoController : ControllerBase
    {
        siteBillingInfoDAL _activeDAL = new siteBillingInfoDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsSiteBillingInfo> offList = _activeDAL.SelectAllSiteBillingInfo(dbName);
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


        [HttpGet("{id}")]
        public clsResult Get(int id,string dbName)
        { 
            try
            {
                clsSiteBillingInfo off = _activeDAL.SelectSiteBillingInfoById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("GetClientInfoForSetByClientId")]
        public clsResult GetClientInfoForSetByClientId(int clientId,string dbName)
        { 
            try
            {
                clsSiteBillingInfo billingInfo = new clsSiteBillingInfo();
                clientMasterDAL _clientDAL = new clientMasterDAL();
                clsClientMaster clientMaster = _clientDAL.SelectClientMasterById(clientId, dbName).FirstOrDefault();
                if (clientMaster != null)
                {
                    billingInfo.billingCompanyName = clientMaster.clientCompanyName;
                    billingInfo.billingAddressLine1 = clientMaster.clientAddressLine1;
                    billingInfo.billingAddressLine2 = clientMaster.clientAddressLine2;
                    billingInfo.billingAddressLine3 = clientMaster.clientAddressLine3;
                    billingInfo.countryId = clientMaster.countryId;
                    billingInfo.stateProvinceId = clientMaster.stateProvinceId;
                    billingInfo.cityId = clientMaster.cityId;
                    billingInfo.billingPostalCode = clientMaster.clientPostalCode;
                    billingInfo.billingEmail = clientMaster.clientEmail;
                    billingInfo.billingWebsite = clientMaster.clientWebsite;
                    billingInfo.billingPhone = clientMaster.clientPhone;
                    billingInfo.billingPhoneExt = clientMaster.clientPhoneExt;
                    billingInfo.billingPhoneIsoCode = clientMaster.clientPhoneIsoCode;

                    clientContactPersonDAL _contactPersonDAL = new clientContactPersonDAL();
                    billingInfo.contactPersonList = new List<clsClientContactPersons>();
                    billingInfo.contactPersonList =_contactPersonDAL.SelectClientContactPersonsByClient(clientId, dbName);
                }
                result.Data = new List<object>();
                result.Data.Add(billingInfo);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("GetClientInfoForSetByClientSiteId")]
        public clsResult GetClientInfoForSetByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                clsSiteBillingInfo billingInfo = new clsSiteBillingInfo();
                clientSitesDAL _clientDAL = new clientSitesDAL();
                clsClientSites clientSite = _clientDAL.SelectClientSitesById(clientSiteId, dbName).FirstOrDefault();
                if (clientSite != null)
                {
                    billingInfo.billingCompanyName = clientSite.siteName;
                    billingInfo.billingAddressLine1 = clientSite.siteAddressLine1;
                    billingInfo.billingAddressLine2 = clientSite.siteAddressLine2;
                    billingInfo.billingAddressLine3 = clientSite.siteAddressLine3;
                    billingInfo.countryId = clientSite.countryId;
                    billingInfo.stateProvinceId = clientSite.stateProvinceId;
                    billingInfo.cityId = clientSite.cityId;
                    billingInfo.billingPostalCode = clientSite.sitePostalCode;
                    billingInfo.billingEmail = clientSite.siteEmail;
                    billingInfo.billingWebsite = clientSite.siteWebsite;
                    billingInfo.billingPhone = clientSite.sitePhone;
                    billingInfo.billingPhoneExt = clientSite.sitePhoneExt;
                    billingInfo.billingPhoneIsoCode = clientSite.phoneIsoCode;

                    clientContactPersonDAL _contactPersonDAL = new clientContactPersonDAL();
                    billingInfo.contactPersonList = new List<clsClientContactPersons>();
                    billingInfo.contactPersonList = _contactPersonDAL.SelectClientContactPersonsByClientSite(clientSite.clientId,clientSite.id, dbName);
                }
                result.Data = new List<object>();
                result.Data.Add(billingInfo);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("GetByAppIdClientSiteId")]
        public clsResult GetByAppIdClientSiteId(int appId,int clientSiteId,string dbName)
        { 
            try
            {
                List<clsSiteBillingInfo> offList = _activeDAL.SelectSiteBillingInfoByAppIdClientSiteId(appId, clientSiteId, dbName);
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
        [HttpPost]
        public clsResult Post([FromBody] clsSiteBillingInfo value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateSiteBillingInfo(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    log(value, "Update", value.dbName, "Application Client Billing Information");

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertSiteBillingInfo(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    log(value, "Insert", value.dbName, "Application Client Billing Information");

                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private void log(clsSiteBillingInfo obj, string actionName, string dbName, string formName)
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
        private clsSiteBillingInfo ValidateData(clsSiteBillingInfo value)
        {
            //Add Logic For Insert And Update
            clsSiteBillingInfo obj = new clsSiteBillingInfo();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
    }
}
