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
    public class clientAuditTaskCheckListController : ControllerBase
    {
        clientAuditTaskCheckListDAL _activeDAL = new clientAuditTaskCheckListDAL();
      
        [HttpGet]
        public List<clsClientAuditTaskCheckList> Get(string dbName)
        {
            List<clsClientAuditTaskCheckList> offList = _activeDAL.SelectAllClientAuditTaskCheckList(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAuditTaskCheckList Get(int id,string dbName)
        {
            clsClientAuditTaskCheckList off = _activeDAL.SelectClientAuditTaskCheckListById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAuditTaskCheckList value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAuditCheckList(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAuditCheckList(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAuditTaskCheckList ValidateData(clsClientAuditTaskCheckList value)
        {
            //Add Logic For Insert And Update
            clsClientAuditTaskCheckList obj = new clsClientAuditTaskCheckList();
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
