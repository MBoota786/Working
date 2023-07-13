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
    public class officeAddressesController : ControllerBase
    {
        officeAdressesDAL _activeDAL = new officeAdressesDAL();
        clsResult result = new clsResult();
        // GET: api/<officeAddressesController>
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeAddresses> offList = _activeDAL.SelectAllOfficeAdresses(dbName);
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
        public clsResult GetById(int id, string dbName)
        {
            try
            {
                clsOfficeAddresses offList = _activeDAL.SelectOfficeAdressesById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(offList);
                result.isSuccess = true;
                result.message = General.messageModel.GetDataMessage;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("GetByOfficeId/{officeId}")]
        public clsResult GetByOfficeId(int officeId, string dbName)
        {
            try
            {
                clsOfficeAddresses offList = _activeDAL.SelectOfficeAdressesByOfficeId(officeId, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(offList);
                result.isSuccess = true;
                result.message = General.messageModel.GetDataMessage;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        // POST api/<officeAddressesController>
        [HttpPost]
        public clsResult Post([FromBody] clsOfficeAddresses value)
        {
            try
            {
                if(value.officeID > 0)
                {
                    value.id = _activeDAL.SelectOfficeAdressesByOfficeId(value.officeID,value.dbName).FirstOrDefault() != null ? _activeDAL.SelectOfficeAdressesByOfficeId(value.officeID, value.dbName).FirstOrDefault().id : 0;
                }
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateOfficeAdresses(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertOfficeAdresses(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }


        private clsOfficeAddresses ValidateData(clsOfficeAddresses value)
        {
            //Add Logic For Insert And Update
            clsOfficeAddresses obj = new clsOfficeAddresses();
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
