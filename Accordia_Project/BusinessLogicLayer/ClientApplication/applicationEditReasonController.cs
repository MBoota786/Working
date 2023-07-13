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
   // [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class applicationEditReasonController : ControllerBase
    {
        applicationEditReasonDAL _activeDAL = new applicationEditReasonDAL();
        clsResult result = new clsResult();
        [HttpPost("PostAuditDaysUpdateWithReason")]
        public clsResult PostAuditDaysUpdateWithReason([FromBody] clsApplicationEditReason value)
        {
            try
            {
                //Application AuditDays Update
                applicationDetailDAL appDAL = new applicationDetailDAL();
                //Update Query
                appDAL.ApplicationDetailDynamicColumnUpdateById(value.applicationDetailId, "auditTimePeriod", value.newValue.ToString(), value.dbName); 
                //End
                int Id = _activeDAL.InsertApplicationEditReason(ValidateData(value));
                result.id = Id;
                result.message = General.messageModel.insertMessage;
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }  
        private clsApplicationEditReason ValidateData(clsApplicationEditReason value)
        {
            //Add Logic For Insert And Update
            clsApplicationEditReason obj = new clsApplicationEditReason();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
                value.editDate = DateTime.Now;
            }
            else
            {
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
                value.editDate = DateTime.Now;
            }
            obj = value;
            return obj;
        }
    }
}
