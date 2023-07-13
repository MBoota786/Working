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
    public class paymentStatusController : ControllerBase
    {
        paymentStatusDAL _activeDAL = new paymentStatusDAL();
      
        [HttpGet]
        public List<clsPaymentStatus> Get(string dbName)
        {
            List<clsPaymentStatus> offList = _activeDAL.SelectAllPaymentStatus(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsPaymentStatus Get(int id, string dbName)
        {
            clsPaymentStatus off = _activeDAL.SelectPaymentStatusById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsPaymentStatus value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdatePaymentStatus(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertPaymentStatus(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsPaymentStatus ValidateData(clsPaymentStatus value)
        {
            //Add Logic For Insert And Update
            clsPaymentStatus obj = new clsPaymentStatus();
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
