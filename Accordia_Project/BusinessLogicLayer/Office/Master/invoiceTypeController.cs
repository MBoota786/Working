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
    public class invoiceTypeController : ControllerBase
    {
        invoiceTypeDAL _activeDAL = new invoiceTypeDAL();
      
        [HttpGet]
        public List<clsInvoiceType> Get(string dbName)
        {
            List<clsInvoiceType> offList = _activeDAL.SelectAllInvoiceType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsInvoiceType Get(int id, string dbName)
        {
            clsInvoiceType off = _activeDAL.spSelectInvoiceTypeById(id, dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsInvoiceType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateInvoiceType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertInvoiceType(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsInvoiceType ValidateData(clsInvoiceType value)
        {
            //Add Logic For Insert And Update
            clsInvoiceType obj = new clsInvoiceType();
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
