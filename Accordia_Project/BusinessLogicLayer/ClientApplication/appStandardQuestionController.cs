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
    public class appStandardQuestionController : ControllerBase
    {
        appStandardQuestionDAL _activeDAL = new appStandardQuestionDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppStandardQuestion> offList = _activeDAL.SelectAllAppStandardQuestion(dbName);
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
                clsAppStandardQuestion off = _activeDAL.SelectAppStandardQuestionById(id,dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] clsAppStandardQuestion value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAppStandardQuestion(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAppStandardQuestion(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsAppStandardQuestion ValidateData(clsAppStandardQuestion value)
        {
            //Add Logic For Insert And Update
            clsAppStandardQuestion obj = new clsAppStandardQuestion();
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
