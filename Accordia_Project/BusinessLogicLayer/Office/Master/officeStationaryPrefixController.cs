using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeStationaryPrefixController : ControllerBase
    {
        officeStationaryPrefixDAL _activeDAL = new officeStationaryPrefixDAL();
        clsResult result = new clsResult();

        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeStationaryPrefix> offList = _activeDAL.SelectAllOfficeStationaryPrefix(dbName);
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
                clsOfficeStationaryPrefix off = _activeDAL.SelectOfficeStationaryPrefixById(id,dbName).FirstOrDefault();
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
        [HttpGet("GetByOfficeIdAndStationaryTypeId")]
        public clsResult GetByOfficeIdAndStationaryTypeId(int officeId,int stationaryTypeId, string dbName)
        {
            try
            {
                clsOfficeStationaryPrefix off = _activeDAL.SelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId(officeId,stationaryTypeId,dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] clsOfficeStationaryPrefix value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateOfficeStationaryPrefix(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertOfficeStationaryPrefix(ValidateData(value));
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

 
        private clsOfficeStationaryPrefix ValidateData(clsOfficeStationaryPrefix value)
        {
            //Add Logic For Insert And Update
            clsOfficeStationaryPrefix obj = new clsOfficeStationaryPrefix();
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
