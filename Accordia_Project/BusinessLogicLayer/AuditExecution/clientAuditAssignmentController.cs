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
    public class clientAuditAssignmentController : ControllerBase
    {
        clientAuditAssignmentDAL _activeDAL = new clientAuditAssignmentDAL();
      
        [HttpGet]
        public List<clsClientAuditAssignment> Get(string dbName)
        {
            List<clsClientAuditAssignment> offList = _activeDAL.SelectAllClientAuditAssignment(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAuditAssignment Get(int id,string dbName)
        {
            clsClientAuditAssignment off = _activeDAL.SelectClientAuditAssignmentById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAuditAssignment value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAuditAssignment(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAuditAssignment(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAuditAssignment ValidateData(clsClientAuditAssignment value)
        {
            //Add Logic For Insert And Update
            clsClientAuditAssignment obj = new clsClientAuditAssignment();
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
