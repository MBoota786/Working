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
    public class officeSetupStepsController : ControllerBase
    {
        officeSetupStepsDAL _activeDAL = new officeSetupStepsDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {

            List<clsOfficeSetupSteps> offList = _activeDAL.SelectAllOfficeSetupSteps(dbName);
            result.Data = new List<object>();
            result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

       
        [HttpGet("{id}")]
        public clsResult Get(int id, string dbName)
        {
            try
            {

           
            clsOfficeSetupSteps off = _activeDAL.SelectOfficeSetupStepsById(id,dbName).FirstOrDefault();
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
        public clsResult GetByOfficeId(int officeId,string dbName)
        {
            try
            {

            List<clsOfficeSetupSteps> offList = _activeDAL.SelectOfficeSetupStepsByOfficeId(officeId,dbName);
            result.Data = new List<object>();
            result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        [HttpPost]
        public clsResult Post([FromBody] clsOfficeSetupSteps value)
        {
            try
            {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateOfficeSetupSteps(ValidateData(value));
                result.id = value.id;
                result.message = "Update Successfully";

            }
            else
            {
                // Insert Query
               int Id = _activeDAL.InsertOfficeSetupSteps(ValidateData(value));
                result.id = Id;
                result.message = "Insert Successfully";
            }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }

        private clsOfficeSetupSteps ValidateData(clsOfficeSetupSteps value)
        {
            //Add Logic For Insert And Update
            clsOfficeSetupSteps obj = new clsOfficeSetupSteps();
            if (value.id > 0)
            {
               // On Update Logic
            }
            else
            {
               // On Insert Logic
            }
            obj = value;
            return obj;
        }
    }
}
