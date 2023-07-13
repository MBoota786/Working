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
    public class clientContactPersonsController : ControllerBase
    {
        clientContactPersonDAL _activeDAL = new clientContactPersonDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsClientContactPersons> offList = _activeDAL.SelectAllClientContactPersons(dbName);
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
        [HttpGet("GetByClient")]
        public clsResult GetByClient(int clientId,string dbName)
        {
            try
            {
                List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClient(clientId, dbName);
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
        [HttpGet("GetByClientSite")]
        public clsResult GetByClientSite(int clientId,int clientSiteId,string dbName)
        {
            try
            {
                List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClientSite(clientId, clientSiteId, dbName);
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
        [HttpGet("GetBySiteBillingInfoId")]
        public clsResult GetBySiteBillingInfoId(int siteBillingInfoId,string dbName)
        {
            try
            {
                List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsBySiteBillingInfoId(siteBillingInfoId, dbName);
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
                clsClientContactPersons off = _activeDAL.SelectClientContactPersonsById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetFinanceForSite/{clientId}")]
        public clsResult GetFinanceForSite(int clientId, string dbName)
        {
            try
            {
                clsClientContactPersons off = _activeDAL.SelectClientContactPersonsClientFinanceForSite(clientId, dbName).FirstOrDefault();
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
        [HttpPost("PostActiveFalseForDelete")]
        public clsResult PostActiveFalseForDelete(int id , string dbName)
        {
            try
            {
                //Active False
                _activeDAL.UpdateActiveFalseById(id,dbName);
                result.id = id;
                result.message = General.messageModel.deleteMessage;
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        [HttpPost]
        public clsResult Post([FromBody] clsClientContactPersons value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateClientContactPersons(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    if (value.clientId > 0 && (value.clientSiteId == 0 || value.clientSiteId == null) && (value.siteBillingInfoId == 0 || value.siteBillingInfoId == null))
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClient(value.clientId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                        log(value, "Update Client Contact Person", value.dbName, "Client Contact Person");
                    }
                    else if (value.clientId > 0 && value.clientSiteId > 0)
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClientSite(value.clientId, value.clientSiteId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                        log(value, "Update Client Site Contact Person", value.dbName, "Client Site Contact Person");
                    }
                    else if (value.siteBillingInfoId > 0)
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsBySiteBillingInfoId(value.siteBillingInfoId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                        log(value, "Update Billing Information Contact Person", value.dbName, "Billing Information Contact Person");
                    }
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertClientContactPersons(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    value.id = Id;
                    result.isSuccess = true;
                    if (value.clientId > 0 && (value.clientSiteId == 0 || value.clientSiteId == null) && (value.siteBillingInfoId == 0 || value.siteBillingInfoId == null))
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClient(value.clientId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                        log(value, "Insert Client Contact Person", value.dbName, "Client Contact Person");
                    }
                    else if (value.clientId > 0 && value.clientSiteId > 0)
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClientSite(value.clientId, value.clientSiteId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                        log(value, "Insert Client Site Contact Person", value.dbName, "Client Site Contact Person");
                    }
                    else if (value.siteBillingInfoId > 0)
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsBySiteBillingInfoId(value.siteBillingInfoId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                        log(value, "Insert Billing Information Contact Person", value.dbName, "Billing Information Contact Person");
                    }


                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }      
        [HttpPost("PostForReview")]
        public clsResult PostForReview([FromBody] clsClientContactPersons value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateClientContactPersonsForReview(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    log(value, "Update From Application Review", value.dbName, "Application Review");
                    if (value.clientId > 0 && (value.clientSiteId == 0 || value.clientSiteId == null) && (value.siteBillingInfoId == 0 || value.siteBillingInfoId == null))
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClient(value.clientId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                    }
                    else if (value.clientId > 0 && value.clientSiteId > 0)
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsByClientSite(value.clientId, value.clientSiteId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                    }
                    else if (value.siteBillingInfoId > 0)
                    {
                        List<clsClientContactPersons> offList = _activeDAL.SelectClientContactPersonsBySiteBillingInfoId(value.siteBillingInfoId, value.dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                    }
                }
                else
                {
                    result.message = General.messageModel.idEmpMessage;
                    result.isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsClientContactPersons ValidateData(clsClientContactPersons value)
        {
            //Add Logic For Insert And Update
            clsClientContactPersons obj = new clsClientContactPersons();
            if (!String.IsNullOrEmpty(value.OtherCntPrsnGroup))
            {
                value.contactPersonGroupId = CheckAndInsertContactPersonGroup(value.OtherCntPrsnGroup,value.dbName,Convert.ToInt32(value.userId));
            }
            if (value.id > 0)
            {
               // value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.active = true;
              //  value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
        private void log(clsClientContactPersons obj, string actionName, string dbName, string formName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy =Convert.ToInt32(obj.userId);
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = formName;
            _logsDAL.InsertLogs(clsLog);
        }
        private int CheckAndInsertContactPersonGroup(string OtherCntPrsnGroup, string dbName, int userId)
        {
            siteContactPersonGroupDAL _activeDAL = new siteContactPersonGroupDAL();
            if (_activeDAL.IsExistSiteContactPersonGroup(OtherCntPrsnGroup, dbName) == false)
            {
                clsSiteContactPersonGroup objBusiness = new clsSiteContactPersonGroup();
                objBusiness.dbName = dbName;
                objBusiness.cntPrsnGroupName = OtherCntPrsnGroup;
                objBusiness.userId = userId;
                objBusiness.createdBy = userId;
                objBusiness.createdOn = DateTime.Now;
                return _activeDAL.InsertSiteContactPersonGroup(objBusiness);
            }
            else
            {
                return _activeDAL.SelectSiteContactPersonGroupByName(OtherCntPrsnGroup, dbName).FirstOrDefault().id;
            }
        }
    }
}
