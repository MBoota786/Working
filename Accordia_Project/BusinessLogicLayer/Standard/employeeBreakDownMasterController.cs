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
    public class employeeBreakDownMasterController : ControllerBase
    {
        employeeBreakDownMasterDAL _activeDAL = new employeeBreakDownMasterDAL();
      
        [HttpGet]
        public List<clsEmployeeBreakDownMaster> Get(string dbName)
        {
            List<clsEmployeeBreakDownMaster> offList = _activeDAL.SelectAllEmployeeBreakDownMaster(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsEmployeeBreakDownMaster Get(int id, string dbName)
        {
            clsEmployeeBreakDownMaster off = _activeDAL.SelectEmployeeBreakDownMasterById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsEmployeeBreakDownMaster value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateEmployeeBreakDownMaster(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertEmployeeBreakDownMaster(ValidateData(value));
                return "Insert";
            }
        }

        private clsEmployeeBreakDownMaster ValidateData(clsEmployeeBreakDownMaster value)
        {
            //Add Logic For Insert And Update
            clsEmployeeBreakDownMaster obj = new clsEmployeeBreakDownMaster();
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
