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
    public class appSiteShiftsController : ControllerBase
    {
        appSiteShiftsDAL _activeDAL = new appSiteShiftsDAL();
        clsResult result = new clsResult();
        //DayMap
        appSiteShiftsDayMapController mapController = new appSiteShiftsDayMapController();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAppSiteShifts> offList = _activeDAL.SelectAllAppSiteShifts(dbName);
                foreach (var item in offList)
                {
                    item.DayMap = new List<clsAppSiteShiftsDayMap>();
                    item.DayMap = mapController.GetByAppSiteShiftsId(item.id, dbName).Data.Cast<clsAppSiteShiftsDayMap>().ToList();
                }
                result.Data = new List<object>();
                result.Data.AddRange(offList);
                result.message = General.messageModel.GetDataMessage;
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
        public clsResult GetById(int id,string dbName)
        {
            try
            {
                clsAppSiteShifts offList = _activeDAL.SelectAppSiteShiftsById(id,dbName).FirstOrDefault();
                if (offList != null)
                {

                    offList.DayMap = new List<clsAppSiteShiftsDayMap>();
                    offList.DayMap = mapController.GetByAppSiteShiftsId(offList.id, dbName).Data.Cast<clsAppSiteShiftsDayMap>().ToList();
                }
                result.Data = new List<object>();
                result.Data.Add(offList);
                result.isSuccess = true;
                result.message = General.messageModel.GetDataMessage;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }


        [HttpGet("GetByAppIdClientSiteId")]
        public clsResult GetByAppIdClientSiteId(int appId,int clientSiteId,string dbName)
        {
            try
            {
                List<clsAppSiteShifts> activeList = _activeDAL.SelectAppSiteShiftsByAppIdClientSiteId(appId, clientSiteId, dbName);
                foreach (var item in activeList)
                {
                    item.DayMap = new List<clsAppSiteShiftsDayMap>();
                    item.DayMap = mapController.GetByAppSiteShiftsId(item.id, dbName).Data.Cast<clsAppSiteShiftsDayMap>().ToList();
                }
                result.Data = new List<object>();
                result.Data.AddRange(activeList);
                result.isSuccess = true;
                result.message = General.messageModel.GetDataMessage;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
      
        [HttpPost]
        public clsResult Post([FromBody] clsAppSiteShifts value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAppSiteShifts(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAppSiteShifts(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                foreach (var item in value.DayMap)
                {
                    item.dbName = value.dbName;
                    item.appSiteShiftsId = result.id;
                    item.userId = value.userId;
                }
                if (value.DayMap != null)
                {
                    mapController.Post(value.DayMap);
                }
                List<clsAppSiteShifts> activeList = _activeDAL.SelectAppSiteShiftsByAppIdClientSiteId(value.appId, value.clientSiteId, value.dbName);
                foreach (var item in activeList)
                {
                    item.DayMap = new List<clsAppSiteShiftsDayMap>();
                    item.DayMap = mapController.GetByAppSiteShiftsId(item.id, value.dbName).Data.Cast<clsAppSiteShiftsDayMap>().ToList();
                }
                result.Data = new List<object>();
                result.Data.AddRange(activeList);
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsAppSiteShifts ValidateData(clsAppSiteShifts value)
        {
            //Add Logic For Insert And Update
            clsAppSiteShifts obj = new clsAppSiteShifts();
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
