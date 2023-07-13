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
    public class riskLevelController : ControllerBase
    {
        riskLevelDAL _activeDAL = new riskLevelDAL();
      
        [HttpGet]
        public List<clsRiskLevel> Get(string dbName)
        {
            List<clsRiskLevel> offList = _activeDAL.SelectAllRiskLevel(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsRiskLevel Get(int id, string dbName)
        {
            clsRiskLevel off = _activeDAL.SelectRiskLevelById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsRiskLevel value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateRiskLevel(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertRiskLevel(ValidateData(value));
                return "Insert";
            }
        }

        private clsRiskLevel ValidateData(clsRiskLevel value)
        {
            //Add Logic For Insert And Update
            clsRiskLevel obj = new clsRiskLevel();
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
