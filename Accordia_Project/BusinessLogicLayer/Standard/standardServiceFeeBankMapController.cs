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
    public class standardServiceFeeBankMapController : ControllerBase
    {
        standardServiceFeeBankMapDAL _activeDAL = new standardServiceFeeBankMapDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsStandardServiceFeeBankMap> offList = _activeDAL.SelectAllStandardServiceFeeBankMap(dbName);
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
        [HttpGet("GetForDropDown")]
        public clsResult GetForDropDown(string dbName)
        {
            try
            {
                List<clsStandardServiceFeeBankMap> offList = _activeDAL.SelectAllStandardServiceFeeBankMap(dbName).Where(x => x.active == true).ToList();
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
                clsStandardServiceFeeBankMap off = _activeDAL.SelectStandardServiceFeeBankMapById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByStandardServiceFeeId")]
        public clsResult GetByStandardServiceFeeId(int standardServiceFeeId, string dbName)
        {
            try
            {
                List<clsStandardServiceFeeBankMap> offList = _activeDAL.SelectStandardServiceFeeBankMapByStandardServiceFeeId(standardServiceFeeId, dbName);
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
        public clsResult Post([FromBody] clsStandardServiceFeeBankMap value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateStandardServiceFeeBankMap(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertStandardServiceFeeBankMap(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                List<clsStandardServiceFeeBankMap> offList = _activeDAL.SelectAllStandardServiceFeeBankMap(value.dbName);
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

        private clsStandardServiceFeeBankMap ValidateData(clsStandardServiceFeeBankMap value)
        {
            //Add Logic For Insert And Update
            clsStandardServiceFeeBankMap obj = new clsStandardServiceFeeBankMap();
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
