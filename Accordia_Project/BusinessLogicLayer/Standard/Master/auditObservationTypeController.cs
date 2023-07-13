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
    public class auditObservationTypeController : ControllerBase
    {
        auditObservationTypeDAL _activeDAL = new auditObservationTypeDAL();
      
        [HttpGet]
        public List<clsAuditObservationType> Get(string dbName)
        {
            List<clsAuditObservationType> offList = _activeDAL.SelectAllAuditObservationType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditObservationType Get(int id, string dbName)
        {
            clsAuditObservationType off = _activeDAL.SelectAuditObservationTypeById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditObservationType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditObservationType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditObservationType(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditObservationType ValidateData(clsAuditObservationType value)
        {
            //Add Logic For Insert And Update
            clsAuditObservationType obj = new clsAuditObservationType();
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
