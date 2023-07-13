using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class quotationVersionController : ControllerBase
    {
        quotationVersionDAL _activeDAL = new quotationVersionDAL();
      
        [HttpGet]
        public List<clsQuotationVersion> Get(string dbName)
        {
            List<clsQuotationVersion> offList = _activeDAL.SelectAllQuotationVersion(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsQuotationVersion Get(int id, string dbName)
        {
            clsQuotationVersion off = _activeDAL.SelectQuotationVersionById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsQuotationVersion value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuotationVersion(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuotationVersion(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsQuotationVersion ValidateData(clsQuotationVersion value)
        {
            //Add Logic For Insert And Update
            clsQuotationVersion obj = new clsQuotationVersion();
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
