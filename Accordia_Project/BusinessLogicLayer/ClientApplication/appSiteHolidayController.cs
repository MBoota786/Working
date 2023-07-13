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
    public class appSiteHolidayController : ControllerBase
    {
        appSiteHolidayDAL _activeDAL = new appSiteHolidayDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppSiteHoliday> offList = _activeDAL.SelectAllAppSiteHoliday(dbName);
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


        [HttpGet("GetByAppIdClientSiteId/{clientSiteId}")]
        public clsResult GetByAppIdClientSiteId(int clientSiteId,string dbName)
        {
           
            try
            {
                List<clsAppSiteHoliday> activeList = _activeDAL.spSelectAppSiteHolidayByAppIdClientSiteId(clientSiteId, dbName);
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
        public clsResult Post([FromBody] clsAppSiteHoliday value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAppSiteHoliday(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAppSiteHoliday(ValidateData(value));
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

        private clsAppSiteHoliday ValidateData(clsAppSiteHoliday value)
        {
            //Add Logic For Insert And Update
            clsAppSiteHoliday obj = new clsAppSiteHoliday();
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
