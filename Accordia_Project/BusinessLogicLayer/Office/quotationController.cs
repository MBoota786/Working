﻿using DataAccessLayer;
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
    public class quotationController : ControllerBase
    {
        quotationDAL _activeDAL = new quotationDAL();

        [HttpGet]
        public List<clsQuotation> Get(string dbName)
        {
            List<clsQuotation> offList = _activeDAL.SelectAllQuotation(dbName);
            return offList;
        }


        [HttpGet("{id}")]
        public clsQuotation Get(int id, string dbName)
        {
            clsQuotation off = _activeDAL.SelectQuotationById(id, dbName).FirstOrDefault();
            return off;
        }


        [HttpPost]
        public string Post([FromBody] clsQuotation value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateQuotation(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertQuotation(ValidateData(value));
                return "Insert";
            }
        }

        private clsQuotation ValidateData(clsQuotation value)
        {
            //Add Logic For Insert And Update
            clsQuotation obj = new clsQuotation();
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
