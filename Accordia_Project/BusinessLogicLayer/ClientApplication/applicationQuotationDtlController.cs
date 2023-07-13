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
    public class applicationQuotationDtlController : ControllerBase
    {
        applicationQuotationDtlDAL _activeDAL = new applicationQuotationDtlDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsApplicationQuotationDtl> offList = _activeDAL.SelectAllApplicationQuotationDtl(dbName);
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
        [HttpGet("GetByApplicationQuotationId")]
        public clsResult GetByApplicationQuotationId(int applicationQuotationId, string dbName)
        {
            try
            {
                List<clsApplicationQuotationDtl> offList = _activeDAL.SelectApplicationQuotationDtlByApplicationQuotationId(applicationQuotationId, dbName);
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
                clsApplicationQuotationDtl off = _activeDAL.SelectApplicationQuotationDtlById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] List<clsApplicationQuotationDtl> value)
        {
            try
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        if (item.id > 0)
                        {
                            //Update Query
                            _activeDAL.InsertApplicationQuotationDtl(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // Insert Query
                            int Id = _activeDAL.InsertApplicationQuotationDtl(ValidateData(item));
                            result.id = Id;
                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                        }
                    }
                    List<clsApplicationQuotationDtl> offList = _activeDAL.SelectApplicationQuotationDtlByApplicationQuotationId(value[0].applicationQuotationId, value[0].dbName);
                    result.Data = new List<object>();
                    result.Data.AddRange(offList);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsApplicationQuotationDtl ValidateData(clsApplicationQuotationDtl value)
        {
            //Add Logic For Insert And Update
            clsApplicationQuotationDtl obj = new clsApplicationQuotationDtl();
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
