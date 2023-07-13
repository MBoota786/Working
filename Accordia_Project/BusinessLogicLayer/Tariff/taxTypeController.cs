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
    public class taxTypeController : ControllerBase
    {
        taxTypeDAL _activeDAL = new taxTypeDAL();
      
        [HttpGet]
        public List<clsTaxType> Get(string dbName)
        {
            List<clsTaxType> offList = _activeDAL.SelectAllTaxType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsTaxType Get(int id, string dbName)
        {
            clsTaxType off = _activeDAL.SelectTaxTypeById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsTaxType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateTaxType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertTaxType(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsTaxType ValidateData(clsTaxType value)
        {
            //Add Logic For Insert And Update
            clsTaxType obj = new clsTaxType();
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
