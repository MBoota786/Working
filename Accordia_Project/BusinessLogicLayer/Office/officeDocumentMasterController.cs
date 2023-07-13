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
    public class officeDocumentMasterController : ControllerBase
    {
        officeDocumentMasterDAL _activeDAL = new officeDocumentMasterDAL();
      
        [HttpGet]
        public List<clsOfficeDocumentMaster> Get()
        {
            List<clsOfficeDocumentMaster> offList = _activeDAL.SelectAllOfficeDocumentMaster();
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsOfficeDocumentMaster Get(int id)
        {
            clsOfficeDocumentMaster off = _activeDAL.SelectOfficeDocumentMasterById(id).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsOfficeDocumentMaster value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateOfficeDocumentMaster(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertOfficeDocumentMaster(ValidateData(value));
                return "Insert";
            }
        }

        private clsOfficeDocumentMaster ValidateData(clsOfficeDocumentMaster value)
        {
            //Add Logic For Insert And Update
            clsOfficeDocumentMaster obj = new clsOfficeDocumentMaster();
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
