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
   // [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class standardServiceFeeMasterController : ControllerBase
    {
        standardServiceFeeMasterDAL _activeDAL = new standardServiceFeeMasterDAL();
        standardServiceFeeDetailDAL _dtlDAL = new standardServiceFeeDetailDAL();
        standardServiceFeeBankMapDAL _bankDAL = new standardServiceFeeBankMapDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsStandardServiceFeeMaster> offList = _activeDAL.SelectAllStandardServiceFeeMaster(dbName);
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

       private clsStandardServiceFeeMaster GetDetails(clsStandardServiceFeeMaster item, string dbName)
        {
            try
            {
                if (item != null && item.id > 0)
                {
                    item.feeDetail = new List<clsStandardServiceFeeDetail>();
                    item.feeDetail = _dtlDAL.SelectAllStandardServiceFeeDetailByStandardServiceFeeId(item.id, dbName).Where(x => x.isOtherCharge == false).ToList();
                    item.otherFeeDetail = new List<clsStandardServiceFeeDetail>();
                    item.otherFeeDetail = _dtlDAL.SelectAllStandardServiceFeeDetailByStandardServiceFeeId(item.id, dbName).Where(x => x.isOtherCharge == true).ToList();
                    item.bankMap = new List<clsStandardServiceFeeBankMap>();
                    item.bankMap = _bankDAL.SelectStandardServiceFeeBankMapByStandardServiceFeeId(item.id, dbName);
                }
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public clsResult Get(int id, string dbName)
        {
            try
            {
                clsStandardServiceFeeMaster off = _activeDAL.SelectStandardServiceFeeMasterById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                off = GetDetails(off, dbName);
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
        [HttpGet("StandardServiceFeeMasterByReceivableOfficeId/{receivableOfficeId}")]
        public clsResult GetByStandardServiceFeeMasterByReceivableOfficeId(int receivableOfficeId, string dbName)
        {
            try
            {
                List<clsStandardServiceFeeMaster> offList = _activeDAL.SelectStandardServiceFeeMasterByReceivableOfficeId(receivableOfficeId, dbName);
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
        [HttpGet("GetByStandardServiceFeeMasterByOfficeId")]
        public clsResult GetByStandardServiceFeeMasterByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsStandardServiceFeeMaster> offList = _activeDAL.SelectStandardServiceFeeMasterByOfficeId(officeId, dbName);
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
        [HttpGet("GetStandardServiceFeeForQuotatonByAppIdClientSiteId")]
        public clsResult GetStandardServiceFeeForQuotatonByAppIdClientSiteId(int appId, int clientSiteId, string dbName)
        {
            try
            {
                List<clsStandardServiceFeeMaster> offList = _activeDAL.SelectStandardServiceFeeForQuotatonByAppIdClientSiteId(appId,clientSiteId, dbName);
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
        public clsResult Post([FromBody] clsStandardServiceFeeMaster value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateStandardServiceFeeMaster(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    if (_activeDAL.IsServiceExistByAccreditationStandardId(value.accreditationStandardId, value.dbName))
                    {
                        result.id = value.id;
                        result.message = "Service Already Exist For This Standard...!";
                        result.isSuccess = false;
                        return result;
                    }
                    else
                    {
                        // Insert Query
                        int Id = _activeDAL.InsertStandardServiceFeeMaster(ValidateData(value));
                        value.id = Id;
                        result.id = Id;
                        result.message = General.messageModel.insertMessage;
                        result.isSuccess = true;
                    }
                }
                if (value.id > 0)
                {
                    InsertFeeDetail(value);
                    InsertBankMap(value);
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        private void InsertFeeDetail(clsStandardServiceFeeMaster obj)
        {
            try
            {
            if (obj.feeDetail != null)
            {
                foreach (var item in obj.feeDetail)
                {
                        item.standardServiceFeeId = obj.id;
                        item.serviceId = 1;
                        item.feeName = item.auditTypeName + " Fee ("+obj.serviceFeeName +")";
                        item.isAmount = true;
                        item.isPercent = false;
                        item.isOtherCharge = false;
                        item.dbName = obj.dbName;
                        item.active = true;
                        item.createdBy = obj.userId;
                        item.createdOn = DateTime.Now;
                        _dtlDAL.InsertStandardServiceFeeDetail(item);
                }
            } 
            if (obj.otherFeeDetail != null)
            {
                foreach (var item in obj.otherFeeDetail)
                {
                        item.standardServiceFeeId = obj.id;
                        item.serviceId = 1;
                        item.isAmount = true;
                        item.isPercent = false;
                        item.isOtherCharge = true;
                        item.dbName = obj.dbName;
                        item.active = true;
                        item.createdBy = obj.userId;
                        item.createdOn = DateTime.Now;
                        _dtlDAL.InsertStandardServiceFeeDetail(item);
                }
            }
            }
            catch (Exception)
            {
              throw new ArgumentException("Error In Fee Detail Insert ..!");
            }
        }     
        private void InsertBankMap(clsStandardServiceFeeMaster obj)
        {
            try
            {
                if (obj.bankMap != null)
                {
                    foreach (var item in obj.bankMap)
                    {
                            item.standardServiceFeeId = obj.id;
                            item.dbName = obj.dbName;
                            item.active = true;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            _bankDAL.InsertStandardServiceFeeBankMap(item);
                    }
                } 
            }
            catch (Exception)
            {
              throw new ArgumentException("Error In Bank Insert ..!");
            }
        }

        private clsStandardServiceFeeMaster ValidateData(clsStandardServiceFeeMaster value)
        {
            //Add Logic For Insert And Update
            clsStandardServiceFeeMaster obj = new clsStandardServiceFeeMaster();
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
