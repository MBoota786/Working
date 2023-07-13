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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class accreditationBodyStandardController : ControllerBase
    {
        accreditationBodyStandardDAL _activeDAL = new accreditationBodyStandardDAL();
        clsResult result = new clsResult();

        //_____ Insert , Update ______
        [HttpPost]
        public clsResult Post([FromBody] clsAccreditationBodyStandard value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccreditationBodyStandard(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccreditationBodyStandard(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        private clsAccreditationBodyStandard ValidateData(clsAccreditationBodyStandard value)
        {
            //Add Logic For Insert And Update
            clsAccreditationBodyStandard obj = new clsAccreditationBodyStandard();
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

        //_____ get All AccredationStandared ______
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccreditationBodyStandard> offList = _activeDAL.SelectAllAccreditationBodyStandard();
                result.Data = new List<object>();
                result.Data.AddRange(offList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        //_____ get single AccredationStandared ______
        [HttpGet("{id}")]
        public clsResult Get(int id)
        {
            try
            {
                clsAccreditationBodyStandard off = _activeDAL.SelectAccreditationBodyStandardById(id).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }


        //_____ Get Audtior by ______
        [HttpGet("GetByAccreditationId/{accreditationId}")]
        public clsResult GetByAccreditationId(int accreditationId)
        {
            try
            {
                List<clsAccreditationBodyStandard> offList = _activeDAL.SelectAccreditationBodyStandardByAccreditationId(accreditationId).ToList();
                result.Data = new List<object>();
                result.Data.Add(offList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }


    }
}
