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
    public class auditTypeController : ControllerBase
    {
        auditTypeDAL _activeDAL = new auditTypeDAL();
      
        [HttpGet]
        public List<clsAuditType> Get(string dbName)
        {
            List<clsAuditType> offList = _activeDAL.SelectAllAuditType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditType Get(int id, string dbName)
        {
            clsAuditType off = _activeDAL.SelectAuditTypeById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditType(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditType ValidateData(clsAuditType value)
        {
            //Add Logic For Insert And Update
            clsAuditType obj = new clsAuditType();
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
