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
    public class appSiteAuditDaysDetailController : ControllerBase
    {
        appSiteAuditDaysDetailDAL _activeDAL = new appSiteAuditDaysDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppSiteAuditDaysDetail> offList = _activeDAL.spSelectAllAppSiteAuditDaysDetail(dbName);
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


        [HttpGet("GetByAppIdClientSiteId/{appId,clientSiteId}")]
        public clsResult GetByAppIdClientSiteId(int appId,int clientSiteId,string dbName)
        {   
            try
            {
                List<clsAppSiteAuditDaysDetail> activeList = _activeDAL.SelectAppSiteAuditDaysDetailByAppIdClientSiteId(appId, clientSiteId,dbName);
                result.Data = new List<object>();
                result.Data.AddRange(activeList);
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
        public clsResult Post([FromBody] clsAppSiteAuditDaysDetail value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAppSiteAuditDaysDetail(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAppSiteAuditDaysDetail(ValidateData(value));
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

        private clsAppSiteAuditDaysDetail ValidateData(clsAppSiteAuditDaysDetail value)
        {
            //Add Logic For Insert And Update
            clsAppSiteAuditDaysDetail obj = new clsAppSiteAuditDaysDetail();
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
