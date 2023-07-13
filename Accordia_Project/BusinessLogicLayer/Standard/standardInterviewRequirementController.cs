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
    public class standardInterviewRequirementController : ControllerBase
    {
        standardInterviewRequirementDAL _activeDAL = new standardInterviewRequirementDAL();
      
        [HttpGet]
        public List<clsStandardInterviewRequirement> Get(string dbName)
        {
            List<clsStandardInterviewRequirement> offList = _activeDAL.SelectAllStandardInterviewRequirement(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsStandardInterviewRequirement Get(int id, string dbName)
        {
            clsStandardInterviewRequirement off = _activeDAL.SelectStandardInterviewRequirementById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsStandardInterviewRequirement value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateStandardInterviewRequirement(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertStandardInterviewRequirement(ValidateData(value));
                return "Insert";
            }
        }

        private clsStandardInterviewRequirement ValidateData(clsStandardInterviewRequirement value)
        {
            //Add Logic For Insert And Update
            clsStandardInterviewRequirement obj = new clsStandardInterviewRequirement();
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
