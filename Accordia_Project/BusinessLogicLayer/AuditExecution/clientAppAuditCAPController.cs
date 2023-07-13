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
    public class clientAppAuditCAPController : ControllerBase
    {
        clientAppAuditCAPDAL _activeDAL = new clientAppAuditCAPDAL();
      
        [HttpGet]
        public List<clsClientAppAuditCAP> Get(string dbName)
        {
            List<clsClientAppAuditCAP> offList = _activeDAL.SelectAllClientAppAuditCAP(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAppAuditCAP Get(int id,string dbName)
        {
            clsClientAppAuditCAP off = _activeDAL.SelectClientAppAuditCAPById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAppAuditCAP value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAppAuditCAP(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAppAuditCAP(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAppAuditCAP ValidateData(clsClientAppAuditCAP value)
        {
            //Add Logic For Insert And Update
            clsClientAppAuditCAP obj = new clsClientAppAuditCAP();
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
