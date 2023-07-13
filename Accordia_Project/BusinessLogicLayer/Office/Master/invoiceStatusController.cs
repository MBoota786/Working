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
    public class invoiceStatusController : ControllerBase
    {
        invoiceStatusDAL _activeDAL = new invoiceStatusDAL();
      
        [HttpGet]
        public List<clsInvoiceStatus> Get(string dbName)
        {
            List<clsInvoiceStatus> offList = _activeDAL.SelectAllInvoiceStatus(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsInvoiceStatus Get(int id, string dbName)
        {
            clsInvoiceStatus off = _activeDAL.spSelectInvoiceStatusById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsInvoiceStatus value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateInvoiceStatus(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertInvoiceStatus(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsInvoiceStatus ValidateData(clsInvoiceStatus value)
        {
            //Add Logic For Insert And Update
            clsInvoiceStatus obj = new clsInvoiceStatus();
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
