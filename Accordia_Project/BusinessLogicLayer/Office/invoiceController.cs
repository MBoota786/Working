using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
  //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class invoiceController : ControllerBase
    {
        invoiceDAL _activeDAL = new invoiceDAL();
        clsResult result = new clsResult();

        [HttpGet("{id}")]
        public clsResult Get(int id, string dbName)
        {
            try
            {
                clsInvoice off = _activeDAL.SelectInvoiceById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByOfficeId")]
        public clsResult GetByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsInvoice> offList = _activeDAL.SelectInvoiceByOfficeId(officeId, dbName);
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
        public clsResult Post([FromBody] clsInvoice value)
        {
            try
            {
                if (value.id > 0)
                {
                    // Update Query
                    _activeDAL.UpdateInvoice(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertInvoice(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                List<clsInvoice> offList = _activeDAL.SelectInvoiceByOfficeId(value.officeId,value.dbName);
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
        private string InitializeCode(string dbName, int officeId)
        {
            string Code = "INV-001";
            try
            {
                officeStationaryPrefixDAL _offPrefixDAL = new officeStationaryPrefixDAL();
                clsOfficeStationaryPrefix objPre = new clsOfficeStationaryPrefix();
                objPre = _offPrefixDAL.SelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId(officeId, Convert.ToInt32(enumStationaryType.Invoice), dbName).FirstOrDefault();
                if (objPre == null)
                {
                    objPre = new clsOfficeStationaryPrefix();
                }
                string prefix = objPre.officeStationaryPrefix != "" ? objPre.officeStationaryPrefix : "INV";
                int startNum = objPre.startFrom > 0 ? objPre.startFrom : 1;
                int incrementNum = objPre.incrementNo > 0 ? objPre.incrementNo : 1;
                Code = prefix + "-" + startNum;
                string MaxCode = _activeDAL.GetMaxCode(dbName);
                if (!string.IsNullOrEmpty(MaxCode))
                {
                    var substring = MaxCode.Substring(MaxCode.LastIndexOf('-') + 1);
                    int Add = Convert.ToInt32(substring);
                    Add = Add + incrementNum;
                    substring = Regex.Replace(substring, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
                    Code = prefix + "-" + substring;
                }
                else
                {
                    // Code = "APP-1";
                }

                return Code;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private clsInvoice ValidateData(clsInvoice value)
        {
            //Add Logic For Insert And Update
            clsInvoice obj = new clsInvoice();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
            }
            else
            {
                value.code = InitializeCode(value.dbName,value.officeId); 
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
    }
}
