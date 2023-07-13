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
    public class auditRequiredDocDetailController : ControllerBase
    {
        auditRequiredDocDetailDAL _activeDAL = new auditRequiredDocDetailDAL();
      
        [HttpGet]
        public List<clsAuditRequiredDocDetail> Get(string dbName)
        {
            List<clsAuditRequiredDocDetail> offList = _activeDAL.SelectAllAuditRequiredDocDetail(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAuditRequiredDocDetail Get(int id, string dbName)
        {
            clsAuditRequiredDocDetail off = _activeDAL.SelectAuditRequiredDocDetailById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAuditRequiredDocDetail value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAuditRequiredDocDetail(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAuditRequiredDocDetail(ValidateData(value));
                return "Insert";
            }
        }

        private clsAuditRequiredDocDetail ValidateData(clsAuditRequiredDocDetail value)
        {
            //Add Logic For Insert And Update
            clsAuditRequiredDocDetail obj = new clsAuditRequiredDocDetail();
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
