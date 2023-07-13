using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office.Master
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class contactPersonsUsersRoleMapController : ControllerBase
    {
        contactPersonsUsersRoleMapDAL _activeDAL = new contactPersonsUsersRoleMapDAL();
        clsResult result = new clsResult();
        // GET: api/<officeTypeController>
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsContactPersonsUsersRoleMap> offList = _activeDAL.SelectAllContactPersonsUsersRoleMap(dbName);
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

        // GET api/<officeTypeController>/5
        [HttpGet("{ContactPersonsUsersId}")]
        public clsResult Get(int ContactPersonsUsersId, string dbName)
        {
            try
            {
                clsContactPersonsUsersRoleMap off = _activeDAL.SelectContactPersonsUsersRoleMapByContactPersonsUsersId(ContactPersonsUsersId, dbName).FirstOrDefault();
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

        // POST api/<officeTypeController>
        [HttpPost]
        public clsResult Post([FromBody] clsContactPersonsUsersRoleMap value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateContactPersonsUsersRoleMap(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertContactPersonsUsersRoleMap(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
     
        private clsContactPersonsUsersRoleMap ValidateData(clsContactPersonsUsersRoleMap value)
        {
            //Add Logic For Insert And Update
            clsContactPersonsUsersRoleMap obj = new clsContactPersonsUsersRoleMap();
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
