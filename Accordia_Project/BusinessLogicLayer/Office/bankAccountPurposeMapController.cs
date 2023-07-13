using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class bankAccountPurposeMapController : ControllerBase
    {
        bankAccountPurposeMapDAL _activeDAL = new bankAccountPurposeMapDAL();
        clsResult result = new clsResult();
        // GET: api/<officeTypeController>
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsBankAccountPurposeMap> offList = _activeDAL.SelectAllBankAccountPurposeMap(dbName);
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

        // GET api/<officeTypeController>/5
        [HttpGet("{officeBankDetailsId}")]
        public clsResult Get(int officeBankDetailsId, string dbName)
        {
            try
            {
                clsBankAccountPurposeMap off = _activeDAL.SelectBankAccountPurposeMapByOfficeBankDetailsId(officeBankDetailsId, dbName).FirstOrDefault();
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

        // POST api/<officeTypeController>
        [HttpPost]
        public clsResult Post([FromBody] clsBankAccountPurposeMap value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateBankAccountPurposeMap(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertBankAccountPurposeMap(ValidateData(value));
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
     
        private clsBankAccountPurposeMap ValidateData(clsBankAccountPurposeMap value)
        {
            //Add Logic For Insert And Update
            clsBankAccountPurposeMap obj = new clsBankAccountPurposeMap();
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
