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
    public class quotationStatusController : ControllerBase
    {
        quotationStatusDAL _activeDAL = new quotationStatusDAL();
      
        [HttpGet]
        public List<clsQuotationStatus> Get(string dbName)
        {
            List<clsQuotationStatus> offList = _activeDAL.SelectAllQuotation(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsQuotationStatus Get(int id, string dbName)
        {
            clsQuotationStatus off = _activeDAL.SelectQuotationStatusById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsQuotationStatus value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuotationStatus(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuotationStatus(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsQuotationStatus ValidateData(clsQuotationStatus value)
        {
            //Add Logic For Insert And Update
            clsQuotationStatus obj = new clsQuotationStatus();
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
