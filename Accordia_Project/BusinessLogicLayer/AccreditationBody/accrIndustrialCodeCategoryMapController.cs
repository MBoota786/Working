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
    public class accrIndustrialCodeCategoryMapController : ControllerBase
    {
        accrIndustrialCodeCategoryMapDAL _activeDAL = new accrIndustrialCodeCategoryMapDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccrIndustrialCodeCategoryMap> offList = _activeDAL.SelectAllAccrIndustrialCodeCategoryMap(dbName);
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
                clsAccrIndustrialCodeCategoryMap off = _activeDAL.SelectAccrIndustrialCodeCategoryMapById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccreditationBodyStandardIdAndAccrIndustrialCodeId")]
        public clsResult GetByAccreditationBodyStandardIdAndAccrIndustrialCodeId(int accreditationBodyStandardId, int accrIndustrialCodeTypeId, string dbName)
        {
            try
            {
                List<clsAccrIndustrialCodeCategoryMap> offList = _activeDAL.SelectAllAccrIndustrialCodeCategoryMapByAccreditationBodyStandardIdAndAccrIndustrialCodeId(accreditationBodyStandardId, accrIndustrialCodeTypeId, dbName);
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
        public clsResult Post([FromBody] clsAccrIndustrialCodeCategoryMap value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccrIndustrialCodeCategoryMap(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccrIndustrialCodeCategoryMap(ValidateData(value));
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
                    _activeDAL.ActiveFalseForDeleteAccrIndustrialCodeCategoryMapById(id, dbName);
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

        private clsAccrIndustrialCodeCategoryMap ValidateData(clsAccrIndustrialCodeCategoryMap value)
        {
            //Add Logic For Insert And Update
            clsAccrIndustrialCodeCategoryMap obj = new clsAccrIndustrialCodeCategoryMap();
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
