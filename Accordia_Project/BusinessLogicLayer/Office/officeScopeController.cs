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
    public class officeScopeController : ControllerBase
    {
        officeScopeDAL _activeDAL = new officeScopeDAL();
        clsResult result =new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeScope> offList = _activeDAL.SelectAllOfficeScope(dbName);
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
                List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeById(id, dbName);
                if (offList != null)
                {
                    offList = GetMapData(offList, dbName);
                }
                result.Data = new List<object>();
                result.Data.Add(offList.FirstOrDefault());
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
        public clsResult GetByOfficeId(int id, string dbName)
        {
            try
            {
                List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeByOfficeId(id, dbName);
                if (offList != null)
                {
                    offList = GetMapData(offList, dbName);
                }
                result.Data = new List<object>();
                result.Data.Add(offList.FirstOrDefault());
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
        public clsResult Post([FromBody] List<clsOfficeScope> list)
        {
            try
            {
                if (list != null)
                {
                    foreach (var value in list)
                    {

                        if (value.id > 0)
                        {
                            //Update Query
                            _activeDAL.UpdateOfficeScope(ValidateData(value));
                            result.id = value.id;
                                    if (value.id > 0)
                                    {
                                        InsertMapStandardData(value);
                                        InsertMapStateData(value);
                                        InsertMapCityData(value);
                                    }
                                    result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                            log(value, "Update", value.dbName, "Office Scope");
                        }
                        else
                        {

                            // Insert Query
                            int Id = _activeDAL.InsertOfficeScope(ValidateData(value));
                            result.id = Id;
                            value.id = Id;
                            if (value.id > 0)
                            {
                                InsertMapStandardData(value);
                                InsertMapStateData(value);
                                InsertMapCityData(value);
                            }
                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                            log(value, "Insert", value.dbName, "Office Scope");
                        }
                    }
                    List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeByOfficeId(list[0].officeId, list[0].dbName);
                    if (offList != null)
                    {
                        offList = GetMapData(offList, list[0].dbName);
                    }
                    result.Data = new List<object>();
                    result.Data.Add(offList.FirstOrDefault());
                }
                else
                {
                    result.message = General.messageModel.listEmpMessage;
                    result.isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        private void log(clsOfficeScope obj, string actionName, string dbName, string formName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = formName;
            _logsDAL.InsertLogs(clsLog);
        }

        officeScopeStandardMapDAL standardMapDAL = new officeScopeStandardMapDAL();
        officeScopeStateMapDAL stateMapDAL = new officeScopeStateMapDAL();
        officeScopeCityMapDAL cityMapDAL = new officeScopeCityMapDAL();

        private void InsertMapStandardData(clsOfficeScope obj)
        {
            try
            {
            if (obj.id > 0)
            {
                if (obj.scopeStandard != null)
                {
                    standardMapDAL.DeleteOfficeScopeStandardMap(obj.id, obj.dbName);
                    foreach (var item in obj.scopeStandard)
                    {
                        item.dbName = obj.dbName;
                        item.createdBy = obj.userId;
                        item.createdOn = DateTime.Now;
                        item.officeScopeId = obj.id;
                        standardMapDAL.InsertOfficeScopeStandardMap(item);
                    }
                }
            }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error Throw From Office Scope Standard Insert.");
            }
        } 
        private void InsertMapStateData(clsOfficeScope obj)
        {
            try
            {
                if (obj.id > 0)
                {
                    if (obj.scopeStandard != null)
                    {
                        stateMapDAL.DeleteOfficeScopeStateMap(obj.id,obj.dbName);
                        foreach (var item in obj.scopeState)
                        {
                            item.dbName = obj.dbName;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            item.officeScopeId = obj.id;
                            stateMapDAL.InsertOfficeScopeStateMap(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error Throw From Office Scope State Insert.");
            }
        }
        private void InsertMapCityData(clsOfficeScope obj)
        {
            try
            {
            if (obj.id > 0)
            {
                if (obj.scopeStandard != null)
                {
                        cityMapDAL.DeleteOfficeScopeCityMap(obj.id, obj.dbName);
                        foreach (var item in obj.scopeCity)
                    {
                        item.dbName = obj.dbName;
                        item.createdBy = obj.userId;
                        item.createdOn = DateTime.Now;
                        item.officeScopeId = obj.id;
                        cityMapDAL.InsertOfficeScopeCityMap(item);
                    }
                }
            }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error Throw From Office Scope City Insert.");
            }
        }
        private List<clsOfficeScopeStandardMap> GetMapStandard(int officeScopeId,string dbName)
        {
            try
            {
                return standardMapDAL.spSelectOfficeScopeStandardMapByOfficeScopeId(officeScopeId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In Standard Get");
            }
        }   
        private List<clsOfficeScopeStateMap> GetMapState(int officeScopeId,string dbName)
        {
            try
            {
                return stateMapDAL.spSelectOfficeScopeStateMapByOfficeScopeId(officeScopeId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In State Province Map Get");
            }
        }    
        private List<clsOfficeScopeCityMap> GetMapCity(int officeScopeId,string dbName)
        {
            try
            {
                return cityMapDAL.spSelectOfficeScopeCityMapByOfficeScopeId(officeScopeId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In City Map Get");
            }
        }
        private List<clsOfficeScope> GetMapData(List<clsOfficeScope> list,string dbName)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    //item.id ==> officeScopeId
                    item.scopeStandard = new List<clsOfficeScopeStandardMap>();
                    item.scopeStandard = GetMapStandard(item.id, dbName);
                    item.scopeState = new List<clsOfficeScopeStateMap>();
                    item.scopeState = GetMapState(item.id, dbName);   
                    item.scopeCity = new List<clsOfficeScopeCityMap>();
                    item.scopeCity = GetMapCity(item.id, dbName);
                }
            }
            return list;
        }
        private clsOfficeScope ValidateData(clsOfficeScope value)
        {
            //Add Logic For Insert And Update
            clsOfficeScope obj = new clsOfficeScope();
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
