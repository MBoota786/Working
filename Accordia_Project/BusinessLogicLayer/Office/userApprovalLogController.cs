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
    public class userApprovalLogController : ControllerBase
    {
        userApprovalLogDAL _activeDAL = new userApprovalLogDAL();
      
        [HttpGet]
        public List<clsUserApprovalLog> Get()
        {
            List<clsUserApprovalLog> offList = _activeDAL.SelectAllUserApprovalLog();
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsUserApprovalLog Get(int id)
        {
            clsUserApprovalLog off = _activeDAL.SelectUserApprovalLogById(id).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsUserApprovalLog value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateUserApprovalLog(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertUserApprovalLog(ValidateData(value));
                return "Insert";
            }
        }

        private clsUserApprovalLog ValidateData(clsUserApprovalLog value)
        {
            //Add Logic For Insert And Update
            clsUserApprovalLog obj = new clsUserApprovalLog();
            if (value.id > 0)
            {
               // On Update Logic
            }
            else
            {
               // On Insert Logic
            }
            obj = value;
            return obj;
        }
    }
}
