using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeEmailController : ControllerBase
    {
        officeEmailDAL _activeDAL = new officeEmailDAL();
        clsResult result = new clsResult();
        // GET: api/<officeEmailController>
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeEmail> offList = _activeDAL.SelectAllOfficeEmail(dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        // GET api/<officeEmailController>/5
        [HttpGet("{id}")]
        public clsResult Get(int id,string dbName)
        {
            try
            {
                clsOfficeEmail off = _activeDAL.SelectOfficeEmailById(id,dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;  
        }
        [HttpGet("GetByOfficeId/{officeId}")]
        public clsResult GetByOfficeId(int officeId, string dbName)
        {
            try
            {
                clsOfficeEmail off = _activeDAL.SelelctOfficeEmailByOfficeId(officeId, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        // POST api/<officeEmailController>
        [HttpPost]
        public clsResult Post([FromBody] clsOfficeEmail value)
        {
            try
            {

            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateOfficeEmail(ValidateData(value));
                result.id = value.id;
                result.message = "Update Successfully";
            }
            else
            {
                // Insert Query
               int Id = _activeDAL.InsertOfficeEmail(ValidateData(value));
                result.id = Id;
                result.message = "Insert Successfully";
            }

            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        private clsOfficeEmail ValidateData(clsOfficeEmail value)
        {
            //Add Logic For Insert And Update
            clsOfficeEmail obj = new clsOfficeEmail();
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
