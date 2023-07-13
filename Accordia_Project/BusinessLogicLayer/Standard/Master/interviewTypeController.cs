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
    public class interviewTypeController : ControllerBase
    {
        interviewTypeDAL _activeDAL = new interviewTypeDAL();
      
        [HttpGet]
        public List<clsInterviewType> Get(string dbName)
        {
            List<clsInterviewType> offList = _activeDAL.SelectAllInterviewType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsInterviewType Get(int id, string dbName)
        {
            clsInterviewType off = _activeDAL.SelectInterviewTypeById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsInterviewType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateInterviewType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertInterviewType(ValidateData(value));
                return "Insert";
            }
        }

        private clsInterviewType ValidateData(clsInterviewType value)
        {
            //Add Logic For Insert And Update
            clsInterviewType obj = new clsInterviewType();
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
