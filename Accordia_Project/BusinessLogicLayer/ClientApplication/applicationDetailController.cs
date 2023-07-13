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
    public class applicationDetailController : ControllerBase
    {
        applicationDetailDAL _activeDAL = new applicationDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsApplicationDetail> offList = _activeDAL.SelectAllApplicationDetail(dbName);
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
        public clsResult GetByAppIdAndClientSiteId(int appId,int clientSiteId,string dbName)
        {
            try
            {
                List<clsApplicationDetail> offList = _activeDAL.SelectApplicationDetailByAppIdAndClientSiteId(appId,clientSiteId,dbName);
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
        [HttpGet("GetListByOfficeId/{officeId}")]
        public clsResult GetListByOfficeId(int officeId,string dbName)
        {
            try
            {
                List<clsApplicationDetail> offList = _activeDAL.SelectApplicationMasterForListByOfficeId(officeId, dbName);
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
        [HttpGet("GetApplicationDetailForAuditDurationByAppIdAndClientSiteId")]
        public clsResult GetApplicationDetailForAuditDurationByAppIdAndClientSiteId(int appId,int clientSiteId,string dbName)
        {
            try
            {
                List<clsApplicationDetail> offList = _activeDAL.SelectApplicationDetailForAuditDurationByAppIdAndClientSiteId(appId,clientSiteId, dbName);
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
                clsApplicationDetail off = _activeDAL.SelectApplicationDetailById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] List<clsApplicationDetail> value)
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
                    _activeDAL.UpdateApplicationDetail(ValidateData(item));
                    result.id = item.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertApplicationDetail(ValidateData(item));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                    }
                    if (value[0].appId > 0 && value[0].clientSiteId > 0)
                    {
                        List<clsApplicationDetail> offList = _activeDAL.SelectApplicationDetailByAppIdAndClientSiteId(value[0].appId, value[0].clientSiteId, value[0].dbName);
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
        [HttpPost("PostUpdateAuditDurationById")]
        public clsResult PostUpdateAuditDurationById([FromBody] List<clsApplicationDetail> value)
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
                    _activeDAL.UpdateApplicationDetailAuditDurationById(item);
                    result.id = item.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    result.message = General.messageModel.idEmpMessage;
                    result.isSuccess = false;
                }
                    }
                }
                else
                {
                    result.message = General.messageModel.listEmpMessage;
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

        private clsApplicationDetail ValidateData(clsApplicationDetail value)
        {
            //Add Logic For Insert And Update
            clsApplicationDetail obj = new clsApplicationDetail();
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
