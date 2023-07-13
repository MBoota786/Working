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
    public class buyerContactPersonController : ControllerBase
    {
        buyerContactPersonDAL _activeDAL = new buyerContactPersonDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsBuyerContactPerson> offList = _activeDAL.SelectAllBuyerContactPerson(dbName);
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
        public clsResult Get(int id, string dbName)
        {
            try
            {
                clsBuyerContactPerson off = _activeDAL.SelectBuyerContactPersonById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByBuyerId")]
        public clsResult GetByBuyerId(int buyerId, string dbName)
        {
            try
            {
                List<clsBuyerContactPerson> offList = _activeDAL.SelectBuyerContactPersonByBuyerId(buyerId, dbName);
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
        public clsResult Post([FromBody] clsBuyerContactPerson value)
        {
            try
            {
                if (value.id > 0)
                {
                   // Update Query
                    _activeDAL.UpdateBuyerContactPerson(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    log(value, "Update", value.dbName, "Buyer Contact Person");
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertBuyerContactPerson(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    value.id = Id;
                    log(value, "Insert", value.dbName, "Buyer Contact Person");
                }
                List<clsBuyerContactPerson> offList = _activeDAL.SelectBuyerContactPersonByBuyerId(value.id,value.dbName);
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
        private void log(clsBuyerContactPerson obj, string actionName, string dbName, string formName)
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
        private clsBuyerContactPerson ValidateData(clsBuyerContactPerson value)
        {
            //Add Logic For Insert And Update
            clsBuyerContactPerson obj = new clsBuyerContactPerson();
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
