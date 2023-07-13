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
    public class formulaOperationController : ControllerBase
    {
        formulaOperationDAL _activeDAL = new formulaOperationDAL();
      
        [HttpGet]
        public List<clsFormulaOperation> Get(string dbName)
        {
            List<clsFormulaOperation> offList = _activeDAL.SelectAllFormulaOperation(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsFormulaOperation Get(int id, string dbName)
        {
            clsFormulaOperation off = _activeDAL.SelectFormulaOperationById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsFormulaOperation value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateFormulaOperation(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertFormulaOperation(ValidateData(value));
                return "Insert";
            }
        }

        private clsFormulaOperation ValidateData(clsFormulaOperation value)
        {
            //Add Logic For Insert And Update
            clsFormulaOperation obj = new clsFormulaOperation();
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
