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
    public class auditRequiredDocTypeController : ControllerBase
    {
        auditRequiredDocTypeDAL _activeDAL = new auditRequiredDocTypeDAL();
      
        [HttpGet]
        public List<clsAuditRequiredDocType> Get(string dbName)
        {
            List<clsAuditRequiredDocType> offList = _activeDAL.SelectAllAuditRequiredDocType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditRequiredDocType Get(int id, string dbName)
        {
            clsAuditRequiredDocType off = _activeDAL.SelectAuditRequiredDocTypeById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditRequiredDocType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditRequiredDocType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditRequiredDocType(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditRequiredDocType ValidateData(clsAuditRequiredDocType value)
        {
            //Add Logic For Insert And Update
            clsAuditRequiredDocType obj = new clsAuditRequiredDocType();
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
