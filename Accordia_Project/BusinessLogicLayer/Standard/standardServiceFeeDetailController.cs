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
  //  [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class standardServiceFeeDetailController : ControllerBase
    {
        standardServiceFeeDetailDAL _activeDAL = new standardServiceFeeDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            List<clsStandardServiceFeeDetail> offList = _activeDAL.SelectAllStandardServiceFeeDetail(dbName);
            result.Data = new List<object>();
            result.Data.AddRange(offList);
            result.isSuccess = true;
            return result;
        }

        [HttpGet("StandardServiceFeeDetailByStandardServiceFeeId/{standardServiceFeeId}")]
        public clsResult GetByStandardServiceFeeDetailByStandardServiceFeeId(int standardServiceFeeId, string dbName)
        {
            List<clsStandardServiceFeeDetail> offList = _activeDAL.SelectAllStandardServiceFeeDetailByStandardServiceFeeId(standardServiceFeeId, dbName);
            result.Data = new List<object>();
            result.Data.AddRange(offList);
            result.isSuccess = true;
            return result;
        } 
        [HttpGet("GetSelectStandardFeeDetailForTariffByAccreditationStandardId")]
        public clsResult GetSelectStandardFeeDetailForTariffByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            List<clsStandardServiceFeeDetail> offList = _activeDAL.SelectStandardFeeDetailForTariffByAccreditationStandardId(accreditationStandardId, dbName);
            result.Data = new List<object>();
            result.Data.AddRange(offList);
            result.isSuccess = true;
            return result;
        }
        [HttpPost]
        public clsResult Post([FromBody] clsStandardServiceFeeDetail value)
        {
            try
            {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateStandardServiceFeeDetail(ValidateData(value));
                result.id = value.id;
                result.message = General.messageModel.updateMessage;
                result.isSuccess = true;
            }
            else
            {
                // Insert Query
                _activeDAL.InsertStandardServiceFeeDetail(ValidateData(value));
                result.id = value.id;
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

        private clsStandardServiceFeeDetail ValidateData(clsStandardServiceFeeDetail value)
        {
            //Add Logic For Insert And Update
            clsStandardServiceFeeDetail obj = new clsStandardServiceFeeDetail();
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
