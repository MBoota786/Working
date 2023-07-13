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
    public class paymentStatusMappingController : ControllerBase
    {
        paymentStatusMappingDAL _activeDAL = new paymentStatusMappingDAL();
      
        [HttpGet]
        public List<clsPaymentStatusMapping> Get(string dbName)
        {
            List<clsPaymentStatusMapping> offList = _activeDAL.SelectAllPaymentStatusMapping(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsPaymentStatusMapping Get(int id, string dbName)
        {
            clsPaymentStatusMapping off = _activeDAL.SelectPaymentStatusMappingById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsPaymentStatusMapping value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdatePaymentStatusMapping(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertPaymentStatusMapping(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsPaymentStatusMapping ValidateData(clsPaymentStatusMapping value)
        {
            //Add Logic For Insert And Update
            clsPaymentStatusMapping obj = new clsPaymentStatusMapping();
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
