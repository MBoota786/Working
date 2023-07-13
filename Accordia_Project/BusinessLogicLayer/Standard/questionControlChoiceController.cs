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
    public class questionControlChoiceController : ControllerBase
    {
        questionControlChoiceDAL _activeDAL = new questionControlChoiceDAL();
      
        [HttpGet]
        public List<clsQuestionControlChoice> Get(string dbName)
        {
            List<clsQuestionControlChoice> offList = _activeDAL.SelectAllQuestionControlChoice(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsQuestionControlChoice Get(int id, string dbName)
        {
            clsQuestionControlChoice off = _activeDAL.SelectQuestionControlChoiceById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsQuestionControlChoice value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuestionControlChoice(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuestionControlChoice(ValidateData(value));
                return "Insert";
            }
        }

        private clsQuestionControlChoice ValidateData(clsQuestionControlChoice value)
        {
            //Add Logic For Insert And Update
            clsQuestionControlChoice obj = new clsQuestionControlChoice();
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
