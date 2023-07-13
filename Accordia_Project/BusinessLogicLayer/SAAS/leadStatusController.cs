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
    public class leadStatusController : ControllerBase
    {
        leadStatusDAL _activeDAL = new leadStatusDAL();
      
        [HttpGet()]
        public List<clsLeadStatus> Get(string dbName)
        {
            List<clsLeadStatus> offList = _activeDAL.SelectAllLeadStatus(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsLeadStatus Get(int id, string dbName)
        {
            clsLeadStatus off = _activeDAL.SelectLeadStatusById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsLeadStatus value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateLeadStatus(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertLeadStatus(ValidateData(value));
                return "Insert";
            }
        }

        private clsLeadStatus ValidateData(clsLeadStatus value)
        {
            //Add Logic For Insert And Update
            clsLeadStatus obj = new clsLeadStatus();
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
