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
    public class auditApplicationReviewPointStatusController : ControllerBase
    {
        auditApplicationReviewPointStatusDAL _activeDAL = new auditApplicationReviewPointStatusDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAuditApplicationReviewPointStatus> offList = _activeDAL.SelectAllAuditApplicationReviewPointStatus(dbName);
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
                clsAuditApplicationReviewPointStatus off = _activeDAL.SelectAuditApplicationReviewPointStatusById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] clsAuditApplicationReviewPointStatus value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAuditApplicationReviewPointStatus(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.spInsertAuditApplicationReviewPointStatus(ValidateData(value));
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

        private clsAuditApplicationReviewPointStatus ValidateData(clsAuditApplicationReviewPointStatus value)
        {
            //Add Logic For Insert And Update
            clsAuditApplicationReviewPointStatus obj = new clsAuditApplicationReviewPointStatus();
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
