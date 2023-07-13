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
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class siteInfrastructureController : ControllerBase
    {
        siteInfrastructureDAL _activeDAL = new siteInfrastructureDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsSiteInfrastructure> offList = _activeDAL.SelectAllSiteInfrastructure(dbName);
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
        [HttpGet("GetByClientSiteId/{clientSiteId}")]
        public clsResult GetByClientSiteId(int clientSiteId,string dbName)
        {
            try
            {
                List<clsSiteInfrastructure> offList = _activeDAL.SelectSiteInfrastructureByClientSiteId(clientSiteId, dbName);
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
                clsSiteInfrastructure off = _activeDAL.SelectSiteInfrastructureById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] List<clsSiteInfrastructure> value)
        {
            try
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        if (item.id > 0)
                        {
                            //Update Query
                            _activeDAL.UpdateSiteInfrastructure(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // Insert Query
                            int Id = _activeDAL.InsertSiteInfrastructure(ValidateData(item));
                            result.id = Id;
                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                        }
                    }
                    if (value[0].clientSiteId > 0)
                    {
                        List<clsSiteInfrastructure> offList = _activeDAL.SelectSiteInfrastructureByClientSiteId(value[0].clientSiteId, value[0].dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                    }
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        } 
        [HttpPost("PostForReview")]
        public clsResult PostForReview([FromBody] List<clsSiteInfrastructure> value)
        {
            try
            {
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        if (item.id > 0)
                        {
                            //Update Query
                            _activeDAL.UpdateSiteInfrastructureForReview(ValidateData(item));
                            result.id = item.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            result.message = General.messageModel.idEmpMessage;
                            result.isSuccess = false;
                            return result;
                        }
                    }
                    if (value[0].clientSiteId > 0)
                    {
                        List<clsSiteInfrastructure> offList = _activeDAL.SelectSiteInfrastructureByClientSiteId(value[0].clientSiteId, value[0].dbName);
                        result.Data = new List<object>();
                        result.Data.AddRange(offList);
                    }
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsSiteInfrastructure ValidateData(clsSiteInfrastructure value)
        {
            //Add Logic For Insert And Update
            clsSiteInfrastructure obj = new clsSiteInfrastructure();
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
