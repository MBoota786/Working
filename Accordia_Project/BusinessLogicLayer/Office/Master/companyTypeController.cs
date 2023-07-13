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
    public class companyTypeController : ControllerBase
    {
        companyTypeDAL _activeDAL = new companyTypeDAL();
      
        [HttpGet]
        public List<clsCompanyType> Get(string dbName)
        {
            List<clsCompanyType> offList = _activeDAL.SelectAllCompanyType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsCompanyType Get(int id, string dbName)
        {
            clsCompanyType off = _activeDAL.SelectCompanyTypeById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsCompanyType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCompanyType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCompanyType(ValidateData(value));
                return "Insert";
            }
        }


        private clsCompanyType ValidateData(clsCompanyType value)
        {
            //Add Logic For Insert And Update
            clsCompanyType obj = new clsCompanyType();
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
