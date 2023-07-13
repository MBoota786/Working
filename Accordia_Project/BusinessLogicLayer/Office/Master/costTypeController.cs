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
    public class costTypeController : ControllerBase
    {
        costTypeDAL _activeDAL = new costTypeDAL();
      
        [HttpGet]
        public List<clsCostType> Get(string dbName)
        {
            List<clsCostType> offList = _activeDAL.SelectAllCostType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsCostType Get(int id, string dbName)
        {
            clsCostType off = _activeDAL.SelectCostTypeById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsCostType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCostType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCostType(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsCostType ValidateData(clsCostType value)
        {
            //Add Logic For Insert And Update
            clsCostType obj = new clsCostType();
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
