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
    public class standardProcessController : ControllerBase
    {
        standardProcessDAL _activeDAL = new standardProcessDAL();
      
        [HttpGet]
        public List<clsStandardProcess> Get(string dbName)
        {
            List<clsStandardProcess> offList = _activeDAL.SelectAllStandardProcess(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsStandardProcess Get(int id, string dbName)
        {
            clsStandardProcess off = _activeDAL.SelectStandardProcessById(id, dbName).FirstOrDefault();
            return off;
        }
        //[HttpPost]
        //public string Post([FromBody] clsStandardProcess value)
        //{
        //    if (value.id > 0)
        //    {
        //        //Update Query
        //        _activeDAL.UpdateCheckList(ValidateData(value));
        //        return "Update";
        //    }
        //    else
        //    {
        //        // Insert Query
        //        _activeDAL.InsertCheckList(ValidateData(value));
        //        return "Insert";
        //    }
        //}

        //private clsStandardProcess ValidateData(clsStandardProcess value)
        //{
        //    //Add Logic For Insert And Update
        //    clsStandardProcess obj = new clsStandardProcess();
        //    if (value.id > 0)
        //    {
        //        value.modifiedBy = value.userId;
        //        value.modifiedOn = DateTime.Now;
        //    }
        //    else
        //    {
        //        value.active = true;
        //        value.createdBy = value.userId;
        //        value.createdOn = DateTime.Now;
        //    }
        //    obj = value;
        //    return obj;
        //}
    }
}
