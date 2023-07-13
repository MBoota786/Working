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
    public class invoiceLedgerController : ControllerBase
    {
        invoiceLedgerDAL _activeDAL = new invoiceLedgerDAL();
      
        [HttpGet()]
        public List<clsInvoiceLedger> Get(string dbName)
        {
            List<clsInvoiceLedger> offList = _activeDAL.SelectAllInvoiceLedger(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsInvoiceLedger Get(int id, string dbName)
        {
            clsInvoiceLedger off = _activeDAL.SelectInvoiceLedgerById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsInvoiceLedger value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateInvoiceLedger(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertInvoiceLedger(ValidateData(value));
                return "Insert";
            }
        }

        private clsInvoiceLedger ValidateData(clsInvoiceLedger value)
        {
            //Add Logic For Insert And Update
            clsInvoiceLedger obj = new clsInvoiceLedger();
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
