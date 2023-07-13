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
    public class officeDocumentDtlController : ControllerBase
    {
        officeDocumentDtlDAL _activeDAL = new officeDocumentDtlDAL();
      
        [HttpGet]
        public List<clsOfficeDocumentDtl> Get()
        {
            List<clsOfficeDocumentDtl> offList = _activeDAL.SelectAllOfficeDocumentDtl();
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsOfficeDocumentDtl Get(int id)
        {
            clsOfficeDocumentDtl off = _activeDAL.SelectOfficeDocumentDtlById(id).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsOfficeDocumentDtl value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateOfficeDocumentDtl(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertOfficeDocumentDtl(ValidateData(value));
                return "Insert";
            }
        }

        private clsOfficeDocumentDtl ValidateData(clsOfficeDocumentDtl value)
        {
            //Add Logic For Insert And Update
            clsOfficeDocumentDtl obj = new clsOfficeDocumentDtl();
            if (value.id > 0)
            {

            }
            else
            {
             
            }
            obj = value;
            return obj;
        }
    }
}
