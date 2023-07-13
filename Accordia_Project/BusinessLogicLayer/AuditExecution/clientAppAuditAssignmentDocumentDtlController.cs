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
    public class clientAppAuditAssignmentDocumentDtlController : ControllerBase
    {
        clientAppAuditAssignmentDocumentDtlDAL _activeDAL = new clientAppAuditAssignmentDocumentDtlDAL();
      
        [HttpGet]
        public List<clsClientAppAuditAssignmentDocumentDtl> Get(string dbName)
        {
            List<clsClientAppAuditAssignmentDocumentDtl> offList = _activeDAL.SelectAllClientAppAuditAssignmentDocumentDtl(dbName);
            return offList;
        }

        [HttpGet("{id}")]
        public clsClientAppAuditAssignmentDocumentDtl Get(int id,string dbName)
        {
            clsClientAppAuditAssignmentDocumentDtl off = _activeDAL.SelectClientAppAuditAssignmentDocumentDtlById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAppAuditAssignmentDocumentDtl value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAppAuditAssignmentDocumentDtl(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAppAuditAssignmentDocumentDtl(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAppAuditAssignmentDocumentDtl ValidateData(clsClientAppAuditAssignmentDocumentDtl value)
        {
            //Add Logic For Insert And Update
            clsClientAppAuditAssignmentDocumentDtl obj = new clsClientAppAuditAssignmentDocumentDtl();
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
