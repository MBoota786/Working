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
    public class contactPersonsUsersController : ControllerBase
    {
        contactPersonsUsersDAL _activeDAL = new contactPersonsUsersDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public List<clsContactPersonsUsers> Get(string dbName)
        {
            List<clsContactPersonsUsers> offList = _activeDAL.SelectAllContactPersonsUsers(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsContactPersonsUsers Get(int id,string dbName)
        {
            clsContactPersonsUsers off = _activeDAL.SelectContactPersonsAndUsersById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpGet("GetByOfficeId/{officeId}")]
        public List<clsContactPersonsUsers> GetByOfficeId(int officeId,string dbName)
        {
            List<clsContactPersonsUsers> offList = _activeDAL.SelectContactPersonsAndUsersByOfficeId(officeId,dbName);
            contactPersonsUsersRoleMapDAL mapDAL = new contactPersonsUsersRoleMapDAL();
            if (offList.Count != null && offList.Count > 0)
            {
                foreach (var item in offList)
                {
                    item.roleList = new List<clsRole>();
                 List<clsContactPersonsUsersRoleMap> list =  mapDAL.SelectContactPersonsUsersRoleMapByContactPersonsUsersId(item.id, dbName).ToList();
                    foreach (var roleMap in list)
                    {
                        clsRole obj = new clsRole();
                        obj.id = roleMap.roleId;
                        obj.roleName = roleMap.roleName;
                        item.roleList.Add(obj);
                    }
                }
            }
            return offList;
        }

        [HttpPost]
        public clsResult Post([FromBody] clsContactPersonsUsers value)
        {
            try
            {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdateContactPersonsUsers(ValidateData(value));
                    if (value.roleList.Count != null && value.roleList.Count > 0)
                    {
                        DeleteAndInsertRole(value);
                    }
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
            else
            {
                // Insert Query
                int Id = _activeDAL.InsertContactPersonsUsers(ValidateData(value));
                    if (value.roleList.Count != null && value.roleList.Count > 0)
                    {
                        value.id = Id;
                        DeleteAndInsertRole(value);
                    }
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
                result.isSuccess = false;
            }
            return result;
        }
        private void DeleteAndInsertRole(clsContactPersonsUsers obj)
        {
            contactPersonsUsersRoleMapDAL mapDAL = new contactPersonsUsersRoleMapDAL();
            mapDAL.DeleteContactPersonsUsersRoleMapByContactPersonsUsersId(obj.id, obj.dbName);
            foreach (var item in obj.roleList)
            {
                clsContactPersonsUsersRoleMap objMap = new clsContactPersonsUsersRoleMap();
                objMap.createdBy = obj.userId;
                objMap.createdOn = DateTime.Now;
                objMap.active = true;
                objMap.roleId = item.id;
                objMap.contactPersonsUsersId = obj.id;
                mapDAL.InsertContactPersonsUsersRoleMap(objMap);
            }
        }

        private clsContactPersonsUsers ValidateData(clsContactPersonsUsers value)
        {
            //Add Logic For Insert And Update
            clsContactPersonsUsers obj = new clsContactPersonsUsers();
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
