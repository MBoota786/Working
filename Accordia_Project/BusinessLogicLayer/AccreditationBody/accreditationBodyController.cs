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
    public class accreditationBodyController : ControllerBase
    {
        accreditationBodyDAL _activeDAL = new accreditationBodyDAL();
        clsResult result = new clsResult();

        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccreditationBody> offList = _activeDAL.SelectAllAccreditationBody(dbName);
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
        [HttpGet("GetAllAccreditationForView")]
        public clsResult GetAllAccreditationForView(string dbName)
        {
            try
            {
                List<clsAccreditationBody> offList = _activeDAL.SelectAllAccreditationForView(dbName);
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
        [HttpGet("GetAccreditationNameForList")]
        public clsResult GetAccreditationNameForList(string dbName)
        {
            try
            {
                List<clsAccreditationBody> offList = _activeDAL.SelectAccreditationNameForList(dbName);
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
                clsAccreditationBody off = _activeDAL.SelectAccreditationBodyById(id,dbName).FirstOrDefault();
            //    off.accrAddress = new clsAccreditationAddresses();
            //    off.accrOfficeEmail = new clsAccreditationOfficeEmail();
             //   off.accrContactInformation = new clsAccreditationCompanyContactsInformation();
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
        public clsResult Post([FromBody] clsAccreditationBody value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccreditationBody(ValidateData(value));
                   // bool isOk = InsertAndUpdateAddressAndContactInfo(value.id, value);
                    result.id = value.id;
                    //if (!isOk)
                    //{
                    //    result.message = "Error In Data";
                    //    result.isSuccess = false;
                    //}
                    //else
                    //{
                        result.message = General.messageModel.insertMessage;
                        result.isSuccess = true;
                  //  }
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccreditationBody(ValidateData(value));
                  //  bool isOk = InsertAndUpdateAddressAndContactInfo(Id, value);
                    result.id = Id;
                    //if (!isOk)
                    //{
                    //    result.message = "Error In Data";
                    //    result.isSuccess = false;
                    //}
                    //else
                    //{
                        result.message = General.messageModel.insertMessage;
                        result.isSuccess = true;
                    //}
                
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        //private bool InsertAndUpdateAddressAndContactInfo(int id,clsAccreditationBody obj)
        //{
        //    try
        //    {
        //    accreditationAddressesController _address = new accreditationAddressesController();
        //    _address.Post(obj.accrAddress);
        //    accreditationCompanyContactsInformationController _contactInfo = new accreditationCompanyContactsInformationController();
        //    _contactInfo.Post(obj.accrContactInformation);
        //    accreditationOfficeEmailController _email = new accreditationOfficeEmailController();
        //   _email.Post(obj.accrOfficeEmail);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //     return false;
        //    }
        //}
        private clsAccreditationBody ValidateData(clsAccreditationBody value)
        {
            //Add Logic For Insert And Update
            clsAccreditationBody obj = new clsAccreditationBody();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
                if (value.accreditationOtherCategory != null && value.accreditationOtherCategory != "")
                {
                    value.accreditationCategoryId = CheckAndInsertAccreditationOtherCategory(value.accreditationOtherCategory, value.dbName, value.userId);
                }
            }
            else
            {
                value.active = true;
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
                if (value.accreditationOtherCategory != null && value.accreditationOtherCategory !="")
                {
                    value.accreditationCategoryId = CheckAndInsertAccreditationOtherCategory(value.accreditationOtherCategory, value.dbName, value.userId);
                }
            }
            obj = value;
            return obj;
        }
        private int CheckAndInsertAccreditationOtherCategory(string accreditationOtherCategory, string dbName, int userId)
        {
            accreditationCategoryDAL _activeDAL = new accreditationCategoryDAL();
            if (_activeDAL.IsAccreditationOtherCategoryExist(accreditationOtherCategory, dbName) == false)
            {
                clsAccreditationCategory objBusiness = new clsAccreditationCategory();
                objBusiness.dbName = dbName;
                objBusiness.accreditationCategoryName = accreditationOtherCategory;
                objBusiness.userId = userId;
                objBusiness.createdBy = userId;
                objBusiness.createdOn = DateTime.Now;
                return _activeDAL.InsertAccreditationCategory(objBusiness);
            }
            else
            {
                return _activeDAL.SelectAccreditationOtherCategoryByName(accreditationOtherCategory, dbName).FirstOrDefault().id;
            }
        }
    }
}
