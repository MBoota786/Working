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
   
    [Route("api/[controller]")]
    [ApiController]
    public class subscriptionPlanController : ControllerBase
    {
        subscriptionPlanDAL _activeDAL = new subscriptionPlanDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsSubscriptionPlan> offList = _activeDAL.SelectAllSubscriptionPlan(dbName);
                packageStandardDAL stndDAL = new packageStandardDAL();
                if (offList != null)
                {
                    foreach (var item in offList)
                    {
                        item.packageStandard = stndDAL.SelectPackageStandardByPackageId(item.id, dbName);
                    }
                }
                result.isSuccess = true;
                result.Data = new List<object>();
                result.Data.AddRange(offList);
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
                clsSubscriptionPlan off = _activeDAL.SelectSubscriptionPlanById(id, dbName).FirstOrDefault();
                packageStandardDAL stndDAL = new packageStandardDAL();
                if (off != null)
                {
                    off.packageStandard = stndDAL.SelectPackageStandardByPackageId(off.id, dbName);
                }
                result.Data = new List<object>();
                result.Data.Add(off);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }
        [Authorize]
        [HttpPost]
        public clsResult Post([FromBody] clsSubscriptionPlan value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateSubscriptionPlan(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertSubscriptionPlan(ValidateData(value));
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

        private clsSubscriptionPlan ValidateData(clsSubscriptionPlan value)
        {
            //Add Logic For Insert And Update
            clsSubscriptionPlan obj = new clsSubscriptionPlan();
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
