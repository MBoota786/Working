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
    public class bankAdditionalDetailsController : ControllerBase
    {
        bankAdditionalDetailsDAL _activeDAL = new bankAdditionalDetailsDAL();
      
        [HttpGet]
        public List<clsBankAdditionalDetails> Get(string dbName)
        {
            List<clsBankAdditionalDetails> offList = _activeDAL.SelectAllBankAdditionalDetails(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsBankAdditionalDetails Get(int id, string dbName)
        {
            clsBankAdditionalDetails off = _activeDAL.SelectBankAdditionalDetailsById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsBankAdditionalDetails value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdatebankAdditionalDetails(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertbankAdditionalDetails(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsBankAdditionalDetails ValidateData(clsBankAdditionalDetails value)
        {
            //Add Logic For Insert And Update
            clsBankAdditionalDetails obj = new clsBankAdditionalDetails();
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
