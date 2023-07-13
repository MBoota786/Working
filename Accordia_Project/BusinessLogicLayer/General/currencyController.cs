using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.General
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class currencyController : ControllerBase
    {
        currencyDAL _activeDAL = new currencyDAL();
        // GET: api/<currencyController>
        [HttpGet]
        public List<clsCurrency> Get(string dbName)
        {
            List<clsCurrency> offList = _activeDAL.SelectAllCurrency(dbName);
            return offList;
        }

        // GET api/<currencyController>/5
        [HttpGet("{id}")]
        public clsCurrency Get(int id, string dbName)
        {
            clsCurrency off = _activeDAL.SelectCurrencyById(id,dbName).FirstOrDefault();
            return off;
        }

        // POST api/<currencyController>
        [HttpPost]
        public string Post([FromBody] clsCurrency value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCurrency(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCurrency(ValidateData(value));
                return "Insert";
            }
        }

        private clsCurrency ValidateData(clsCurrency value)
        {
            //Add Logic For Insert And Update
            clsCurrency obj = new clsCurrency();
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
