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
    public class trTypeController : ControllerBase
    {
        trTypeDAL _activeDAL = new trTypeDAL();

        [HttpGet]
        public List<clsTrType> Get(string dbName)
        {
            List<clsTrType> offList = _activeDAL.SelectAllTrType(dbName);
            return offList;
        }


        [HttpGet("{id}")]
        public clsTrType Get(int id, string dbName)
        {
            clsTrType off = _activeDAL.SelectTrTypeById(id, dbName).FirstOrDefault();
            return off;
        }


        [HttpPost]
        public string Post([FromBody] clsTrType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateTrType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertTrType(ValidateData(value));
                return "Insert";
            }
        }


        private clsTrType ValidateData(clsTrType value)
        {
            //Add Logic For Insert And Update
            clsTrType obj = new clsTrType();
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
