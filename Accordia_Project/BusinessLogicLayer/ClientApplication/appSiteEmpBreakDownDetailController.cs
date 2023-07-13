using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
   // [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class appSiteEmpBreakDownDetailController : ControllerBase
    {
        appSiteEmpBreakDownDetailDAL _activeDAL = new appSiteEmpBreakDownDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppSiteEmpBreakDownDetail> offList = _activeDAL.SelectAllAppSiteEmpBreakDownDetail(dbName);
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
                clsAppSiteEmpBreakDownDetail off = _activeDAL.SelectAppSiteEmpBreakDownDetailById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByClientSiteIdAndAppId")]
        public clsResult GetByClientSiteIdAndAppId(int appId,int clientSiteId, string dbName)
        { 
            try
            {
                List<clsAppSiteEmpBreakDownDetail> offList = _activeDAL.SelectAppSiteEmpBreakDownDetailByClientSiteIdAndAppId(appId,clientSiteId, dbName);
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
        public clsResult Post([FromBody] List<clsAppSiteEmpBreakDownDetail> value)
        {
            try
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        List<clsAppSiteEmpBreakDownDetail> list = _activeDAL.SelectAppSiteEmpBreakDownDetailByClientSiteIdAndAppId(item.appId, item.clientSiteId, item.dbName);
                        if (list != null)
                        {
                            foreach (var listItem in list)
                            {
                                if (item.isLocal == listItem.isLocal)
                                {
                                    item.id = listItem.id;
                                }
                                else if (item.isMigrant == listItem.isMigrant)
                                {
                                    item.id = listItem.id;
                                }
                            }
                        }
                        if (item.id > 0)
                        {
                            //Update Query
                            _activeDAL.UpdateAppSiteEmpBreakDownDetail(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // Insert Query
                            int Id = _activeDAL.InsertAppSiteEmpBreakDownDetail(ValidateData(item));
                            result.id = Id;
                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                        }
                    }
                    List<clsAppSiteEmpBreakDownDetail> offList = _activeDAL.SelectAppSiteEmpBreakDownDetailByClientSiteIdAndAppId(value[0].appId, value[0].clientSiteId, value[0].dbName);
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

        private clsAppSiteEmpBreakDownDetail ValidateData(clsAppSiteEmpBreakDownDetail value)
        {
            //Add Logic For Insert And Update
            clsAppSiteEmpBreakDownDetail obj = new clsAppSiteEmpBreakDownDetail();
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
