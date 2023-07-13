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
    public class accreditationOfficeContactPersonsController : ControllerBase
    {
        accreditationOfficeContactPersonsDAL _activeDAL = new accreditationOfficeContactPersonsDAL();

        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccreditationOfficeContactPersons> offList = _activeDAL.SelectAllAccreditationOfficeContactPersons(dbName);
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
                clsAccreditationOfficeContactPersons off = _activeDAL.SelectAccreditationOfficeContactPersonsById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByAccreditationId/{accreditationId}")]
        public clsResult GetByAccreditationId(int accreditationId, string dbName)
        {
            try
            {
                List<clsAccreditationOfficeContactPersons> offList = _activeDAL.SelectAccreditationOfficeContactPersonsByAccreditationId(accreditationId, dbName).ToList();
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
        public clsResult Post([FromBody] clsAccreditationOfficeContactPersons value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccreditationOfficeContactPersons(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                    List<clsAccreditationOfficeContactPersons> offList = _activeDAL.SelectAccreditationOfficeContactPersonsByAccreditationId(value.accreditationId, value.dbName).ToList();
                    result.Data = new List<object>();
                    result.Data.AddRange(offList);
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccreditationOfficeContactPersons(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    List<clsAccreditationOfficeContactPersons> offList = _activeDAL.SelectAccreditationOfficeContactPersonsByAccreditationId(value.accreditationId, value.dbName).ToList();
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

        private clsAccreditationOfficeContactPersons ValidateData(clsAccreditationOfficeContactPersons value)
        {
            //Add Logic For Insert And Update
            clsAccreditationOfficeContactPersons obj = new clsAccreditationOfficeContactPersons();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
                if (value.otherContactPersonCategory != null && value.otherContactPersonCategory != "")
                {
                    value.contactPersonCategoryId = CheckAndInsertAccreditationContactPersonCategory(value.otherContactPersonCategory, value.dbName, value.userId);
                }
            }
            else
            {
                if (value.otherContactPersonCategory != null && value.otherContactPersonCategory != "")
                {
                    value.contactPersonCategoryId = CheckAndInsertAccreditationContactPersonCategory(value.otherContactPersonCategory, value.dbName, value.userId);
                }
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
            }
            obj = value;
            return obj;
        }
        private int CheckAndInsertAccreditationContactPersonCategory(string accreditationContactPersonCategory, string dbName, int userId)
        {
            accreditationContactPersonCategoryDAL _activeDAL = new accreditationContactPersonCategoryDAL();
            if (_activeDAL.IsAccreditationContactPersonCategoryExist(accreditationContactPersonCategory, dbName) == false)
            {
                clsAccreditationContactPersonCategory objContactPersonCategory = new clsAccreditationContactPersonCategory();
                objContactPersonCategory.dbName = dbName;
                objContactPersonCategory.contactPersonCategory = accreditationContactPersonCategory;
                objContactPersonCategory.userId = userId;
                objContactPersonCategory.createdBy = userId;
                objContactPersonCategory.createdOn = DateTime.Now;
                return _activeDAL.InsertAccreditationContactPersonCategory(objContactPersonCategory);
            }
            else
            {
                return _activeDAL.SelectAccreditationContactPersonCategoryByName(accreditationContactPersonCategory, dbName).FirstOrDefault().id;
            }
        }
        [HttpDelete("{id}")]
        public clsResult Delete(int id, string dbName)
        {
            try
            {
                if (id > 0)
                {
                    _activeDAL.ActiveFalseForDeletetblAccreditationOfficeContactPersonsById(id, dbName);
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
    }
}
