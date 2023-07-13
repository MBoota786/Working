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
    public class clientAuditTaskPreRequisitsController : ControllerBase
    {
        clientAuditTaskPreRequisitsDAL _activeDAL = new clientAuditTaskPreRequisitsDAL();
      
        [HttpGet]
        public List<clsClientAuditTaskPreRequisits> Get(string dbName)
        {
            List<clsClientAuditTaskPreRequisits> offList = _activeDAL.SelectAllClientAuditTaskPreRequisits(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAuditTaskPreRequisits Get(int id,string dbName)
        {
            clsClientAuditTaskPreRequisits off = _activeDAL.SelectClientAuditTaskPreRequisitsById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAuditTaskPreRequisits value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAuditTaskPreRequisits(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAuditTaskPreRequisits(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAuditTaskPreRequisits ValidateData(clsClientAuditTaskPreRequisits value)
        {
            //Add Logic For Insert And Update
            clsClientAuditTaskPreRequisits obj = new clsClientAuditTaskPreRequisits();
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
