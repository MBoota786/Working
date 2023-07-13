using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class emailTypeController : ControllerBase
    {
        emailTypeDAL _activeDAL = new emailTypeDAL();
        // GET: api/<designationController>
        [HttpGet]
        public List<clsEmailTypes> Get(string dbName)
        {
            List<clsEmailTypes> offList = _activeDAL.SelectAllEmailType(dbName);
            return offList;
        }

        // GET api/<designationController>/5
        [HttpGet("{id}")]
        public clsEmailTypes Get(int id, string dbName)
        {
            clsEmailTypes obj = _activeDAL.SelectEmailTypeById(id, dbName).FirstOrDefault();
            return obj;
        }

        // POST api/<designationController>
        [HttpPost]
        public string Post([FromBody] clsEmailTypes value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateEmailType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertEmailType(ValidateData(value));
                return "Insert";
            }
        }


        private clsEmailTypes ValidateData(clsEmailTypes value)
        {
            //Add Logic For Insert And Update
            clsEmailTypes obj = new clsEmailTypes();
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
