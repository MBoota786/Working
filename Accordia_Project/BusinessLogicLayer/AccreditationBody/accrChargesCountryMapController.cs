
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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class accrChargesCountryMapController : ControllerBase
    {
        accrChargesCountryMapDAL _activeDAL = new accrChargesCountryMapDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccrChargesCountryMap> offList = _activeDAL.SelectAllAccrChargesCountryMap(dbName);
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
                clsAccrChargesCountryMap off = _activeDAL.SelectAccrChargesCountryMapById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccrChargesAmountMapId/{accrChargesAmountMapId}")]
        public clsResult GetByAccrChargesAmountMapId(int accrChargesAmountMapId, string dbName)
        {
            try
            {
                List<clsAccrChargesCountryMap> offList = _activeDAL.SelectAccrChargesCountryMapByAccrChargesAmountMapId(accrChargesAmountMapId, dbName);
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
        public clsResult Post([FromBody] List<clsAccrChargesCountryMap> value)
        {
            try
            {
                if (value != null)
                {
                    int index = 0;
                    foreach (var item in value)
                    {
                        if (item.id > 0)
                        {
                            //Update Query
                            _activeDAL.UpdateAccrChargesCountryMap(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // For Delete Old
                            if (index == 0)
                            {
                                _activeDAL.DeleteAccrChargesCountryMapByAccrChargesAmountMapId(item.accrChargesAmountMapId, item.dbName);
                                index = 1;
                            }
                            // Insert Query
                            int Id = _activeDAL.InsertAccrChargesCountryMap(ValidateData(item));
                            result.id = Id;
                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsAccrChargesCountryMap ValidateData(clsAccrChargesCountryMap value)
        {
            //Add Logic For Insert And Update
            clsAccrChargesCountryMap obj = new clsAccrChargesCountryMap();
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
