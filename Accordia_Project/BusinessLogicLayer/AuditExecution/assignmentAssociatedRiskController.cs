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
    public class assignmentAssociatedRiskController : ControllerBase
    {
        assignmentAssociatedRiskDAL _activeDAL = new assignmentAssociatedRiskDAL();
      
        [HttpGet]
        public List<clsAssignmentAssociatedRisk> Get(string dbName)
        {
            List<clsAssignmentAssociatedRisk> offList = _activeDAL.SelectAllAssignmentAssociatedRisk(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsAssignmentAssociatedRisk Get(int id,string dbName)
        {
            clsAssignmentAssociatedRisk off = _activeDAL.SelectAssignmentAssociatedRiskById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsAssignmentAssociatedRisk value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAssignmentAssociatedRisk(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAssignmentAssociatedRisk(ValidateData(value));
                return "Insert";
            }
        }

        private clsAssignmentAssociatedRisk ValidateData(clsAssignmentAssociatedRisk value)
        {
            //Add Logic For Insert And Update
            clsAssignmentAssociatedRisk obj = new clsAssignmentAssociatedRisk();
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
