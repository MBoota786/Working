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
    public class auditDeliverableDocumentController : ControllerBase
    {
        auditDeliverableDocumentDAL _activeDAL = new auditDeliverableDocumentDAL();
      
        [HttpGet]
        public List<clsAuditDeliverableDocument> Get(string dbName)
        {
            List<clsAuditDeliverableDocument> offList = _activeDAL.SelectAllAuditDeliverableDocument(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditDeliverableDocument Get(int id, string dbName)
        {
            clsAuditDeliverableDocument off = _activeDAL.SelectAuditDeliverableDocumentById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpGet("GetByAccreditationStandardId/{accreditationStandardId}")]
        public List<clsAuditDeliverableDocument> GetByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            List<clsAuditDeliverableDocument> offList = _activeDAL.SelectAuditDeliverableDocumentByAccreditationStandardId(accreditationStandardId, dbName);
            return offList;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditDeliverableDocument value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditDeliverableDocument(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditDeliverableDocument(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditDeliverableDocument ValidateData(clsAuditDeliverableDocument value)
        {
            //Add Logic For Insert And Update
            clsAuditDeliverableDocument obj = new clsAuditDeliverableDocument();
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
