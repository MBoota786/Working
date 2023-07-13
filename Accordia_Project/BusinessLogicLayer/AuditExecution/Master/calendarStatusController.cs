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
    public class calendarStatusController : ControllerBase
    {
        calendarStatusDAL _activeDAL = new calendarStatusDAL();
      
        [HttpGet]
        public List<clsCalendarStatus> Get(string dbName)
        {
            List<clsCalendarStatus> offList = _activeDAL.SelectAllCalendarStatus(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsCalendarStatus Get(int id,string dbName)
        {
            clsCalendarStatus off = _activeDAL.SelectCalendarStatusById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsCalendarStatus value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCalendarStatus(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCalendarStatus(ValidateData(value));
                return "Insert";
            }
        }

        private clsCalendarStatus ValidateData(clsCalendarStatus value)
        {
            //Add Logic For Insert And Update
            clsCalendarStatus obj = new clsCalendarStatus();
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
