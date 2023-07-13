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
    public class paymentStatusTypeController : ControllerBase
    {
        paymentStatusTypeDAL _activeDAL = new paymentStatusTypeDAL();
      
        [HttpGet]
        public List<clsPaymentStatusType> Get(string dbName)
        {
            List<clsPaymentStatusType> offList = _activeDAL.SelectAllPaymentStatusType(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsPaymentStatusType Get(int id, string dbName)
        {
            clsPaymentStatusType off = _activeDAL.SelectPaymentStatusTypeById(id,dbName).FirstOrDefault();
            return off;
        }

       
        [HttpPost]
        public string Post([FromBody] clsPaymentStatusType value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdatePaymentStatusType(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertPaymentStatusType(ValidateData(value));
                return "Insert";
            }
        }

    
        private clsPaymentStatusType ValidateData(clsPaymentStatusType value)
        {
            //Add Logic For Insert And Update
            clsPaymentStatusType obj = new clsPaymentStatusType();
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
