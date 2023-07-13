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
    public class accreditationBankDetailController : ControllerBase
    {
        accreditationBankDetailDAL _activeDAL = new accreditationBankDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccreditationBankDetail> offList = _activeDAL.SelectAllAccreditationBankDetail(dbName);
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

       
        [HttpGet("GetByAccreditationId{accreditationId}")]
        public clsResult GetByAccreditationId(int accreditationId, string dbName)
        {
            try
            {
                List<clsAccreditationBankDetail> offList = _activeDAL.SelectAccreditationBankDetailByAccreditationId(accreditationId, dbName).ToList();
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
                clsAccreditationBankDetail offList = _activeDAL.SelectAccreditationBankDetailById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(offList);
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
        public clsResult Post([FromBody] clsAccreditationBankDetail value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccreditationBankDetail(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    List<clsAccreditationBankDetail> offList = _activeDAL.SelectAccreditationBankDetailByAccreditationId(value.accreditationId, value.dbName).ToList();
                    result.Data = new List<object>();
                    result.Data.AddRange(offList);
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccreditationBankDetail(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    List<clsAccreditationBankDetail> offList = _activeDAL.SelectAccreditationBankDetailByAccreditationId(value.accreditationId, value.dbName).ToList();
                    result.Data = new List<object>();
                    result.Data.AddRange(offList);
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        private clsAccreditationBankDetail ValidateData(clsAccreditationBankDetail value)
        {
            //Add Logic For Insert And Update
            clsAccreditationBankDetail obj = new clsAccreditationBankDetail();
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
        [HttpDelete("{id}")]
        public clsResult Delete(int id, string dbName)
        {
            try
            {
                if (id > 0)
                {
                    _activeDAL.ActiveFalseForDeleteAccreditationBankDetailById(id, dbName);
                    result.id = id;
                    result.message = General.messageModel.deleteMessage;
                    result.isSuccess = true;
                }
                else
                {
                    result.id = id;
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
    }
}
