using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeController : ControllerBase
    {
        officeDAL _activeDAL = new officeDAL();
        clsResult result =new clsResult();
        // GET: api/<officeController>
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOffice> offList = _activeDAL.SelectAllOffice(dbName);
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
        [HttpGet("GetForListByReportingOfficeId")]
        public clsResult GetForListByReportingOfficeId(int reportingOfficeId, string dbName)
        {
            try
            {
                List<clsOffice> offList = _activeDAL.SelectOfficeForListByReportingOfficeId(reportingOfficeId, dbName);
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
        [HttpGet("GetByOfficeTypeId")]
        public clsResult GetByOfficeTypeId(int officeTypeId, string dbName)
        {
            try
            {
                List<clsOffice> offList = _activeDAL.SelectOfficeByOfficeTypeId(officeTypeId, dbName);
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

        // GET api/<officeController>/5
        [HttpGet("{id}")]
        public clsResult Get(int id,string dbName)
        {
            try
            {
                clsOffice off = _activeDAL.SelectAllOfficeById(id, dbName).FirstOrDefault();
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

        // POST api/<officeController>
        [HttpPost]
        public clsResult Post([FromBody] clsOffice value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateOffice(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {

                    // Insert Query
                    int Id = _activeDAL.InsertOffice(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    //Set Office For UserLogin If HeadOffice
                    if (value.officeTypeId == 1)
                    {
                        userLoginDAL userDAL = new userLoginDAL();
                        userDAL.UpdateOfficeIdById(value.userId, Id, value.dbName);
                    }
                    //End
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        private clsOffice ValidateData(clsOffice value)
        {
            //Add Logic For Insert And Update
            clsOffice obj = new clsOffice();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;

                if (value.otherBusinessType != null && value.otherBusinessType != "")
                {
                    value.businessTypeId = CheckAndInsertBusinessType(value.otherBusinessType, value.dbName, value.userId);
                }
            }
            else
            {
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;

                //Set Folder Path For Azure
                if (value.officeTypeId > 0)
                {
                    officeTypeDAL offTypeDAL = new officeTypeDAL();
                    clsOfficeType objOff = offTypeDAL.SelectOfficeTypeById(value.officeTypeId,value.dbName).FirstOrDefault();
                    value.officeFolderPath = value.officeName + "-" + objOff.officeTypeName;
                    //End
                }
                else
                {
                    value.officeFolderPath = value.officeName;
                }
                if (value.otherBusinessType != null && value.otherBusinessType != "")
                {
                  value.businessTypeId =  CheckAndInsertBusinessType(value.otherBusinessType, value.dbName, value.userId);
                }
                //Set Office Code
                value.officeCode = InitializeCode(value.dbName, value.officeTypeId);
                //End
            }
            obj = value;
            return obj;
        }

        private int CheckAndInsertBusinessType(string businessTypeName,string dbName,int userId)
        {
            businessTypeDAL _activeDAL = new businessTypeDAL();
            if (_activeDAL.IsBusinessTypeExist(businessTypeName, dbName) == false)
            {
                clsBusinessType objBusiness = new clsBusinessType();
                objBusiness.dbName = dbName;
                objBusiness.businessTypeName = businessTypeName;
                objBusiness.userId = userId;
                return _activeDAL.InsertBusinessType(objBusiness);
            }
            else
            {
            return _activeDAL.SelectBusinessTypeByName(businessTypeName, dbName).FirstOrDefault().id;
            }
        }

        private string InitializeCode(string dbName,int officeTypeId)
        {
            string Code = "HO-001";
            try
            {
                officeTypeDAL _offTypeDAL = new officeTypeDAL();
                string prefix =  _offTypeDAL.SelectOfficeTypeById(officeTypeId,dbName).FirstOrDefault().officeTypePrefix;
                prefix = prefix != "" ? prefix : "HO";
                Code = prefix + "-001";
                string MaxCode = _activeDAL.GetMaxCode(dbName);
                if (!string.IsNullOrEmpty(MaxCode))
                {
                    var substring = MaxCode.Substring(MaxCode.LastIndexOf('-') + 1);
                    int Add = Convert.ToInt32(substring);
                    Add = Add + 1;
                    substring = Regex.Replace(substring, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
                    Code = prefix + "-" + substring;
                }
                else
                {
                    Code = "HO-001";
                }

                return Code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
