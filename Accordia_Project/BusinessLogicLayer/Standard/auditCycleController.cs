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
    public class auditCycleController : ControllerBase
    {
        auditCycleDAL _activeDAL = new auditCycleDAL();
      
        [HttpGet]
        public List<clsAuditCycle> Get(string dbName)
        {
            List<clsAuditCycle> offList = _activeDAL.SelectAllAuditCycle(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditCycle Get(int id, string dbName)
        {
            clsAuditCycle off = _activeDAL.SelectAuditCycleById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditCycle value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditCycle(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditCycle(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditCycle ValidateData(clsAuditCycle value)
        {
            //Add Logic For Insert And Update
            clsAuditCycle obj = new clsAuditCycle();
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
