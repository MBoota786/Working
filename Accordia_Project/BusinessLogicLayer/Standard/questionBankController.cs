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
    public class questionBankController : ControllerBase
    {
        questionBankDAL _activeDAL = new questionBankDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsQuestionBank> offList = _activeDAL.SelectAllQuestionsBank(dbName);
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
                clsQuestionBank off = _activeDAL.SelectQuestionsBankById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByParentQuestionId/{parentQuestionId}")]
        public clsResult GetByParentQuestionId(int parentQuestionId, string dbName)
        {
            try
            {
                clsQuestionBank off = _activeDAL.SelectQuestionsBankByParentQuestionId(parentQuestionId, dbName).FirstOrDefault();
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
                List<clsQuestionBank> offList = _activeDAL.SelectQuestionsBankByOfficeId(officeId, dbName);
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
        [HttpGet("GetByOfficeIdAndCountryId")]
        public clsResult GetByOfficeIdAndCountryId(int officeId,int countryId, string dbName)
        {
            try
            {
                List<clsQuestionBank> offList = _activeDAL.SelectQuestionsBankByOfficeIdAndCountryId(officeId,countryId, dbName);
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
        [HttpGet("GetByOfficeIdAndCountryIdAndStateProvinceId")]
        public clsResult GetByOfficeIdAndCountryIdAndStateProvinceId(int officeId,int countryId,int stateProvinceId, string dbName)
        {
            try
            {
                List<clsQuestionBank> offList = _activeDAL.SelectQuestionsBankByOfficeIdAndCountryIdAndStateProvinceId(officeId,countryId,stateProvinceId, dbName);
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
        public clsResult Post([FromBody] clsQuestionBank value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateQuestionsBank(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertQuestionsBank(ValidateData(value));
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

        private clsQuestionBank ValidateData(clsQuestionBank value)
        {
            //Add Logic For Insert And Update
            clsQuestionBank obj = new clsQuestionBank();
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
