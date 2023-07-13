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
    public class clientAppAuditNcsController : ControllerBase
    {
        clientAppAuditNcsDAL _activeDAL = new clientAppAuditNcsDAL();
      
        [HttpGet]
        public List<clsClientAppAuditNcs> Get(string dbName)
        {
            List<clsClientAppAuditNcs> offList = _activeDAL.SelectAllClientAppAuditNcs(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAppAuditNcs Get(int id,string dbName)
        {
            clsClientAppAuditNcs off = _activeDAL.SelectClientAppAuditNcsById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAppAuditNcs value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAppAuditNcs(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAppAuditNcs(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAppAuditNcs ValidateData(clsClientAppAuditNcs value)
        {
            //Add Logic For Insert And Update
            clsClientAppAuditNcs obj = new clsClientAppAuditNcs();
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
