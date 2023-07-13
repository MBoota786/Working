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
    public class applicationOfficeSitesController : ControllerBase
    {
        applicationOfficeSitesDAL _activeDAL = new applicationOfficeSitesDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsApplicationOfficeSites> offList = _activeDAL.SelectAllApplicationOfficeSites(dbName);
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
        public clsResult GetByAppId(int appId, string dbName)
        {
            try
            {
                List<clsApplicationOfficeSites> activeList = _activeDAL.SelectApplicationOfficeSitesByAppId(appId, dbName);
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
        [HttpGet("GetByAppIdClientSiteId")]
        public clsResult GetByAppIdClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                clsApplicationOfficeSites activeList = _activeDAL.SelectApplicationOfficeSitesByAppIdClientSiteId(appId,clientSiteId, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(activeList);
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
        public clsResult Post([FromBody] clsApplicationOfficeSites value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateApplicationOfficeSites(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertApplicationOfficeSites(ValidateData(value));
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

        private clsApplicationOfficeSites ValidateData(clsApplicationOfficeSites value)
        {
            //Add Logic For Insert And Update
            clsApplicationOfficeSites obj = new clsApplicationOfficeSites();
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
