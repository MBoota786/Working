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
    public class auditPreRequisitesDetailController : ControllerBase
    {
        auditPreRequisitesDetailDAL _activeDAL = new auditPreRequisitesDetailDAL();
      
        [HttpGet]
        public List<clsAuditPreRequisitesDetail> Get(string dbName)
        {
            List<clsAuditPreRequisitesDetail> offList = _activeDAL.SelectAllAuditPreRequisitesDetail(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditPreRequisitesDetail Get(int id, string dbName)
        {
            clsAuditPreRequisitesDetail off = _activeDAL.SelectAuditPreRequisitesDetailById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditPreRequisitesDetail value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditPreRequisitesDetail(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditPreRequisitesDetail(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditPreRequisitesDetail ValidateData(clsAuditPreRequisitesDetail value)
        {
            //Add Logic For Insert And Update
            clsAuditPreRequisitesDetail obj = new clsAuditPreRequisitesDetail();
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
