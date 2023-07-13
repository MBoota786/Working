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
    public class auditClausesController : ControllerBase
    {
        auditClausesDAL _activeDAL = new auditClausesDAL();
      
        [HttpGet]
        public List<clsAuditClauses> Get(string dbName)
        {
            List<clsAuditClauses> offList = _activeDAL.SelectAllAuditClause(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditClauses Get(int id, string dbName)
        {
            clsAuditClauses off = _activeDAL.SelectAuditClauseById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditClauses value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditClauses(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditClauses(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditClauses ValidateData(clsAuditClauses value)
        {
            //Add Logic For Insert And Update
            clsAuditClauses obj = new clsAuditClauses();
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
