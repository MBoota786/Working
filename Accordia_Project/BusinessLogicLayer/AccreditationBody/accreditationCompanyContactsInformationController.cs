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
    public class accreditationCompanyContactsInformationController : ControllerBase
    {
        accreditationCompanyContactsInformationDAL _activeDAL = new accreditationCompanyContactsInformationDAL();

        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccreditationCompanyContactsInformation> offList = _activeDAL.SelectAllAccreditationCompanyContactsInformation(dbName);
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
                clsAccreditationCompanyContactsInformation off = _activeDAL.SelectAccreditationCompanyContactsInformationById(id,dbName).FirstOrDefault();
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
                List<clsAccreditationCompanyContactsInformation> offList = _activeDAL.SelectAccreditationCompanyContactsInformationByAccreditationId(accreditationId,dbName).ToList();
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
        public clsResult Post([FromBody] clsAccreditationCompanyContactsInformation value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccreditationCompanyContactsInformation(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    _activeDAL.DeleteAccreditationCompanyContactsInformation(value.accreditationId, value.dbName);
                    int Id = _activeDAL.InsertAccreditationCompanyContactsInformation(ValidateData(value));
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

        private clsAccreditationCompanyContactsInformation ValidateData(clsAccreditationCompanyContactsInformation value)
        {
            //Add Logic For Insert And Update
            clsAccreditationCompanyContactsInformation obj = new clsAccreditationCompanyContactsInformation();
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
