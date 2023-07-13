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
 //   [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class appQuotationOtherChargesController : ControllerBase
    {
        appQuotationOtherChargesDAL _activeDAL = new appQuotationOtherChargesDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppQuotationOtherCharges> offList = _activeDAL.SelectAllAppQuotationOtherCharges(dbName);
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
        [HttpGet("GetByApplicationQuotationDtlId")]
        public clsResult GetByApplicationQuotationDtlId(int applicationQuotationId, string dbName)
        {
            try
            {
                List<clsAppQuotationOtherCharges> offList = _activeDAL.SelectAppQuotationOtherChargesByApplicationQuotationDtlId(applicationQuotationId,dbName);
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
                clsAppQuotationOtherCharges off = _activeDAL.SelectAppQuotationOtherChargesById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] List<clsAppQuotationOtherCharges> value)
        {
            try
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        if (item != null)
                        {
                //clsAppQuotationOtherCharges off = _activeDAL.SelectAppQuotationOtherChargesByApplicationQuotationIdClientSiteId(item.applicationQuotationId, item.clientSiteId, value[0].dbName).FirstOrDefault();
                //            if (off != null)
                //            {
                //                item.id = off.id > 0 ? off.id : 0;
                //            }
                            if (item.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAppQuotationOtherCharges(ValidateData(item));
                    result.id = item.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAppQuotationOtherCharges(ValidateData(item));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                        }
                    }
                    List<clsAppQuotationOtherCharges> offList = _activeDAL.SelectAppQuotationOtherChargesByApplicationQuotationDtlId(value[0].applicationQuotationDtlId, value[0].dbName);
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

        private clsAppQuotationOtherCharges ValidateData(clsAppQuotationOtherCharges value)
        {
            //Add Logic For Insert And Update
            clsAppQuotationOtherCharges obj = new clsAppQuotationOtherCharges();
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
