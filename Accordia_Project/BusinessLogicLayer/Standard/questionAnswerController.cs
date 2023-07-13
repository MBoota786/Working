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
    public class questionAnswerController : ControllerBase
    {
        questionAnswerDAL _activeDAL = new questionAnswerDAL();
      
        [HttpGet]
        public List<clsQuestionAnswer> Get(string dbName)
        {
            List<clsQuestionAnswer> offList = _activeDAL.SelectAllQuestionAnswer(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsQuestionAnswer Get(int id, string dbName)
        {
            clsQuestionAnswer off = _activeDAL.SelectQuestionAnswerById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsQuestionAnswer value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuestionAnswer(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuestionAnswer(ValidateData(value));
                return "Insert";
            }
        }

        private clsQuestionAnswer ValidateData(clsQuestionAnswer value)
        {
            //Add Logic For Insert And Update
            clsQuestionAnswer obj = new clsQuestionAnswer();
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
