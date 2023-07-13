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
    public class accrSpecialChargesController : ControllerBase
    {
        accrSpecialChargesDAL _activeDAL = new accrSpecialChargesDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccrSpecialCharges> offList = _activeDAL.SelectAllAccrSpecialCharges(dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
                result.message = General.messageModel.GetDataMessage;
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
                clsAccrSpecialCharges off = _activeDAL.SelectAccrSpecialChargesById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
                result.message = General.messageModel.GetDataMessage;
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("GetByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId")]
        public clsResult GetByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId(int accrId,int accreditationStandardId,int typeOfInvoiceChargeId, string dbName)
        {
            try
            {
                List<clsAccrSpecialCharges> offList = _activeDAL.SelectAccrSpecialChargesByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId(accrId,accreditationStandardId,typeOfInvoiceChargeId, dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
                result.message = General.messageModel.GetDataMessage;
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
        public clsResult Post([FromBody] clsAccrSpecialCharges value)
        {
            try
            {
                if (value != null)
                {

                    if (value.id > 0)
                    {
                        //Update Query
                        _activeDAL.UpdateAccrSpecialCharges(ValidateData(value));
                        result.id = value.id;
                        result.message = General.messageModel.updateMessage;
                        result.isSuccess = true;
                    }
                    else
                    {
                        // Insert Query
                        int Id = _activeDAL.InsertAccrSpecialCharges(ValidateData(value));
                        result.id = Id;
                        result.message = General.messageModel.insertMessage;
                        result.isSuccess = true;
                    }
                    List<clsAccrSpecialCharges> offList = _activeDAL.SelectAccrSpecialChargesByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId(value.accrId, value.accreditationStandardId, value.typeOfInvoiceChargeId, value.dbName);
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
        [HttpDelete("{id}")]
        public clsResult Delete(int id,string dbName)
        {
            try
            {
            if (id > 0)
            {
                _activeDAL.ActiveFalseForDeleteAccrSpecialChargesById(id, dbName);
                result.id = id;
                result.message = General.messageModel.deleteMessage;
                result.isSuccess = true;
            }
            else
            {
                result.id = id;
                result.message = General.messageModel.idEmpMessage;
                result.isSuccess = false;
            }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private clsAccrSpecialCharges ValidateData(clsAccrSpecialCharges value)
        {
            //Add Logic For Insert And Update
            clsAccrSpecialCharges obj = new clsAccrSpecialCharges();
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
