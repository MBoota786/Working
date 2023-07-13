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
    public class checkListSectionController : ControllerBase
    {
        checkListSectionDAL _activeDAL = new checkListSectionDAL();
      
        [HttpGet]
        public List<clsCheckListSection> Get(string dbName)
        {
            List<clsCheckListSection> offList = _activeDAL.SelectAllCheckListSection(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsCheckListSection Get(int id, string dbName)
        {
            clsCheckListSection off = _activeDAL.SelectCheckListSectionById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsCheckListSection value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateCheckListSection(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertCheckListSection(ValidateData(value));
                return "Insert";
            }
        }

        private clsCheckListSection ValidateData(clsCheckListSection value)
        {
            //Add Logic For Insert And Update
            clsCheckListSection obj = new clsCheckListSection();
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
