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
    public class clientMasterController : ControllerBase
    {
        clientMasterDAL _activeDAL = new clientMasterDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsClientMaster> offList = _activeDAL.SelectAllClientMaster(dbName);
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
                clsClientMaster off = _activeDAL.SelectClientMasterById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByOfficeId/{officeId}")]
        public clsResult GetByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsClientMaster> offList = _activeDAL.SelectAllClientMasterByOfficeId(officeId, dbName);
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
        [HttpGet("GetByCompanyName")]
        public clsResult GetByCompanyName(string companyName,int officeId,string dbName)
        {
            
            try
            {
                List<clsClientMaster> offList = _activeDAL.SearchClientByCompanyName(companyName,officeId, dbName);
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
        public clsResult Post([FromBody] clsClientMaster value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateClientMaster(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertClientMaster(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }  
        [HttpPost("PostFromReview")]
        public clsResult PostFromReview([FromBody] clsClientMaster value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateClientMasterForReview(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    clsClientMaster off = _activeDAL.SelectClientMasterById(value.id, value.dbName).FirstOrDefault();
                    result.Data = new List<object>();
                    result.Data.Add(off);

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

        private clsClientMaster ValidateData(clsClientMaster value)
        {
            //Add Logic For Insert And Update
            clsClientMaster obj = new clsClientMaster();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
                if (value.otherBusinessType != null && value.otherBusinessType != "")
                {
                    value.businessTypeId = CheckAndInsertClientbusinessType(value.otherBusinessType, value.dbName, value.userId);
                }
              
            }
            else
            {
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
                value.clientCode = InitializeCode(value.dbName, value.officeId);
                if (value.otherBusinessType != null && value.otherBusinessType != "")
                {
                    value.businessTypeId = CheckAndInsertClientbusinessType(value.otherBusinessType, value.dbName, value.userId);
                }
            }
            obj = value;
            return obj;
        }
        private int CheckAndInsertClientbusinessType(string otherBusinessType, string dbName, int userId)
        {
            clientBusinessTypeDAL _activeDAL = new clientBusinessTypeDAL();
            if (_activeDAL.IsExistClientBusinessType(otherBusinessType, dbName) == false)
            {
                clsClientBusinessType objBusiness = new clsClientBusinessType();
                objBusiness.dbName = dbName;
                objBusiness.clientBusinessTypeName = otherBusinessType;
                objBusiness.userId = userId;
                objBusiness.createdBy = userId;
                objBusiness.createdOn = DateTime.Now;
                return _activeDAL.InsertClientBusinessType(objBusiness);
            }
            else
            {
                return _activeDAL.SelectClientBusinessTypeByName(otherBusinessType, dbName).FirstOrDefault().id;
            }
        }
        private string InitializeCode(string dbName, int officeId)
        {
            string Code = "C-1";
            try
            {
                officeStationaryPrefixDAL _offPrefixDAL = new officeStationaryPrefixDAL();
                clsOfficeStationaryPrefix objPre = new clsOfficeStationaryPrefix();
                objPre = _offPrefixDAL.SelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId(officeId, Convert.ToInt32(enumStationaryType.ClientMaster), dbName).FirstOrDefault();
                string prefix = objPre.officeStationaryPrefix != "" ? objPre.officeStationaryPrefix : "C";
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
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
