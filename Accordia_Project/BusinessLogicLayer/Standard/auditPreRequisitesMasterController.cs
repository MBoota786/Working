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
    public class auditPreRequisitesMasterController : ControllerBase
    {
        auditPreRequisitesMasterDAL _activeDAL = new auditPreRequisitesMasterDAL();
      
        [HttpGet]
        public List<clsAuditPreRequisitesMaster> Get(string dbName)
        {
            List<clsAuditPreRequisitesMaster> offList = _activeDAL.SelectAllAuditPreRequisitesMaster(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditPreRequisitesMaster Get(int id, string dbName)
        {
            clsAuditPreRequisitesMaster off = _activeDAL.SelectAuditPreRequisitesMasterById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditPreRequisitesMaster value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditPreRequisitesMaster(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditPreRequisitesMaster(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditPreRequisitesMaster ValidateData(clsAuditPreRequisitesMaster value)
        {
            //Add Logic For Insert And Update
            clsAuditPreRequisitesMaster obj = new clsAuditPreRequisitesMaster();
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
