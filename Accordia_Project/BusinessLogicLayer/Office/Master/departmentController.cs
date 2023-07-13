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
    public class departmentController : ControllerBase
    {
        departmentDAL _activeDAL = new departmentDAL();
      
        [HttpGet]
        public List<clsDepartment> Get(string dbName)
        {
            List<clsDepartment> offList = _activeDAL.SelectAllDepartment(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsDepartment Get(int id, string dbName)
        {
            clsDepartment off = _activeDAL.SelectDepartmentById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsDepartment value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateDepartment(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertDepartment(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsDepartment ValidateData(clsDepartment value)
        {
            //Add Logic For Insert And Update
            clsDepartment obj = new clsDepartment();
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
