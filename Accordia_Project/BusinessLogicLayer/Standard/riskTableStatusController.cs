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
    public class riskTableStatusController : ControllerBase
    {
        riskTableStatusDAL _activeDAL = new riskTableStatusDAL();
      
        [HttpGet]
        public List<clsRiskTableStatus> Get(string dbName)
        {
            List<clsRiskTableStatus> offList = _activeDAL.SelectAllRiskTableStatus(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsRiskTableStatus Get(int id, string dbName)
        {
            clsRiskTableStatus off = _activeDAL.SelectRiskTableStatusById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsRiskTableStatus value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateRiskTableStatus(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertRiskTableStatus(ValidateData(value));
                return "Insert";
            }
        }

        private clsRiskTableStatus ValidateData(clsRiskTableStatus value)
        {
            //Add Logic For Insert And Update
            clsRiskTableStatus obj = new clsRiskTableStatus();
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
