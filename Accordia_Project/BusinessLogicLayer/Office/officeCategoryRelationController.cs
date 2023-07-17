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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeCategoryRelationController : ControllerBase
    {
        officeCategoryRelationDAL _activeDAL = new officeCategoryRelationDAL();
        clsResult result =new clsResult();
        officeScopeController _scopeController = new officeScopeController();
        officeStandardsController _standardController = new officeStandardsController();
        officeStandardsDAL _standardDAL = new officeStandardsDAL();

        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeCategoryRelation> offList = _activeDAL.SelectAllOfficeCategoryRelation(dbName);
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
                clsOfficeCategoryRelation off = _activeDAL.SelectOfficeCategoryRelationById(id, dbName).FirstOrDefault();
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
                clsOfficeCategoryRelation off = _activeDAL.SelectOfficeCategoryRelationByOfficeId(officeId, dbName).FirstOrDefault();
                //___ get officeStandard by office Id __
                if (off != null)
                {
                    off.listOfficeStandard = _standardDAL.SelectOfficeStandardsByOfficeId(officeId,null);
                }
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
        public clsResult Post([FromBody] clsOfficeCategoryRelation value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateOfficeCategoryRelation(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertOfficeCategoryRelation(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                //if (value.listOfficeScope != null)
                //{
                //    _scopeController.Post(value.listOfficeScope);
                //}
                if (value.listOfficeStandard != null)
                {
                    _standardController.Post(value.listOfficeStandard);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }


        private clsOfficeCategoryRelation ValidateData(clsOfficeCategoryRelation value)
        {
            //Add Logic For Insert And Update
            clsOfficeCategoryRelation obj = new clsOfficeCategoryRelation();
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
