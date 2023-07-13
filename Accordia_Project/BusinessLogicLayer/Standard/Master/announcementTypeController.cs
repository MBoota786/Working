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
    public class announcementTypeController : ControllerBase
    {
        announcementTypeDAL _activeDAL = new announcementTypeDAL();

        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAnnouncementType> offList = _activeDAL.SelectAllAnouncementType(dbName);
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
                clsAnnouncementType off = _activeDAL.SelectAnouncementTypeById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccreditationStandardIdAndAuditTypeId")]
        public clsResult GetByAccreditationStandardIdAndAuditTypeId(int accreditationStandardId, int auditTypeId, string dbName)
        {
            try
            {
                List<clsAnnouncementType> offList = _activeDAL.SelectAllAnouncementTypeByAccreditationStandardIdAndAuditTypeId(accreditationStandardId,auditTypeId, dbName);
                result.Data = new List<object>();
                result.Data.Add(offList);
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
        public clsResult Post([FromBody] clsAnnouncementType value)
        {
            try
            {
                if (value.id > 0)
                {
                    // Update Query
                    _activeDAL.UpdateAnnouncementType(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAnnouncementType(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                List<clsAnnouncementType> offList = _activeDAL.SelectAllAnouncementType(value.dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsAnnouncementType ValidateData(clsAnnouncementType value)
        {
            //Add Logic For Insert And Update
            clsAnnouncementType obj = new clsAnnouncementType();
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
