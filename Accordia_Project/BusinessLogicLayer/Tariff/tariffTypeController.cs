﻿using DataAccessLayer;
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
    public class tariffTypeController : ControllerBase
    {
        tariffTypeDAL _activeDAL = new tariffTypeDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsTariffType> offList = _activeDAL.SelectAllTariffType(dbName);
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
        [HttpGet("GetForDropDown")]
        public clsResult GetForDropDown(string dbName)
        {
            try
            {
                List<clsTariffType> offList = _activeDAL.SelectAllTariffType(dbName).Where(x => x.active == true).ToList();
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
                clsTariffType off = _activeDAL.SelectTariffTypeById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] clsTariffType value)
        {
            try
            {
                if (value.id > 0)
                {
                   // Update Query
                    _activeDAL.UpdateTariffType(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertTariffType(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                List<clsTariffType> offList = _activeDAL.SelectAllTariffType(value.dbName);
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

        private clsTariffType ValidateData(clsTariffType value)
        {
            //Add Logic For Insert And Update
            clsTariffType obj = new clsTariffType();
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
