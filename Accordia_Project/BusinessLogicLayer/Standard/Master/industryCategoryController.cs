using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class industryCategoryController : ControllerBase
    {
        industryCategoryDAL _activeDAL = new industryCategoryDAL();
      
        [HttpGet]
        public List<clsIndustryCategory> Get(string dbName)
        {
            List<clsIndustryCategory> offList = _activeDAL.SelectAllIndustryCategory(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsIndustryCategory Get(int id, string dbName)
        {
            clsIndustryCategory off = _activeDAL.SelectIndustryCategoryById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsIndustryCategory value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateIndustryCategory(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertIndustryCategory(ValidateData(value));
                return "Insert";
            }
        }

        private clsIndustryCategory ValidateData(clsIndustryCategory value)
        {
            //Add Logic For Insert And Update
            clsIndustryCategory obj = new clsIndustryCategory();
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
