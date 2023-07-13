using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class salutationController : ControllerBase
    {
        salutationDAL _activeDAL = new salutationDAL();
        logsDAL _logsDAL = new logsDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsSalutation> offList = _activeDAL.SelectAllSalutation(dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

       
        [HttpGet("{id}")]
        public clsResult Get(int id,string dbName)
        {
            try
            {
                clsSalutation off = _activeDAL.SelectSalutationById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }
        [HttpPost]
        public clsResult Post([FromBody] clsSalutation value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    //_activeDAL.UpdateSiteContactPersonGroup(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertSalutation(ValidateData(value));
                    result.id = Id;
                    value.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    log(value, "Insert", value.dbName);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private void log(clsSalutation obj, string actionName, string dbName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.active = true;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = "Salutation";
            _logsDAL.InsertLogs(clsLog);
        }
        private clsSalutation ValidateData(clsSalutation value)
        {
            //Add Logic For Insert And Update
            clsSalutation obj = new clsSalutation();
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
