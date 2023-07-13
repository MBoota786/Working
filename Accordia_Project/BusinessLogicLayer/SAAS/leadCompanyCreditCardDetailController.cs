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
    public class leadCompanyCreditCardDetailController : ControllerBase
    {
        leadCompanyCreditCardDetailDAL _activeDAL = new leadCompanyCreditCardDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsLeadCompanyCreditCardDetail> offList = _activeDAL.SelectAllLeadCompanyCreditCardDetail(null);
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


        [HttpGet("GetByLeadCompanyId/{leadCompanyId}")]
        public clsResult GetByLeadCompanyId(int leadCompanyId,string dbName)
        {
            try
            {
                clsLeadCompanyCreditCardDetail off = _activeDAL.spSelectLeadCompanyCreditCardDetailByLeadCompanyId(leadCompanyId, null).FirstOrDefault();
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

        [HttpPost]
        public clsResult Post([FromBody] clsLeadCompanyCreditCardDetail value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateLeadCompanyCreditCardDetail(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertLeadCompanyCreditCardDetail(ValidateData(value));
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

        private clsLeadCompanyCreditCardDetail ValidateData(clsLeadCompanyCreditCardDetail value)
        {
            //Add Logic For Insert And Update
            clsLeadCompanyCreditCardDetail obj = new clsLeadCompanyCreditCardDetail();
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
