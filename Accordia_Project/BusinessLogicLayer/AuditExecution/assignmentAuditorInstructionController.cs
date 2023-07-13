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
    public class assignmentAuditorInstructionController : ControllerBase
    {
        assignmentAuditorInstructionDAL _activeDAL = new assignmentAuditorInstructionDAL();
      
        [HttpGet]
        public List<clsAssignmentAuditorInstruction> Get(string dbName)
        {
            List<clsAssignmentAuditorInstruction> offList = _activeDAL.SelectAllAssignmentAuditorInstruction(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAssignmentAuditorInstruction Get(int id,string dbName)
        {
            clsAssignmentAuditorInstruction off = _activeDAL.SelectAssignmentAuditorInstructionById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAssignmentAuditorInstruction value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAssignmentAuditorInstruction(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAssignmentAuditorInstruction(ValidateData(value));
                return "Insert";
            }
        }

        private clsAssignmentAuditorInstruction ValidateData(clsAssignmentAuditorInstruction value)
        {
            //Add Logic For Insert And Update
            clsAssignmentAuditorInstruction obj = new clsAssignmentAuditorInstruction();
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
