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
    public class clientAuditTaskRequiredDocController : ControllerBase
    {
        clientAuditTaskRequiredDocDAL _activeDAL = new clientAuditTaskRequiredDocDAL();
      
        [HttpGet]
        public List<clsClientAuditTaskRequiredDoc> Get(string dbName)
        {
            List<clsClientAuditTaskRequiredDoc> offList = _activeDAL.SelectAllClientAuditTaskRequiredDoc(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClientAuditTaskRequiredDoc Get(int id,string dbName)
        {
            clsClientAuditTaskRequiredDoc off = _activeDAL.SelectClientAuditTaskRequiredDocById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClientAuditTaskRequiredDoc value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClientAuditTaskRequiredDoc(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClientAuditTaskRequiredDoc(ValidateData(value));
                return "Insert";
            }
        }

        private clsClientAuditTaskRequiredDoc ValidateData(clsClientAuditTaskRequiredDoc value)
        {
            //Add Logic For Insert And Update
            clsClientAuditTaskRequiredDoc obj = new clsClientAuditTaskRequiredDoc();
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
