using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class standardSetupController : ControllerBase
    {
        standardSetupDAL _activeDAL = new standardSetupDAL();
      
        [HttpGet]
        public List<clsStandardSetup> Get(string dbName)
        {
            List<clsStandardSetup> offList = _activeDAL.SelectAllStandardSetup(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsStandardSetup Get(int id, string dbName)
        {
            clsStandardSetup off = _activeDAL.SelectStandardSetupById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsStandardSetup value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateStandardSetup(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertStandardSetup(ValidateData(value));
                return "Insert";
            }
        }

        private clsStandardSetup ValidateData(clsStandardSetup value)
        {
            //Add Logic For Insert And Update
            clsStandardSetup obj = new clsStandardSetup();
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
