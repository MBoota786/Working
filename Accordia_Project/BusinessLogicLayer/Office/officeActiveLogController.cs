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
    public class officeActiveLogController : ControllerBase
    {
        officeActiveLogDAL _activeDAL = new officeActiveLogDAL();
      
        [HttpGet]
        public List<clsOfficeActiveLog> Get()
        {
            List<clsOfficeActiveLog> offList = _activeDAL.SelectAllOfficeActiveLog();
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsOfficeActiveLog Get(int id)
        {
            clsOfficeActiveLog off = _activeDAL.SelectOfficeActiveLogById(id).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsOfficeActiveLog value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateOfficeActiveLog(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertOfficeActiveLog(ValidateData(value));
                return "Insert";
            }
        }


        private clsOfficeActiveLog ValidateData(clsOfficeActiveLog value)
        {
            //Add Logic For Insert And Update
            clsOfficeActiveLog obj = new clsOfficeActiveLog();
            if (value.id > 0)
            {
               // On Update Logic
            }
            else
            {
               // On Insert Logic
            }
            obj = value;
            return obj;
        }
    }
}
