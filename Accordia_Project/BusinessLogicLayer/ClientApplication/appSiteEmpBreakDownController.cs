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
    public class appSiteEmpBreakDownController : ControllerBase
    {
        appSiteEmpBreakDownDAL _activeDAL = new appSiteEmpBreakDownDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppSiteEmpBreakDown> offList = _activeDAL.SelectAllAppSiteEmpBreakDown(dbName);
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
                clsAppSiteEmpBreakDown off = _activeDAL.SelectAppSiteEmpBreakDownById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByClientSiteIdAndAppId")]
        public clsResult GetByClientSiteIdAndAppId(int appId,int clientSiteId, string dbName)
        { 
            try
            {
                List<clsAppSiteEmpBreakDown> offList = _activeDAL.SelectAppSiteEmpBreakDownByClientSiteIdAndAppId(appId,clientSiteId, dbName);
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
        public clsResult Post([FromBody] clsAppSiteEmpBreakDown value)
        {
            try
            {
                clsAppSiteEmpBreakDown obj = _activeDAL.SelectAppSiteEmpBreakDownByClientSiteIdAndAppId(value.appId, value.clientSiteId, value.dbName).FirstOrDefault();
                if (obj != null && obj.id > 0)
                {
                    value.id = obj.id;
                }
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAppSiteEmpBreakDown(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAppSiteEmpBreakDown(ValidateData(value));
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

        private clsAppSiteEmpBreakDown ValidateData(clsAppSiteEmpBreakDown value)
        {
            //Add Logic For Insert And Update
            clsAppSiteEmpBreakDown obj = new clsAppSiteEmpBreakDown();
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
