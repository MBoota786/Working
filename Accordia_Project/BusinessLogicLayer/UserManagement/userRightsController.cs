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
    public class userRightsController : ControllerBase
    {
        userRightsDAL _activeDAL = new userRightsDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsUserRights> offList = _activeDAL.SelectAllUserRights(dbName);
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
        [HttpGet("GetByUserLoginId/{userLoginId}")]
        public clsResult GetByUserLoginId(int userLoginId,string dbName)
        {
            try
            {
                List<clsUserRights> offList = _activeDAL.SelectUserRightsByUserLoginId(userLoginId,dbName);
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
                clsUserRights off = _activeDAL.SelectUserRightsById(id, dbName).FirstOrDefault();
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

        [HttpPost]
        public clsResult Post([FromBody] List<clsUserRights> value)
        {
            try
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        if (item.id > 0)
                        {
                            //Update Query
                            _activeDAL.UpdateUserRights(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // Insert Query
                            int Id = _activeDAL.InsertUserRights(ValidateData(item));
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

    
        private clsUserRights ValidateData(clsUserRights value)
        {
            //Add Logic For Insert And Update
            clsUserRights obj = new clsUserRights();
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
