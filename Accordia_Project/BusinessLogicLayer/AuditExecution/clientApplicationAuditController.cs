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
    public class clientApplicationAuditController : ControllerBase
    {
        clientApplicationAuditDAL _activeDAL = new clientApplicationAuditDAL();
      
        [HttpGet]
        public List<clsClientApplicationAudit> Get(string dbName)
        {
            List<clsClientApplicationAudit> offList = _activeDAL.SelectAllClientApplicationAudit(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientApplicationAudit Get(int id,string dbName)
        {
            clsClientApplicationAudit off = _activeDAL.SelectClientApplicationAuditById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientApplicationAudit value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientApplicationAudit(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientApplicationAudit(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientApplicationAudit ValidateData(clsClientApplicationAudit value)
        {
            //Add Logic For Insert And Update
            clsClientApplicationAudit obj = new clsClientApplicationAudit();
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
