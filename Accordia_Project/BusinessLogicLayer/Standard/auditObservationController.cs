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
    public class auditObservationController : ControllerBase
    {
        auditObservationDAL _activeDAL = new auditObservationDAL();
      
        [HttpGet]
        public List<clsAuditObservation> Get(string dbName)
        {
            List<clsAuditObservation> offList = _activeDAL.SelectAllAuditObservation(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditObservation Get(int id, string dbName)
        {
            clsAuditObservation off = _activeDAL.SelectAuditObservationById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditObservation value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditObservation(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditObservation(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditObservation ValidateData(clsAuditObservation value)
        {
            //Add Logic For Insert And Update
            clsAuditObservation obj = new clsAuditObservation();
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
