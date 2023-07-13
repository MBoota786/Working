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
    public class employeeBreakDownDtlController : ControllerBase
    {
        employeeBreakDownDtlDAL _activeDAL = new employeeBreakDownDtlDAL();
      
        [HttpGet]
        public List<clsEmployeeBreakDownDtl> Get(string dbName)
        {
            List<clsEmployeeBreakDownDtl> offList = _activeDAL.SelectAllEmployeeBreakDownDtl(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsEmployeeBreakDownDtl Get(int id, string dbName)
        {
            clsEmployeeBreakDownDtl off = _activeDAL.SelectEmployeeBreakDownDtlById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsEmployeeBreakDownDtl value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateEmployeeBreakDownDtl(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertEmployeeBreakDownDtl(ValidateData(value));
                return "Insert";
            } 
        }

        private clsEmployeeBreakDownDtl ValidateData(clsEmployeeBreakDownDtl value)
        {
            //Add Logic For Insert And Update
            clsEmployeeBreakDownDtl obj = new clsEmployeeBreakDownDtl();
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
