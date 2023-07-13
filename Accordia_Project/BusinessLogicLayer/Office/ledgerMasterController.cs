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
    public class ledgerMasterController : ControllerBase
    {
        ledgerMasterDAL _activeDAL = new ledgerMasterDAL();
      
        [HttpGet]
        public List<clsLedgerMaster> Get(string dbName)
        {
            List<clsLedgerMaster> offList = _activeDAL.SelectAllLedgerMaster(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsLedgerMaster Get(int id, string dbName)
        {
            clsLedgerMaster off = _activeDAL.SelectLedgerMasterById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsLedgerMaster value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateLedgerMaster(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertLedgerMaster(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsLedgerMaster ValidateData(clsLedgerMaster value)
        {
            //Add Logic For Insert And Update
            clsLedgerMaster obj = new clsLedgerMaster();
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
