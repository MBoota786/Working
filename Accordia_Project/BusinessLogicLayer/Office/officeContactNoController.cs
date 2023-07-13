using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeContactNoController : ControllerBase
    {
        officeContactNoDAL _activeDAL = new officeContactNoDAL();
        // GET: api/<companyContactInformationController>
        [HttpGet]
        public List<clsOfficeContactNo> Get(string dbName)
        {
            List<clsOfficeContactNo> offList = _activeDAL.SelectAllOfficeContactNo(dbName);
            return offList;
        }

        // GET api/<companyContactInformationController>/5
        [HttpGet("{officeAddressId}")]
        public List<clsOfficeContactNo> GetByOfficeAddressId(int officeAddressId, string dbName)
        {
            List<clsOfficeContactNo> offList = _activeDAL.SelectOfficeContactNoByOfficeAddressId(officeAddressId, dbName);
            return offList;
        }

        // POST api/<companyContactInformationController>
        [HttpPost]
        public int Post([FromBody] clsOfficeContactNo value)
        {
            if (value.officeAddressId > 0)
            {
                value.id = _activeDAL.SelectOfficeContactNoByOfficeAddressId(value.officeAddressId, value.dbName).FirstOrDefault() != null ? _activeDAL.SelectOfficeContactNoByOfficeAddressId(value.officeAddressId, value.dbName).FirstOrDefault().id : 0;
            }
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateOfficeContactNo(ValidateData(value));
                return value.id;
            }
            else
            {
                // Insert Query
               int Id = _activeDAL.InsertOfficeContactNo(ValidateData(value));
                return Id;
            }
        }


        private clsOfficeContactNo ValidateData(clsOfficeContactNo value)
        {
            //Add Logic For Insert And Update
            clsOfficeContactNo obj = new clsOfficeContactNo();
            if (value.id > 0)
            {
                value.active = true;
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.active = false;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
    }
}
