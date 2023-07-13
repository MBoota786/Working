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
    public class serviceFeeTypeController : ControllerBase
    {
        serivceFeeTypeDAL _activeDAL = new serivceFeeTypeDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsServiceFeeType> offList = _activeDAL.SelectAllServiceFeeType(dbName);
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
        [HttpGet("GetForDropDown")]
        public clsResult GetForDropDown(string dbName)
        {
            try
            {
                List<clsServiceFeeType> offList = _activeDAL.SelectAllServiceFeeType(dbName).Where(x=> x.active == true).ToList();
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
        [HttpGet("GetByServiceTypeId")]
        public clsResult GetByServiceTypeId(int serviceTypeId,string dbName)
        {
            try
            {
                List<clsServiceFeeType> offList = _activeDAL.SelectServiceFeeTypeByServiceTypeId(serviceTypeId, dbName).Where(x=> x.active == true).ToList();
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
                clsServiceFeeType off = _activeDAL.SelectServiceFeeTypeById(id,dbName).FirstOrDefault();
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
        [HttpPost]
        public clsResult Post([FromBody] clsServiceFeeType value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateServiceFeeType(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    log(value, "Update", value.dbName);
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertServiceFeeType(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    log(value, "Insert",value.dbName);
                }
                List<clsServiceFeeType> offList = _activeDAL.SelectServiceFeeTypeByServiceTypeId(value.serviceTypeId, value.dbName).ToList();
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private void log(clsServiceFeeType obj,string actionName,string dbName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = "Service Fee Type";
            _logsDAL.InsertLogs(clsLog);
        }

        private clsServiceFeeType ValidateData(clsServiceFeeType value)
        {
            //Add Logic For Insert And Update
            clsServiceFeeType obj = new clsServiceFeeType();
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
