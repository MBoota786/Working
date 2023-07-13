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
 //   [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeTaxMasterController : ControllerBase
    {
        officeTaxMasterDAL _activeDAL = new officeTaxMasterDAL();
        officeTaxDetailDAL _dtlDAL = new officeTaxDetailDAL();
        officeTaxStateMapDAL _stateMapDAL = new officeTaxStateMapDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeTaxMaster> offList = _activeDAL.SelectAllOfficeTaxMaster(dbName);
                if (offList != null)
                {
                    offList = GetDetail(offList, dbName);
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
        [HttpGet("GetByOfficeId")]
        public clsResult GetByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsOfficeTaxMaster> offList = _activeDAL.SelectOfficeTaxMasterByOfficeId(officeId, dbName);
                if (offList != null)
                {
                    offList = GetDetail(offList, dbName);
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
        [HttpGet("GetForListByOfficeId")]
        public clsResult GetForListByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsOfficeTaxMaster> offList = _activeDAL.SelectOfficeTaxMasterForListByOfficeId(officeId, dbName);
                if (offList != null)
                {
                    offList = GetDetail(offList, dbName);
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
        [HttpGet("GetAuditFeeTaxByOfficeIdForQuotation")]
        public clsResult GetAuditFeeTaxByOfficeIdForQuotation(int officeId,int serviceFeeTypeId, string dbName)
        {
            try
            {
                List<clsOfficeTaxMaster> offList = _activeDAL.SelectOfficeTaxMasterByOfficeIdForQuotation(officeId,serviceFeeTypeId, dbName);
                if (offList != null)
                {
                    offList = GetDetail(offList, dbName);
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
                clsOfficeTaxMaster off = _activeDAL.SelectOfficeTaxMasterById(id, dbName).FirstOrDefault();
                if (off != null)
                {
                    off.officeTaxDetail = new List<clsOfficeTaxDetail>();
                    off.officeTaxDetail = _dtlDAL.SelectOfficeTaxDetailByOfficeTaxId(off.id, dbName).Where(x => x.active == true).ToList();
                    if (off.officeTaxDetail != null)
                    {
                     off.officeTaxDetail = GetStateMap(off.officeTaxDetail, dbName);
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
        private List<clsOfficeTaxDetail> GetStateMap(List<clsOfficeTaxDetail> list , string dbName)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    item.officeTaxStateMap = new List<clsOfficeTaxStateMap>();
                    item.officeTaxStateMap = _stateMapDAL.SelectOfficeTaxStateMapByOfficeTaxDetailId(item.id, dbName);
                }
            }
            return list;
        }
        private List<clsOfficeTaxMaster> GetDetail(List<clsOfficeTaxMaster> offList,string dbName)
        {
            if (offList != null)
            {
                foreach (var item in offList)
                {
                    item.officeTaxDetail = new List<clsOfficeTaxDetail>();
                    item.officeTaxDetail = _dtlDAL.SelectOfficeTaxDetailByOfficeTaxId(item.id, dbName).Where(x => x.active == true).ToList();
                }
            }
            return offList;
        }
        [HttpPost]
        public clsResult Post([FromBody] clsOfficeTaxMaster value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateOfficeTaxMaster(ValidateData(value));
                    InsertAndUpdateOfficeTaxDetail(value);
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertOfficeTaxMaster(ValidateData(value));
                    result.id = Id;
                    value.id = Id;
                    InsertAndUpdateOfficeTaxDetail(value);
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                List<clsOfficeTaxMaster> offList = _activeDAL.SelectOfficeTaxMasterByOfficeId(value.officeId,value.dbName);
                if (offList != null)
                {
                    offList = GetDetail(offList, value.dbName
                        );
                }
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private void InsertAndUpdateOfficeTaxDetail(clsOfficeTaxMaster obj)
        {
            try
            {
            if (obj.id  > 0)
            {
                if (obj.officeTaxDetail != null)
                {
                    foreach (var item in obj.officeTaxDetail)
                    {
                       if (item.id > 0)
                       {
                           item.officeTaxId = obj.id;
                           item.dbName = obj.dbName;
                           item.active = true;
                           item.createdBy = obj.userId;
                           item.userId = obj.userId;
                           item.createdOn = DateTime.Now;
                           _dtlDAL.UpdateOfficeTaxDetail(item);
                                DeleteAndOfficeTaxStateMap(item);

                       }
                       else
                       {
                           item.officeTaxId = obj.id;
                           item.dbName = obj.dbName;
                           item.active = true;
                           item.createdBy = obj.userId;
                           item.userId = obj.userId;
                           item.createdOn = DateTime.Now;
                           item.id = _dtlDAL.InsertOfficeTaxDetail(item);
                                DeleteAndOfficeTaxStateMap(item);
                       }
                    }
                }
            }

            }
            catch (Exception)
            {
                throw new ArgumentException("Error In Tax Detail.");
            }
        }
        private void DeleteAndOfficeTaxStateMap(clsOfficeTaxDetail obj)
        {

            try
            {
                if (obj.id > 0)
                {
                    _stateMapDAL.DeleteOfficeTaxStateMapByOfficeTaxDetailId(obj.id, obj.dbName);
                    if (obj.officeTaxStateMap != null)
                    {
                        foreach (var item in obj.officeTaxStateMap)
                        {
                            if (item.id > 0)
                            {
                                item.officeTaxDetailId = obj.id;
                                item.dbName = obj.dbName;
                                item.active = true;
                                item.createdBy = obj.userId;
                                item.createdOn = DateTime.Now;
                                _stateMapDAL.UpdateOfficeTaxStateMap(item);
                            }
                            else
                            {
                                item.officeTaxDetailId = obj.id;
                                item.dbName = obj.dbName;
                                item.active = true;
                                item.createdBy = obj.userId;
                                item.createdOn = DateTime.Now;
                                _stateMapDAL.InsertOfficeTaxStateMap(item);
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw new ArgumentException("Error In Tax Detail State Insert.");
            }
        }
        private void logOfficeTaxMaster(clsOfficeTaxMaster obj,string actionName,string dbName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = "Office Tax Master";
            _logsDAL.InsertLogs(clsLog);
        } 
        private void logOfficeTaxDetail(clsOfficeTaxMaster obj,string actionName,string dbName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.officeTaxDetail.ToString();
            clsLog.formName = "Office Tax Detail";
            _logsDAL.InsertLogs(clsLog);
        }
        private void logOfficeTaxState(clsOfficeTaxStateMap obj,string actionName,string dbName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = "Office Tax State";
            _logsDAL.InsertLogs(clsLog);
        }

        private clsOfficeTaxMaster ValidateData(clsOfficeTaxMaster value)
        {
            //Add Logic For Insert And Update
            clsOfficeTaxMaster obj = new clsOfficeTaxMaster();
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
