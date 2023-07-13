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
    public class clientAppAuditAssignmentDocumentMasterController : ControllerBase
    {
        clientAppAuditAssignmentDocumentMasterDAL _activeDAL = new clientAppAuditAssignmentDocumentMasterDAL();
      
        [HttpGet]
        public List<clsClientAppAuditAssignmentDocumentMaster> Get(string dbName)
        {
            List<clsClientAppAuditAssignmentDocumentMaster> offList = _activeDAL.SelectAllClientAppAuditAssignmentDocumentMaster(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAppAuditAssignmentDocumentMaster Get(int id,string dbName)
        {
            clsClientAppAuditAssignmentDocumentMaster off = _activeDAL.SelectClientAppAuditAssignmentDocumentMasterById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAppAuditAssignmentDocumentMaster value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAppAuditAssignmentDocumentMaster(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAppAuditAssignmentDocumentMaster(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAppAuditAssignmentDocumentMaster ValidateData(clsClientAppAuditAssignmentDocumentMaster value)
        {
            //Add Logic For Insert And Update
            clsClientAppAuditAssignmentDocumentMaster obj = new clsClientAppAuditAssignmentDocumentMaster();
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
