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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class roleRightsController : ControllerBase
    {
        roleRightsDAL _activeDAL = new roleRightsDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsRoleRights> offList = _activeDAL.SelectAllRoleRights(dbName);
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
        [HttpGet("GetForSelectAllModuleForRoleRights")]
        public clsResult GetForSelectAllModuleForRoleRights(string dbName)
        {
            try
            {
                List<clsRoleRights> offList = _activeDAL.SelectAllModuleForRoleRights(dbName);
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
        [HttpGet("GetAllModuleForRoleRightsByRoleId/{roleId}")]
        public clsResult GetAllModuleForRoleRightsByRoleId(int roleId, string dbName)
        {
            try
            {
                List<clsRoleRights> offList = _activeDAL.SelectAllModuleForRoleRightsByRoleId(roleId,dbName);
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
        [HttpGet("GetByParentRoleId/{roleId}")]
        public clsResult GetByParentRoleId(int roleId, string dbName)
        {
            try
            {
                List<clsRoleRights> offList = _activeDAL.SelectRoleRightsByRoleId(roleId,dbName);
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
                clsRoleRights off = _activeDAL.SelectRoleRightsById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] List<clsRoleRights> value)
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
                            _activeDAL.UpdateRoleRights(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // Insert Query
                            int Id = _activeDAL.InsertRoleRights(ValidateData(item));
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


        private clsRoleRights ValidateData(clsRoleRights value)
        {
            //Add Logic For Insert And Update
            clsRoleRights obj = new clsRoleRights();
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
