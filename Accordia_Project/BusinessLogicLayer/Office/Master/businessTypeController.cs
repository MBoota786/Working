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
    public class businessTypeController : ControllerBase
    {
        businessTypeDAL _activeDAL = new businessTypeDAL();
        // GET: api/<businessTypeController>
        [HttpGet]
        public List<clsBusinessType> Get(string dbName)
        {
            List<clsBusinessType> offList = _activeDAL.SelectAllBusinessType(dbName);
            return offList;
        }

        // GET api/<businessTypeController>/5
        [HttpGet("{id}")]
        public clsBusinessType Get(int id, string dbName)
        {
            clsBusinessType off = _activeDAL.SelectBusinessTypeById(id,dbName).FirstOrDefault();
            return off;
        }

        // POST api/<businessTypeController>
        [HttpPost]
        public string Post([FromBody] clsBusinessType value)
        {

            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateBusinessType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                if (_activeDAL.IsBusinessTypeExist(value.businessTypeName, value.dbName) == false)
                {
                    _activeDAL.InsertBusinessType(ValidateData(value));
                    return "Insert"; 
                }
                else {
                    return "Inserted";
                }
            }
        }

        private clsBusinessType ValidateData(clsBusinessType value)
        {
            //Add Logic For Insert And Update
            clsBusinessType obj = new clsBusinessType();
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
