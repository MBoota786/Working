using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class auditStandardsController : ControllerBase
    {
        auditStandardsDAL _activeDAL = new auditStandardsDAL();
      
        [HttpGet]
        public List<clsAuditStandards> Get(string dbName)
        {
            List<clsAuditStandards> offList = _activeDAL.SelectAllAuditStandards(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditStandards Get(int id, string dbName)
        {
            clsAuditStandards off = _activeDAL.SelectAuditStandardsById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsAuditStandards value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditStandards(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditStandards(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditStandards ValidateData(clsAuditStandards value)
        {
            //Add Logic For Insert And Update
            clsAuditStandards obj = new clsAuditStandards();
            if (value.id > 0)
            {
               // On Update Logic
            }
            else
            {
               // On Insert Logic
            }
            obj = value;
            return obj;
        }
    }
}
