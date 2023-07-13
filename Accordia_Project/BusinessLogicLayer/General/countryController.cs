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
    public class countryController : ControllerBase
    {
        countryDAL _activeDAL = new countryDAL();
        // GET: api/<countryController>
        [HttpGet]
        public List<clsCountry> Get(string dbName)
        {
            List<clsCountry> offList = _activeDAL.SelectAllCountry(dbName);
            return offList;
        } 
        [HttpGet("GetCountryForDemographicScope")]
        public List<clsCountry> GetCountryForDemographicScope(string dbName)
        {
            List<clsCountry> offList = _activeDAL.SelectAllCountryForDemographicScope(dbName);
            return offList;
        }

        // GET api/<countryController>/5
        [Authorize]
        [HttpGet("{id}")]
        public clsCountry Get(int id, string dbName)
        {
            clsCountry off = _activeDAL.SelectCountryById(id, dbName).FirstOrDefault();
            return off;
        }

        // POST api/<countryController>
        [Authorize]
        [HttpPost]
        public string Post([FromBody] clsCountry value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCountry(value);
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCountry(value);
                return "Insert";
            }
        }

  
    
    }
}
