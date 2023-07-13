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
    public class clauseTypeController : ControllerBase
    {
        clauseTypeDAL _activeDAL = new clauseTypeDAL();
      
        [HttpGet]
        public List<clsClauseType> Get(string dbName)
        {
            List<clsClauseType> offList = _activeDAL.SelectAllClauseType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsClauseType Get(int id, string dbName)
        {
            clsClauseType off = _activeDAL.SelectClauseTypeById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsClauseType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateClauseType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertClauseType(ValidateData(value));
                return "Insert";
            }
        }

        private clsClauseType ValidateData(clsClauseType value)
        {
            //Add Logic For Insert And Update
            clsClauseType obj = new clsClauseType();
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
