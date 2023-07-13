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
    public class auditDurationController : ControllerBase
    {
        auditDurationDAL _activeDAL = new auditDurationDAL();
      
        [HttpGet]
        public List<clsAuditDuration> Get(string dbName)
        {
            List<clsAuditDuration> offList = _activeDAL.SelectAllAuditDuration(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditDuration Get(int id, string dbName)
        {
            clsAuditDuration off = _activeDAL.SelectAuditDurationById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditDuration value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditDuration(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditDuration(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditDuration ValidateData(clsAuditDuration value)
        {
            //Add Logic For Insert And Update
            clsAuditDuration obj = new clsAuditDuration();
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
