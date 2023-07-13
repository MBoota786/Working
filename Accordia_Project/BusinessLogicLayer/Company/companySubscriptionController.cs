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
    public class companySubscriptionController : ControllerBase
    {
        companySubscriptionDAL _activeDAL = new companySubscriptionDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsCompanySubscription> offList = _activeDAL.SelectAllCompanySubscription(dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

       
        [HttpGet("GetByCompanyId/{companyId}")]
        public clsResult GetByCompanyId(int companyId,string dbName)
        {
            try
            {
                List<clsCompanySubscription> offList = _activeDAL.SelectCompanySubscriptionByCompanyId(companyId,dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("CheckUserLimitAndOfficeLimitByCompanyId/{companyId}")]
        public clsResult CheckUserLimitAndOfficeLimitByCompanyId(int companyId, string dbName)
        {
            try
            {
                clsCompanySubscription off = _activeDAL.CheckUserLimitAndOfficeLimitByCompanyId(companyId, dbName);
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
        public clsResult Post([FromBody] clsCompanySubscription value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateCompanySubscription(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertCompanySubscription(ValidateData(value));
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

        private clsCompanySubscription ValidateData(clsCompanySubscription value)
        {
            //Add Logic For Insert And Update
            clsCompanySubscription obj = new clsCompanySubscription();
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
