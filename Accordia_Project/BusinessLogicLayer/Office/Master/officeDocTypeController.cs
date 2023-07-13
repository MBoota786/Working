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
    public class officeDocTypeController : ControllerBase
    {
        officeDocTypeDAL _activeDAL = new officeDocTypeDAL();
        // GET: api/<officeDocTypeController>
        [HttpGet]
        public List<clsOfficeDocType> Get(string dbName)
        {
            List<clsOfficeDocType> offList = _activeDAL.SelectAllOfficeDocType(dbName);
            return offList;
        }

        // GET api/<officeDocTypeController>/5
        [HttpGet("{id}")]
        public clsOfficeDocType Get(int id, string dbName)
        {
            clsOfficeDocType off = _activeDAL.SelectOfficeDocTypesById(id,dbName).FirstOrDefault();
            return off;
        }

        // POST api/<officeDocTypeController>
        [HttpPost]
        public string Post([FromBody] clsOfficeDocType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateOfficeDocType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertOfficeDocType(ValidateData(value));
                return "Insert";
            }
        }

        private clsOfficeDocType ValidateData(clsOfficeDocType value)
        {
            //Add Logic For Insert And Update
            clsOfficeDocType obj = new clsOfficeDocType();
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
