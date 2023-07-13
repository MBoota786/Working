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
    public class checkListController : ControllerBase
    {
        checkListDAL _activeDAL = new checkListDAL();
      
        [HttpGet]
        public List<clsCheckList> Get(string dbName)
        {
            List<clsCheckList> offList = _activeDAL.SelectAllCheckList(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsCheckList Get(int id, string dbName)
        {
            clsCheckList off = _activeDAL.SelectAllCheckListById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsCheckList value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCheckList(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCheckList(ValidateData(value));
                return "Insert";
            }
        }

        private clsCheckList ValidateData(clsCheckList value)
        {
            //Add Logic For Insert And Update
            clsCheckList obj = new clsCheckList();
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
