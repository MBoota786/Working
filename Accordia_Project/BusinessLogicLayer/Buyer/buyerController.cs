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
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class buyerController : ControllerBase
    {
        buyerDAL _activeDAL = new buyerDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsBuyer> offList = _activeDAL.SelectAllBuyer(dbName);
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
                clsBuyer off = _activeDAL.SelectBuyerById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByBuyerOfficeTypeId")]
        public clsResult GetByBuyerOfficeTypeId(int buyerOfficeTypeId, string dbName)
        {
            try
            {
                List<clsBuyer> offList = _activeDAL.SelectBuyerByBuyerOfficeTypeId(buyerOfficeTypeId, dbName);
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
        public clsResult Post([FromBody] clsBuyer value)
        {
            try
            {
                if (value.id > 0)
                {
                   // Update Query
                    _activeDAL.UpdateBuyer(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    log(value, "Update", value.dbName, "Buyer");
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertBuyer(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    value.id = Id;
                    log(value, "Insert", value.dbName, "Buyer");
                }
                List<clsBuyer> offList = _activeDAL.SelectAllBuyer(value.dbName);
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
        private void log(clsBuyer obj, string actionName, string dbName, string formName)
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
        private clsBuyer ValidateData(clsBuyer value)
        {
            //Add Logic For Insert And Update
            clsBuyer obj = new clsBuyer();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.code = InitializeCode(value.dbName, value.officeId);
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
        private string InitializeCode(string dbName, int officeId)
        {
            string Code = "BYR-001";
            try
            {
                officeStationaryPrefixDAL _offPrefixDAL = new officeStationaryPrefixDAL();
                clsOfficeStationaryPrefix objPre = new clsOfficeStationaryPrefix();
                objPre = _offPrefixDAL.SelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId(officeId, Convert.ToInt32(enumStationaryType.Buyer), dbName).FirstOrDefault();
                if (objPre == null)
                {
                    objPre = new clsOfficeStationaryPrefix();
                }
                string prefix = objPre.officeStationaryPrefix != "" ? objPre.officeStationaryPrefix : "BYR";
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
