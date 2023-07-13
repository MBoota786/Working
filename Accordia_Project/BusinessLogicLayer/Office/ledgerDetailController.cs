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
    public class ledgerDetailController : ControllerBase
    {
        ledgerDetailDAL _activeDAL = new ledgerDetailDAL();
      
        [HttpGet]
        public List<clsLedgerDetail> Get(string dbName)
        {
            List<clsLedgerDetail> offList = _activeDAL.SelectAllLedgerDetail(dbName);
            return offList;
        }

        [HttpGet("{id}")]
        public clsLedgerDetail Get(int id, string dbName)
        {
            clsLedgerDetail off = _activeDAL.SelectLedgerDetailById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsLedgerDetail value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateLedgerDetail(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertLedgerDetail(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsLedgerDetail ValidateData(clsLedgerDetail value)
        {
            //Add Logic For Insert And Update
            clsLedgerDetail obj = new clsLedgerDetail();
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
