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
    public class clientAppAuditTeamController : ControllerBase
    {
        clientAppAuditTeamDAL _activeDAL = new clientAppAuditTeamDAL();
      
        [HttpGet]
        public List<clsClientAppAuditTeam> Get(string dbName)
        {
            List<clsClientAppAuditTeam> offList = _activeDAL.SelectAllClientAppAuditTeam(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAppAuditTeam Get(int id,string dbName)
        {
            clsClientAppAuditTeam off = _activeDAL.SelectClientAppAuditTeamById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAppAuditTeam value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAppAuditTeam(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAppAuditTeam(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAppAuditTeam ValidateData(clsClientAppAuditTeam value)
        {
            //Add Logic For Insert And Update
            clsClientAppAuditTeam obj = new clsClientAppAuditTeam();
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
