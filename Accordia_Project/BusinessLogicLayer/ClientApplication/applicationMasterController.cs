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
    public class applicationMasterController : ControllerBase
    {
        applicationMasterDAL _activeDAL = new applicationMasterDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsApplicationMaster> offList = _activeDAL.SelectAllApplicationMaster(dbName);
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
                clsApplicationMaster off = _activeDAL.SelectApplicationMasterById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByOfficeIdAndClientId")]
        public clsResult GetByOfficeIdAndClientId(int officeId,int clientId, string dbName)
        {
            try
            {
                List<clsApplicationMaster> offList = _activeDAL.SelectApplicationMasterByOfficeIdAndClientId(officeId,clientId,dbName);
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
        [HttpGet("GetSelectApplicationForListViewByOfficeId")]
        public clsResult GetSelectApplicationForListViewByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsApplicationMaster> offList = _activeDAL.SelectApplicationForListView(officeId,dbName);
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
        [HttpGet("GetSelectApplicationForReViewList")]
        public clsResult GetSelectApplicationForReViewList(int officeId, string dbName)
        {
            try
            {
                List<clsApplicationMaster> offList = _activeDAL.SelectApplicationForReViewList(officeId,dbName);
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
        public clsResult Post([FromBody] clsApplicationMaster value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateApplicationMaster(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    clsApplicationMaster off = _activeDAL.SelectApplicationMasterById(result.id, value.dbName).FirstOrDefault();
                    result.Data = new List<object>();
                    result.Data.Add(off);
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertApplicationMaster(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    clsApplicationMaster off = _activeDAL.SelectApplicationMasterById(Id, value.dbName).FirstOrDefault();
                    result.Data = new List<object>();
                    result.Data.Add(off);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        [HttpPost("PostUpdateApplicationMasterScopeAndProcess")]
        public clsResult PostUpdateApplicationMasterScopeAndProcess([FromBody] clsApplicationMaster value)
        {
            try
            {
                //Update Query
                _activeDAL.UpdateApplicationMasterScopeAndProcess(value);
                result.id = value.id;
                result.message = General.messageModel.updateMessage;
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }  
        [HttpPost("PostUpdateApplicationMasterAppCertificationStatusById")]
        public clsResult PostUpdateApplicationMasterAppCertificationStatusById(int id,string dbName)
        {
            try
            {
                if (id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateApplicationMasterAppCertificationStatusById(id, dbName);
                    result.id = id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
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
        private clsApplicationMaster ValidateData(clsApplicationMaster value)
        {
            //Add Logic For Insert And Update
            clsApplicationMaster obj = new clsApplicationMaster();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.appCode = InitializeCode(value.dbName, value.officeId);
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
        private string InitializeCode(string dbName,int officeId)
        {
            string Code = "APP-1";
            try
            {
                officeStationaryPrefixDAL _offPrefixDAL = new officeStationaryPrefixDAL();
                clsOfficeStationaryPrefix objPre = new clsOfficeStationaryPrefix();
                objPre = _offPrefixDAL.SelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId(officeId, Convert.ToInt32(enumStationaryType.Application), dbName).FirstOrDefault();
                if (objPre == null)
                {
                    objPre = new clsOfficeStationaryPrefix();
                }
                string prefix = objPre.officeStationaryPrefix != "" ? objPre.officeStationaryPrefix : "APP";
                int startNum = objPre.startFrom > 0 ? objPre.startFrom : 1;
                int incrementNum = objPre.incrementNo > 0 ? objPre.incrementNo : 1;
                Code = prefix + "-"+ startNum;
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
