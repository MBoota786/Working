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
    public class modeOfPaymentController : ControllerBase
    {
        modeOfPaymentDAL _activeDAL = new modeOfPaymentDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsModeOfPayment> offList = _activeDAL.SelectAllModeOfPayment(dbName);
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
                clsModeOfPayment off = _activeDAL.SelectModeOfPaymentById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        [HttpPost]
        public clsResult Post([FromBody] clsModeOfPayment value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateModeOfPayment(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertModeOfPayment(ValidateData(value));
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

    
        private clsModeOfPayment ValidateData(clsModeOfPayment value)
        {
            //Add Logic For Insert And Update
            clsModeOfPayment obj = new clsModeOfPayment();
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
