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
    public class standardReqCheckListController : ControllerBase
    {
        standardReqCheckListDAL _activeDAL = new standardReqCheckListDAL();
      
        [HttpGet]
        public List<clsStandardReqCheckList> Get(string dbName)
        {
            List<clsStandardReqCheckList> offList = _activeDAL.SelectAllStandardReqCheckList(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsStandardReqCheckList Get(int id, string dbName)
        {
            clsStandardReqCheckList off = _activeDAL.SelectStandardReqCheckListById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsStandardReqCheckList value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateStandardReqCheckList(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertStandardReqCheckList(ValidateData(value));
                return "Insert";
            }
        }

        private clsStandardReqCheckList ValidateData(clsStandardReqCheckList value)
        {
            //Add Logic For Insert And Update
            clsStandardReqCheckList obj = new clsStandardReqCheckList();
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
