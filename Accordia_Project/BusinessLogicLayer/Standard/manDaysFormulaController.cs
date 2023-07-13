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
    public class manDaysFormulaController : ControllerBase
    {
        manDaysFormulaDAL _activeDAL = new manDaysFormulaDAL();
      
        [HttpGet]
        public List<clsManDaysFormula> Get(string dbName)
        {
            List<clsManDaysFormula> offList = _activeDAL.SelectAllManDaysFormula(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsManDaysFormula Get(int id, string dbName)
        {
            clsManDaysFormula off = _activeDAL.SelectManDaysFormulaById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsManDaysFormula value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateManDaysFormula(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertManDaysFormula(ValidateData(value));
                return "Insert";
            }
        }

        private clsManDaysFormula ValidateData(clsManDaysFormula value)
        {
            //Add Logic For Insert And Update
            clsManDaysFormula obj = new clsManDaysFormula();
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
