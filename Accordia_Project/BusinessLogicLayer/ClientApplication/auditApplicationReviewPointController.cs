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
    public class auditApplicationReviewPointController : ControllerBase
    {
        auditApplicationReviewPointDAL _activeDAL = new auditApplicationReviewPointDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAuditApplicationReviewPoint> offList = _activeDAL.SelectAllAuditApplicationReviewPoint(dbName);
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
                clsAuditApplicationReviewPoint off = _activeDAL.spSelectAuditApplicationReviewPointById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccreditationStandardAndAuditTypeId")]
        public clsResult GetByAccreditationStandardAndAuditTypeId(int accreditationStandardId,int auditTypeId, string dbName)
        {
            try
            {
                clsAuditApplicationReviewPoint off = _activeDAL.SelectAuditApplicationReviewPointByAccreditationStandardIdAndAuditTypeId(accreditationStandardId,auditTypeId, dbName).FirstOrDefault();
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
        [HttpGet("GetByAppId")]
        public clsResult GetByAppId(int appId, string dbName)
        {
            try
            {
                List<clsAuditApplicationReviewPoint> offList = _activeDAL.spSelectAuditApplicationReviewPointByAppId(appId, dbName).ToList();
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
        public clsResult Post([FromBody] clsAuditApplicationReviewPoint value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAuditApplicationReviewPoint(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAuditApplicationReviewPoint(ValidateData(value));
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
        private clsAuditApplicationReviewPoint ValidateData(clsAuditApplicationReviewPoint value)
        {
            //Add Logic For Insert And Update
            clsAuditApplicationReviewPoint obj = new clsAuditApplicationReviewPoint();
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
