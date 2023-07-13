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
    public class accrCountryScopeMapController : ControllerBase
    {
        accrCountryScopeMapDAL _activeDAL = new accrCountryScopeMapDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccrCountryScopeMap> offList = _activeDAL.SelectAllAccrCountryScopeMap(dbName);
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
                clsAccrCountryScopeMap off = _activeDAL.SelectAccrCountryScopeMapById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccreditationBodyStandardId/{accreditationBodyStandardId}")]
        public clsResult GetByAccreditationBodyStandardId(int accreditationBodyStandardId, string dbName)
        {
            try
            {
                List<clsAccrCountryScopeMap> offList = _activeDAL.spSelectAccrCountryScopeMapByAccreditationBodyStandardId(accreditationBodyStandardId, dbName);
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
        public clsResult Post([FromBody] List<clsAccrCountryScopeMap> value)
        {
            try
            {
                if (value != null)
                {
                    int index = 0;
                    foreach (var item in value)
                    {
                if (item.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccrCountryScopeMap(ValidateData(item));
                    result.id = item.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // For Delete Old
                    if (index == 0)
                    {
                        _activeDAL.DeleteAccrCountryScopeMapByAccreditationBodyStandardId(item.accreditationBodyStandardId, item.dbName);
                        index = 1;
                    }
                     // Insert Query
                            int Id = _activeDAL.InsertAccrCountryScopeMap(ValidateData(item));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                    }
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsAccrCountryScopeMap ValidateData(clsAccrCountryScopeMap value)
        {
            //Add Logic For Insert And Update
            clsAccrCountryScopeMap obj = new clsAccrCountryScopeMap();
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
