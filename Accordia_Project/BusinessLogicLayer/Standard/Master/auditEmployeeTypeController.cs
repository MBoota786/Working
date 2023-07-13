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
    public class auditEmployeeTypeController : ControllerBase
    {
        auditEmployeeTypeDAL _activeDAL = new auditEmployeeTypeDAL();
      
        [HttpGet]
        public List<clsAuditEmployeeType> Get(string dbName)
        {
            List<clsAuditEmployeeType> offList = _activeDAL.SelectAllAuditEmployeeType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditEmployeeType Get(int id, string dbName)
        {
            clsAuditEmployeeType off = _activeDAL.SelectAuditEmployeeTypeById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditEmployeeType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditEmployeeType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditEmployeeType(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditEmployeeType ValidateData(clsAuditEmployeeType value)
        {
            //Add Logic For Insert And Update
            clsAuditEmployeeType obj = new clsAuditEmployeeType();
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
