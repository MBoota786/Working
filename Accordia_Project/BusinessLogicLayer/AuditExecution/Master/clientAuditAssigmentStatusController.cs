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
    public class clientAuditAssigmentStatusController : ControllerBase
    {
        clientAuditAssignmentStatusDAL _activeDAL = new clientAuditAssignmentStatusDAL();
      
        [HttpGet]
        public List<clsClientAuditAssignmentStatus> Get(string dbName)
        {
            List<clsClientAuditAssignmentStatus> offList = _activeDAL.SelectAllClientAuditAssignmentStatus(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAuditAssignmentStatus Get(int id,string dbName)
        {
            clsClientAuditAssignmentStatus off = _activeDAL.SelectClientAuditAssignmentStatusById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAuditAssignmentStatus value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAuditAssignmentStatus(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAuditAssignmentStatus(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAuditAssignmentStatus ValidateData(clsClientAuditAssignmentStatus value)
        {
            //Add Logic For Insert And Update
            clsClientAuditAssignmentStatus obj = new clsClientAuditAssignmentStatus();
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
