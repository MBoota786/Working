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
    public class questionTypeController : ControllerBase
    {
        questionTypeDAL _activeDAL = new questionTypeDAL();
      
        [HttpGet]
        public List<clsQuestionType> Get(string dbName)
        {
            List<clsQuestionType> offList = _activeDAL.SelectAllQuestionType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsQuestionType Get(int id,string dbName)
        {
            clsQuestionType off = _activeDAL.SelectQuestionTypeById(id,dbName).FirstOrDefault();
            return off;
        }
      
        [HttpPost]
        public string Post([FromBody] clsQuestionType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuestionType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuestionType(ValidateData(value));
                return "Insert";
            }
        }

        private clsQuestionType ValidateData(clsQuestionType value)
        {
            //Add Logic For Insert And Update
            clsQuestionType obj = new clsQuestionType();
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
