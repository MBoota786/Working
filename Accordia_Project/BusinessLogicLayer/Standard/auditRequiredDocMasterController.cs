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
    public class auditRequiredDocMasterController : ControllerBase
    {
        auditRequiredDocMasterDAL _activeDAL = new auditRequiredDocMasterDAL();
      
        [HttpGet]
        public List<clsAuditRequiredDocMaster> Get(string dbName)
        {
            List<clsAuditRequiredDocMaster> offList = _activeDAL.SelectAllAuditRequiredDocMaster(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditRequiredDocMaster Get(int id, string dbName)
        {
            clsAuditRequiredDocMaster off = _activeDAL.SelectAuditRequiredDocMasterById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditRequiredDocMaster value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditRequiredDocMaster(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditRequiredDocMaster(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditRequiredDocMaster ValidateData(clsAuditRequiredDocMaster value)
        {
            //Add Logic For Insert And Update
            clsAuditRequiredDocMaster obj = new clsAuditRequiredDocMaster();
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
