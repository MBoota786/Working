using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.General
{

    [Route("api/[controller]")]
    [ApiController]
    public class stateProvinceController : ControllerBase
    {
        stateProviceDAL _activeDAL = new stateProviceDAL();
        // GET: api/<stateProvinceController>
        [HttpGet]
        public List<clsStateProvince> Get(string dbName)
        {
            List<clsStateProvince> offList = _activeDAL.SelectAllStateProvince(dbName);
            return offList;
        }

        // GET api/<stateProvinceController>/5
        [HttpGet("{coutryId}")]
        public List<clsStateProvince> Get(int coutryId, string dbName)
        {
            List<clsStateProvince> off = _activeDAL.SelectStateProvinceByCountryId(coutryId,dbName);
            return off;
        }

        // POST api/<stateProvinceController>
        [Authorize]
        [HttpPost]
        public string Post([FromBody] clsStateProvince value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateStateProvince(value);
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertStateProvince(value);
                return "Insert";
            }
        }

    }
}
