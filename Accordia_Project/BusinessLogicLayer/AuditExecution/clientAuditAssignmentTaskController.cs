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
    public class clientAuditAssignmentTaskController : ControllerBase
    {
        clientAuditAssignmentTaskDAL _activeDAL = new clientAuditAssignmentTaskDAL();
      
        [HttpGet]
        public List<clsClientAuditAssignmentTask> Get(string dbName)
        {
            List<clsClientAuditAssignmentTask> offList = _activeDAL.SelectAllClientAuditAssignmentTask(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAuditAssignmentTask Get(int id,string dbName)
        {
            clsClientAuditAssignmentTask off = _activeDAL.SelectClientAuditAssignmentTaskById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAuditAssignmentTask value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAuditAssignmentTask(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAuditAssignmentTask(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAuditAssignmentTask ValidateData(clsClientAuditAssignmentTask value)
        {
            //Add Logic For Insert And Update
            clsClientAuditAssignmentTask obj = new clsClientAuditAssignmentTask();
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
