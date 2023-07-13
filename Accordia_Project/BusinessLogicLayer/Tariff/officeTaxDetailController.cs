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
    public class officeTaxDetailController : ControllerBase
    {
        officeTaxDetailDAL _activeDAL = new officeTaxDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeTaxDetail> offList = _activeDAL.SelectAllOfficeTaxDetail(dbName);
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
        [HttpGet("GetByOfficeTaxId")]
        public clsResult GetByOfficeTaxId(int officeTaxId,string dbName)
        {
            try
            {
                List<clsOfficeTaxDetail> offList = _activeDAL.SelectOfficeTaxDetailByOfficeTaxId(officeTaxId, dbName);
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
        public clsResult Get(int id, string dbName)
        {
            try
            {
                clsOfficeTaxDetail off = _activeDAL.SelectOfficeTaxDetailById(id, dbName).FirstOrDefault();
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

        [HttpPost]
        public clsResult Post([FromBody] clsOfficeTaxDetail value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateOfficeTaxDetail(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertOfficeTaxDetail(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                List<clsOfficeTaxDetail> offList = _activeDAL.SelectOfficeTaxDetailByOfficeTaxId(value.officeTaxId,value.dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsOfficeTaxDetail ValidateData(clsOfficeTaxDetail value)
        {
            //Add Logic For Insert And Update
            clsOfficeTaxDetail obj = new clsOfficeTaxDetail();
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
