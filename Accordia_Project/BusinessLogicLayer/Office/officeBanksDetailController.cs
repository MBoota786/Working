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
    public class officeBanksDetailController : ControllerBase
    {
        officeBanksDetailDAL _activeDAL = new officeBanksDetailDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeBanksDetail> offList = _activeDAL.SelectAllOfficeBanksDetail(dbName);
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
                clsOfficeBanksDetail off = _activeDAL.SelectOfficeBanksDetailById(id, dbName).FirstOrDefault();
                if (off.id > 0)
                {
                    bankAccountPurposeMapDAL mapDAL = new bankAccountPurposeMapDAL();
                    List<clsBankAccountPurposeMap> list = mapDAL.SelectBankAccountPurposeMapByOfficeBankDetailsId(off.id, dbName);
                    off.bankPurposeList = new List<clsBankAccountPurpose>();
                    foreach (var mapItem in list)
                    {
                        clsBankAccountPurpose obj = new clsBankAccountPurpose();
                        obj.id = mapItem.bankAccountPurposeId;
                        obj.bankAccountPurpose = mapItem.bankAccountPurpose;
                        off.bankPurposeList.Add(obj);
                    }
                }
                result.Data = new List<object>();
                result.Data.Add(off);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

        [HttpGet("GetByOfficeId/{officeId}")]
        public clsResult GetByOfficeId(int officeId, string dbName)
        {
            try
            {
                List<clsOfficeBanksDetail> offList = _activeDAL.SelectOfficeBankDetailByOfficeId(officeId,dbName);
                if (offList != null && offList.Count > 0)
                {
                    bankAccountPurposeMapDAL mapDAL = new bankAccountPurposeMapDAL();
                    foreach (var item in offList)
                    {
                       List<clsBankAccountPurposeMap> list = mapDAL.SelectBankAccountPurposeMapByOfficeBankDetailsId(item.id, dbName);
                        item.bankPurposeList = new List<clsBankAccountPurpose>();
                        foreach (var mapItem in list)
                        {
                            clsBankAccountPurpose obj = new clsBankAccountPurpose();
                            obj.id = mapItem.bankAccountPurposeId;
                            obj.bankAccountPurpose = mapItem.bankAccountPurpose;
                            item.bankPurposeList.Add(obj);
                        }
                    }
                    
                }
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }
        [HttpPost]
        public clsResult Post([FromBody] clsOfficeBanksDetail value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateofficeBanksDetail(ValidateData(value));
                    result.id = value.id;
                    if (value.bankPurposeList.Count != null && value.bankPurposeList.Count > 0)
                    {
                        DeleteAndInsertBankPurpose(value);
                    }
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertofficeBanksDetail(ValidateData(value));
                    if (value.bankPurposeList.Count != null && value.bankPurposeList.Count > 0)
                    {
                        value.id = Id;
                        DeleteAndInsertBankPurpose(value);
                    }
                    result.id = Id;
                    result.message =  General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                result.Data = new List<object>();
                result.Data = GetByOfficeId(value.officeID, value.dbName).Data.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private void DeleteAndInsertBankPurpose(clsOfficeBanksDetail obj)
        {
            bankAccountPurposeMapDAL mapDAL = new bankAccountPurposeMapDAL();
            mapDAL.DeleteBankAccountPurposeMapByOfficeBankDetailsId(obj.id, obj.dbName);
            foreach (var item in obj.bankPurposeList)
            {
                clsBankAccountPurposeMap objMap = new clsBankAccountPurposeMap();
                objMap.createdBy = obj.userId;
                objMap.createdOn = DateTime.Now;
                objMap.active = true;
                objMap.bankAccountPurposeId = item.id;
                objMap.officeBankDetailsId = obj.id;
                mapDAL.InsertBankAccountPurposeMap(objMap);
            }  
        }
        private clsOfficeBanksDetail ValidateData(clsOfficeBanksDetail value)
        {
            //Add Logic For Insert And Update
            clsOfficeBanksDetail obj = new clsOfficeBanksDetail();
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
