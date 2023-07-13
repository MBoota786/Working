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
    public class standardAuditsTypesController : ControllerBase
    {
        standardAuditsTypesDAL _activeDAL = new standardAuditsTypesDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsStandardAuditsTypes> offList = _activeDAL.SelectAllStandardAuditsTypes(dbName); result.Data = new List<object>();
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
                clsStandardAuditsTypes off = _activeDAL.SelectStandardAuditsTypesById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccreditationStandardId/{accreditationStandardId}")]
        public clsResult GetByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            try
            {
                List<clsStandardAuditsTypes> offList = _activeDAL.SelectStandardAuditsTypesByAccreditationStandardId(accreditationStandardId, dbName);
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
        public clsResult Post([FromBody] clsStandardAuditsTypes value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateStandardAuditTypes(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertStandardAuditTypes(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        private clsStandardAuditsTypes ValidateData(clsStandardAuditsTypes value)
        {
            //Add Logic For Insert And Update
            clsStandardAuditsTypes obj = new clsStandardAuditsTypes();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
    }
}
