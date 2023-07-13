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
    public class accrBodyStandardDurationController : ControllerBase
    {
        accrBodyStandardDurationDAL _activeDAL = new accrBodyStandardDurationDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccrBodyStandardDuration> offList = _activeDAL.SelectAllAccrBodyStandardDuration(dbName);
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
                clsAccrBodyStandardDuration off = _activeDAL.SelectAccrBodyStandardDurationById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccrBodyStandardId/{accrBodyStandardId}")]
        public clsResult GetByAccrBodyStandardId(int accrBodyStandardId, string dbName)
        {
            try
            {
                List<clsAccrBodyStandardDuration> offList = _activeDAL.SelectAccrBodyStandardDurationByAccrBodyStandardId(accrBodyStandardId, dbName);
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
        public clsResult Post([FromBody] clsAccrBodyStandardDuration value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccrStandardDuration(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccrStandardDuration(ValidateData(value));
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

        private clsAccrBodyStandardDuration ValidateData(clsAccrBodyStandardDuration value)
        {
            //Add Logic For Insert And Update
            clsAccrBodyStandardDuration obj = new clsAccrBodyStandardDuration();
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
