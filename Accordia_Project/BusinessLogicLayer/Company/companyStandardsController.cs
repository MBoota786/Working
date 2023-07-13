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
    public class companyStandardsController : ControllerBase
    {
        companyStandardsDAL _activeDAL = new companyStandardsDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsCompanyStandards> offList = _activeDAL.SelectAllCompanyStandards(dbName);
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
        public clsResult GetByCompanyId(int id,string dbName)
        {
            try
            {
                List<clsCompanyStandards> offList = _activeDAL.SelectCompanyStandardsById(id,dbName);
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
        public clsResult Post([FromBody] clsCompanyStandards value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateCompanyStandards(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertCompanyStandards(ValidateData(value));
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

        private clsCompanyStandards ValidateData(clsCompanyStandards value)
        {
            //Add Logic For Insert And Update
            clsCompanyStandards obj = new clsCompanyStandards();
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
