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
    public class appClientSecondaryProcessController : ControllerBase
    {
        appClientSecondaryProcessDAL _activeDAL = new appClientSecondaryProcessDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppClientSecondaryProcess> offList = _activeDAL.SelectAllAppClientSecondaryProcess(dbName);
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
        [HttpGet("GetByAppId/{appId}")]
        public clsResult GetByAppId(int appId,string dbName)
        {
            try
            {
                List<clsAppClientSecondaryProcess> offList = _activeDAL.SelectAppClientSecondaryProcessByAppId(appId, dbName);
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
        [HttpGet("GetByAppIdAndClientSiteId")]
        public clsResult GetByAppIdAndClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                List<clsAppClientSecondaryProcess> offList = _activeDAL.SelectAppClientSecondaryProcessByAppIdAndClientSiteId(appId,clientSiteId, dbName);
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
        [HttpGet("GetByOldClientSiteId")]
        public clsResult GetByOldClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                List<clsAppClientSecondaryProcess> offList = _activeDAL.SelectOldAppClientSecondaryProcessByClientSiteId(clientSiteId, dbName);
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
                clsAppClientSecondaryProcess off = _activeDAL.SelectAppClientSecondaryProcessById(id, dbName).FirstOrDefault();
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
        [HttpPost("PostActiveFalseById")]
        public clsResult PostActiveFalseById(int id, string dbName)
        {
            try
            {
                if (id > 0)
                {
                    _activeDAL.SetAppClientSecondaryProcessById(id, dbName);
                    result.id = id;
                    result.message = General.messageModel.deleteMessage;
                    result.isSuccess = true;
                }
                else
                {
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
        [HttpPost]
        public clsResult Post([FromBody] List<clsAppClientSecondaryProcess> value)
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
                            _activeDAL.UpdateAppClientSecondaryProcess(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // For Delete Old
                            if (index == 0)
                            {
                                _activeDAL.DeleteAppClientSecondaryProcessByAppId(item.appId, item.dbName);
                                index = 1;
                            }
                            // Insert Query
                            int Id = _activeDAL.InsertAppClientSecondaryProcess(ValidateData(item));
                            result.id = Id;
                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                        }
                    }
                    if (value[0].appId > 0)
                    {
                        List<clsAppClientSecondaryProcess> offList = _activeDAL.SelectAppClientSecondaryProcessByAppIdAndClientSiteId(value[0].appId, value[0].clientSiteId, value[0].dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
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

        private clsAppClientSecondaryProcess ValidateData(clsAppClientSecondaryProcess value)
        {
            //Add Logic For Insert And Update
            clsAppClientSecondaryProcess obj = new clsAppClientSecondaryProcess();
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
