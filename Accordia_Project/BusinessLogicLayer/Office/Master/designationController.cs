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
    public class designationController : ControllerBase
    {
        designationDAL _activeDAL = new designationDAL();
        clsResult result = new clsResult();
        // GET: api/<designationController>
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsDesignation> offList = _activeDAL.SelectAllDesignation(dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        // GET api/<designationController>/5
        [HttpGet("{id}")]
        public clsResult Get(int id, string dbName)
        {
            try
            {
                clsDesignation obj = _activeDAL.SelectDesignationById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(obj);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        // POST api/<designationController>
        [HttpPost]
        public clsResult Post([FromBody] clsDesignation value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateDesignation(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    if (_activeDAL.IsDesignationExist(value.designationName, value.dbName) == false)
                    {
                        // Insert Query
                        int Id = _activeDAL.InsertDesignation(ValidateData(value));
                        result.id = Id;
                    }
                    result.message = "Insert Successfully";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }

        private clsDesignation ValidateData(clsDesignation value)
        {
            //Add Logic For Insert And Update
            clsDesignation obj = new clsDesignation();
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
