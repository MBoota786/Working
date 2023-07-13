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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class accreditationAddressesController : ControllerBase
    {
        accreditationAddressesDAL _activeDAL = new accreditationAddressesDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccreditationAddresses> offList = _activeDAL.SelectAllAccreditationAddresses(dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        [HttpGet("{id}")]
        public clsResult Get(int id,string dbName)
        {
            try
            {
                clsAccreditationAddresses off = _activeDAL.SelectAccreditationAddressesById(id,dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        } 
        [HttpGet("GetByAccreditationId/{accreditationId}")]
        public clsResult GetByAccreditationId(int accreditationId,string dbName)
        {
            try
            {
                List<clsAccreditationAddresses> offList = _activeDAL.SelectAccreditationAddressesByAccreditationId(accreditationId,dbName).ToList();
                result.Data = new List<object>();
                result.Data.AddRange(offList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

       
        [HttpPost]
        public clsResult Post([FromBody] clsAccreditationAddresses value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccredatioAddresses(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    _activeDAL.DeleteAccreditationAddresses(value.accreditationId, value.dbName);
                    int Id = _activeDAL.InsertAccreditationAddresses(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        private clsAccreditationAddresses ValidateData(clsAccreditationAddresses value)
        {
            //Add Logic For Insert And Update
            clsAccreditationAddresses obj = new clsAccreditationAddresses();
            if (value.id > 0)
            {
                value.active = true;
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
