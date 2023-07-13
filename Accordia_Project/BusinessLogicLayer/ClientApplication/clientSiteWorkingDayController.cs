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
    public class clientSiteWorkingDayController : ControllerBase
    {
        clientSiteWorkingDayDAL _activeDAL = new clientSiteWorkingDayDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsClientSiteWorkingDay> offList = _activeDAL.SelectAllClientSiteWorkingDay(dbName);
                if (offList != null && offList.Count > 0)
                {
                    clientSiteHolidayDAL siteHolidayDAL = new clientSiteHolidayDAL();
                    foreach (var item in offList)
                    {
                        List<clsClientSiteHoliday> listHoliday = siteHolidayDAL.SelectClientSiteHolidayByClientSiteId(item.clientSiteId, dbName);
                        item.clientSiteHoliday = new List<clsClientSiteHoliday>();
                        foreach (var mapItem in listHoliday)
                        {
                            clsClientSiteHoliday obj = new clsClientSiteHoliday();
                            obj.id = mapItem.id;
                            obj.clientSiteId = mapItem.clientSiteId;
                            obj.weekDayId = mapItem.weekDayId;
                            item.clientSiteHoliday.Add(obj);
                        }
                    }
                }
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
                List<clsClientSiteWorkingDay> offList = _activeDAL.SelectClientSiteWorkingDayClientSiteId(clientSiteId, dbName);
                if (offList != null && offList.Count > 0)
                {
                    clientSiteHolidayDAL siteHolidayDAL = new clientSiteHolidayDAL();
                    foreach (var item in offList)
                    {
                        item.clientSiteId = clientSiteId;
                       List<clsClientSiteHoliday> listHoliday = siteHolidayDAL.SelectClientSiteHolidayByClientSiteId(item.clientSiteId, dbName);
                        item.clientSiteHoliday = new List<clsClientSiteHoliday>();
                        foreach (var mapItem in listHoliday)
                        {
                            clsClientSiteHoliday obj = new clsClientSiteHoliday();
                            obj.id = mapItem.id;
                            obj.clientSiteId = mapItem.clientSiteId;
                            obj.weekDayId = mapItem.weekDayId;
                            obj.dayName = mapItem.dayName;
                            item.clientSiteHoliday.Add(obj);
                        }
                    }
                }
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
                clsClientSiteWorkingDay off = _activeDAL.SelectClientSiteWorkingDayById(id, dbName).FirstOrDefault();
                if (off != null && off.id > 0)
                {
                    clientSiteHolidayDAL siteHolidayDAL = new clientSiteHolidayDAL();               
                        List<clsClientSiteHoliday> listHoliday = siteHolidayDAL.SelectClientSiteHolidayByClientSiteId(off.clientSiteId, dbName);
                        off.clientSiteHoliday = new List<clsClientSiteHoliday>();
                        foreach (var mapItem in listHoliday)
                        {
                            clsClientSiteHoliday obj = new clsClientSiteHoliday();
                            obj.id = mapItem.id;
                            obj.clientSiteId = mapItem.clientSiteId;
                            obj.weekDayId = mapItem.weekDayId;
                            off.clientSiteHoliday.Add(obj);
                        }
                    
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
        public clsResult Post([FromBody] clsClientSiteWorkingDay value)
        {
            try
            {
          
                        if (value.id > 0)
                        {
                            //Update Query
                            _activeDAL.UpdateClientSiteWorkingDay(ValidateData(value));
                           if (value.clientSiteHoliday != null && value.clientSiteHoliday.Count > 0)
                           {
                               DeleteAndInsertClientSiteHoliday(value);
                           }
                    result.id = value.id;
                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                        }
                        else
                        {
                            // Insert Query
                            int Id = _activeDAL.InsertClientSiteWorkingDay(ValidateData(value));
                           if (value.clientSiteHoliday != null && value.clientSiteHoliday.Count > 0)
                             {
                             value.id = Id;
                             DeleteAndInsertClientSiteHoliday(value);
                              }
                              result.id = Id;
                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                        }
                    
                    if (value.clientSiteId > 0)
                    {
                        List<clsClientSiteWorkingDay> offList = _activeDAL.SelectClientSiteWorkingDayClientSiteId(value.clientSiteId, value.dbName);
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

        private clsClientSiteWorkingDay ValidateData(clsClientSiteWorkingDay value)
        {
            //Add Logic For Insert And Update
            clsClientSiteWorkingDay obj = new clsClientSiteWorkingDay();
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
        private void DeleteAndInsertClientSiteHoliday(clsClientSiteWorkingDay obj)
        {
            clientSiteHolidayDAL mapDAL = new clientSiteHolidayDAL();
            mapDAL.deleteClientSiteHolidayByClientSiteId(obj.clientSiteId, obj.dbName);
            foreach (var item in obj.clientSiteHoliday)
            {
                clsClientSiteHoliday objMap = new clsClientSiteHoliday();
                objMap.createdBy = obj.userId;
                objMap.createdOn = DateTime.Now;
                objMap.active = true;
                objMap.clientSiteId = obj.clientSiteId;
                objMap.weekDayId = item.weekDayId;
                mapDAL.InsertClientSiteHoliday(objMap);
            }
        }
    }
}
