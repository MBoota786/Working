using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class contactTypeController : ControllerBase
    {
        contactTypeDAL _activeDAL = new contactTypeDAL();
        // GET: api/<contactTypeController>
        [HttpGet]
        public List<clsContactType> Get(string dbName)
        {
            List<clsContactType> offList = _activeDAL.SelectAllContactType(dbName);
            return offList;
        }

        // GET api/<contactTypeController>/5
        [HttpGet("{id}")]
        public clsContactType Get(int id, string dbName)
        {
            clsContactType off = _activeDAL.SelectContactTypeById(id,dbName).FirstOrDefault();
            return off;
        }

        // POST api/<contactTypeController>
        [HttpPost]
        public string Post([FromBody] clsContactType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateContactType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertContactType(ValidateData(value));
                return "Insert";
            }
        }

 
        private clsContactType ValidateData(clsContactType value)
        {
            //Add Logic For Insert And Update
            clsContactType obj = new clsContactType();
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
