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
    public class checkListTypeController : ControllerBase
    {
        checkListTypeDAL _activeDAL = new checkListTypeDAL();
      
        [HttpGet]
        public List<clsCheckListType> Get(string dbName)
        {
            List<clsCheckListType> offList = _activeDAL.SelectAllCheckListType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsCheckListType Get(int id, string dbName)
        {
            clsCheckListType off = _activeDAL.SelectCheckListTypeById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsCheckListType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCheckListType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCheckListType(ValidateData(value));
                return "Insert";
            }
        }

        private clsCheckListType ValidateData(clsCheckListType value)
        {
            //Add Logic For Insert And Update
            clsCheckListType obj = new clsCheckListType();
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
