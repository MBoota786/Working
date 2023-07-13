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
    public class cityController : ControllerBase
    {
        cityDAL _activeDAL = new cityDAL();
        // GET: api/<cityController>
        [HttpGet]
        public List<clsCity> Get(string dbName)
        {
            List<clsCity> offList = _activeDAL.SelectAllCity(dbName);
            return offList;
        }

        // GET api/<cityController>/5
        [HttpGet("{stateProvinceId}")]
        public List<clsCity> Get(int stateProvinceId, string dbName)
        {
            List<clsCity> off = _activeDAL.SelectCityByStateProvinceId(stateProvinceId,dbName);
            return off;
        } 
        [HttpPost("GetByStateProvinceList")]
        public List<clsCity> GetByStateProvinceList(List<int> stateProvinceList, string dbName)
        {
            List<clsCity> offList = new List<clsCity>();
            if (stateProvinceList != null)
            {
                foreach (var item in stateProvinceList)
                {
                    List<clsCity> off = _activeDAL.SelectCityByStateProvinceId(item, dbName);
                    offList.AddRange(off);
                }
            }
            return offList;
        }

        // POST api/<cityController>
        [Authorize]
        [HttpPost]
        public string Post([FromBody] clsCity value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCity(value);
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCity(value);
                return "Insert";
            }
        }


    }
}
