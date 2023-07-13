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
    public class leadCompanyContactPersonController : ControllerBase
    {
        leadCompanyContactPersonDAL _activeDAL = new leadCompanyContactPersonDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsLeadCompanyContactPerson> offList = _activeDAL.SelectAllLeadCompanyContactPersons(null);
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

       
        [HttpGet("{id}")]
        public clsResult Get(int id,string dbName)
        {
            try
            {
                clsLeadCompanyContactPerson off = _activeDAL.SelectLeadCompanyContactPersonsById(id, null).FirstOrDefault();
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
        [HttpGet("GetByLeadCompanyId/{leadCompanyId}")]
        public clsResult GetByCompanyId(int leadCompanyId, string dbName)
        {
            try
            {
                List<clsLeadCompanyContactPerson> offList = _activeDAL.SelectLeadCompanyContactPersonsByLeadCompanyId(leadCompanyId, null);
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

        [HttpPost]
        public clsResult Post([FromBody] clsLeadCompanyContactPerson value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateLeadCompanyContactPersons(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertLeadCompanyContactPersons(ValidateData(value));
                    result.id = Id;
                    result.message = "Insert Successfully";
                }
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsLeadCompanyContactPerson ValidateData(clsLeadCompanyContactPerson value)
        {
            //Add Logic For Insert And Update
            clsLeadCompanyContactPerson obj = new clsLeadCompanyContactPerson();
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
