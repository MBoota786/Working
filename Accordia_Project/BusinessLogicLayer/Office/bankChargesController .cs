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
    public class bankChargesController : ControllerBase
    {
        bankChargesDAL _activeDAL = new bankChargesDAL();
      
        [HttpGet]
        public List<clsBankCharges> Get()
        {
            List<clsBankCharges> offList = _activeDAL.SelectAllBankCharges();
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsBankCharges Get(int id)
        {
            clsBankCharges off = _activeDAL.SelectBankChargesById(id).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsBankCharges value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateBankCharges(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertBankCharges(ValidateData(value));
                return "Insert";
            }
        }


        private clsBankCharges ValidateData(clsBankCharges value)
        {
            //Add Logic For Insert And Update
            clsBankCharges obj = new clsBankCharges();
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
