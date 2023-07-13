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
    public class accrChargesAmountMapController : ControllerBase
    {
        accrChargesAmountMapDAL _activeDAL = new accrChargesAmountMapDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccrChargesAmountMap> offList = _activeDAL.SelectAllAccrChargesAmountMap(dbName);
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
                clsAccrChargesAmountMap off = _activeDAL.SelectAccrChargesAmountMapById(id, dbName).FirstOrDefault();
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

        [HttpGet("GetByAccreditationChargesId/{accreditationChargesId}")]
        public clsResult GetByAccreditationChargesId(int accreditationChargesId, string dbName)
        {
            try
            {
                List<clsAccrChargesAmountMap> offList = _activeDAL.SelectAccrChargesAmountMapByAccreditationChargesId(accreditationChargesId, dbName);
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
        public clsResult Post([FromBody] clsAccrChargesAmountMap value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccrChargesAmountMap(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccrChargesAmountMap(ValidateData(value));
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
        [HttpDelete("{id}")]
        public clsResult Delete(int id, string dbName)
        {
            try
            {
                if (id > 0)
                {
                    _activeDAL.ActiveFalseForDeleteAccrChargesAmountMapById(id, dbName);
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
        private clsAccrChargesAmountMap ValidateData(clsAccrChargesAmountMap value)
        {
            //Add Logic For Insert And Update
            clsAccrChargesAmountMap obj = new clsAccrChargesAmountMap();
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
