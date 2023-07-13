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
    public class clientSiteHolidayController : ControllerBase
    {
        clientSiteHolidayDAL _activeDAL = new clientSiteHolidayDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsClientSiteHoliday> offList = _activeDAL.SelectAllClientSiteHoliday(dbName);
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
                clsClientSiteHoliday off = _activeDAL.SelectClientSiteHolidayById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByClientSiteId")]
        public clsResult GetByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                clsClientSiteHoliday off = _activeDAL.SelectClientSiteHolidayByClientSiteId(clientSiteId, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] List<clsClientSiteHoliday> value)
        {
            try
            {
                if (value != null)
                {
                 _activeDAL.deleteClientSiteHolidayByClientSiteId(value[0].clientSiteId, value[0].dbName);
                 foreach (var item in value)
                 {
                if (item.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateClientSiteHoliday(ValidateData(item));
                    result.id = item.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertClientSiteHoliday(ValidateData(item));
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

        private clsClientSiteHoliday ValidateData(clsClientSiteHoliday value)
        {
            //Add Logic For Insert And Update
            clsClientSiteHoliday obj = new clsClientSiteHoliday();
            if (value.id > 0)
            {
                value.active = true;
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
