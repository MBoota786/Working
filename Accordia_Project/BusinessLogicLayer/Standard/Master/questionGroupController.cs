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
    public class questionGroupController : ControllerBase
    {
        questionGroupDAL _activeDAL = new questionGroupDAL();
      
        [HttpGet]
        public List<clsQuestionGroup> Get(string dbName)
        {
            List<clsQuestionGroup> offList = _activeDAL.SelectAllQuestionGroup(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsQuestionGroup Get(int id, string dbName)
        {
            clsQuestionGroup off = _activeDAL.SelectQuestionGroupById(id, dbName).FirstOrDefault();
            return off;
        }
        [HttpPost]
        public string Post([FromBody] clsQuestionGroup value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuestionGroup(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuestionGroup(ValidateData(value));
                return "Insert";
            }
        }

        private clsQuestionGroup ValidateData(clsQuestionGroup value)
        {
            //Add Logic For Insert And Update
            clsQuestionGroup obj = new clsQuestionGroup();
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
