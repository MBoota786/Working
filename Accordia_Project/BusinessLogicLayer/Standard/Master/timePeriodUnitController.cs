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
    public class timePeriodUnitController : ControllerBase
    {
        timePeriodUnitDAL _activeDAL = new timePeriodUnitDAL();
      
        [HttpGet]
        public List<clsTimePeriodUnit> Get(string dbName)
        {
            List<clsTimePeriodUnit> offList = _activeDAL.SelectAllTimePeriodUnit(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsTimePeriodUnit Get(int id, string dbName)
        {
            clsTimePeriodUnit off = _activeDAL.SelectTimePeriodUnitById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsTimePeriodUnit value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateTimePeriodUnit(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertTimePeriodUnit(ValidateData(value));
                return "Insert";
            }
        }

        private clsTimePeriodUnit ValidateData(clsTimePeriodUnit value)
        {
            //Add Logic For Insert And Update
            clsTimePeriodUnit obj = new clsTimePeriodUnit();
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
