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
    public class questionEffectController : ControllerBase
    {
        questionEffectDAL _activeDAL = new questionEffectDAL();
      
        [HttpGet]
        public List<clsQuestionEffect> Get(string dbName)
        {
            List<clsQuestionEffect> offList = _activeDAL.SelectAllQuestionEffect(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsQuestionEffect Get(int id,string dbName)
        {
            clsQuestionEffect off = _activeDAL.SelectQuestionEffectById(id,dbName).FirstOrDefault();
            return off;
        }
      
        [HttpPost]
        public string Post([FromBody] clsQuestionEffect value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuestionEffect(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuestionEffect(ValidateData(value));
                return "Insert";
            }
        }

        private clsQuestionEffect ValidateData(clsQuestionEffect value)
        {
            //Add Logic For Insert And Update
            clsQuestionEffect obj = new clsQuestionEffect();
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
