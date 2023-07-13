using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Route("api/[controller]")]
    [ApiController]
    public class companyContactInformationController : ControllerBase
    {
        companyContactInformationDAL _activeDAL = new companyContactInformationDAL();
        // GET: api/<companyContactInformationController>
        [HttpGet]
        public List<clsCompanyContactInformation> Get()
        {
            List<clsCompanyContactInformation> offList = _activeDAL.SelectAllCompanyContactInformation();
            return offList;
        }

        // GET api/<companyContactInformationController>/5
        [HttpGet("{id}")]
        public clsCompanyContactInformation Get(int id)
        {
            clsCompanyContactInformation off = _activeDAL.SelectCompanyContactInformationById(id).FirstOrDefault();
            return off;
        }

        // POST api/<companyContactInformationController>
        [HttpPost]
        public string Post([FromBody] clsCompanyContactInformation value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCompanyContactInformation(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCompanyContactInformation(ValidateData(value));
                return "Insert";
            }
        }


        private clsCompanyContactInformation ValidateData(clsCompanyContactInformation value)
        {
            //Add Logic For Insert And Update
            clsCompanyContactInformation obj = new clsCompanyContactInformation();
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
