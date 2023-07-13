using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class adressTypeController : ControllerBase
    {
        adressTypeDAL _activeDAL = new adressTypeDAL();
        // GET: api/<adressTypeController>
        [HttpGet]
        public List<clsAdressType> Get(string dbName)
        {
            List<clsAdressType> offList = _activeDAL.SelectAllAdressType(dbName);
            return offList;
        }

        // GET api/<adressTypeController>/5
        [HttpGet("{id}")]
        public clsAdressType Get(int id, string dbName)
        {
            clsAdressType off = _activeDAL.SelectAdressTypeById(id,dbName).FirstOrDefault();
            return off;
        }

        // POST api/<adressTypeController>
        [HttpPost]
        public string Post([FromBody] clsAdressType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateAdressType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertAdressType(ValidateData(value));
                return "Insert";
            }
        }

        private clsAdressType ValidateData(clsAdressType value)
        {
            //Add Logic For Insert And Update
            clsAdressType obj = new clsAdressType();
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
