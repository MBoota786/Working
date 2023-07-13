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
    public class siteDormitoriesController : ControllerBase
    {
        siteDormitoriesDAL _activeDAL = new siteDormitoriesDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsSiteDormitories> offList = _activeDAL.SelectAllSiteDormitories(dbName);
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
                clsSiteDormitories off = _activeDAL.SelectSiteDormitoriesById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByClientSiteId/{clientSiteId}")]
        public clsResult GetByClientSiteId(int clientSiteId,string dbName)
        { 
            try
            {
                List<clsSiteDormitories> offList = _activeDAL.SelectSiteDormitoriesByClientSiteId(clientSiteId, dbName);
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
        public clsResult Post([FromBody] clsSiteDormitories value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateSiteDormitories(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    //Insert Query
                    int Id = _activeDAL.InsertSiteDormitories(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                List<clsSiteDormitories> off = _activeDAL.SelectSiteDormitoriesByClientSiteId(value.clientSiteId, value.dbName);
                result.Data = new List<object>();
                result.Data.AddRange(off);

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsSiteDormitories ValidateData(clsSiteDormitories value)
        {
            //Add Logic For Insert And Update
            clsSiteDormitories obj = new clsSiteDormitories();
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
