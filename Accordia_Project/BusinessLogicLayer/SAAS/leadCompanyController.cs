using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accordia_Project.BusinessLogicLayer.General;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    [Route("api/[controller]")]
    [ApiController]
    public class leadCompanyController : ControllerBase
    {
        leadCompanyDAL _activeDAL = new leadCompanyDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsLeadCompany> offList = _activeDAL.SelectAllLeadCompany(dbName);
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
                clsLeadCompany off = _activeDAL.SelectLeadCompanyById(id, dbName).FirstOrDefault();
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
        [HttpGet("CheckLeadCompanyNameExist/{companyName}")]
        public bool CheckLeadCompanyNameExist(string companyName)
        {
            return _activeDAL.IsLeadCompanyNameAlreadyExist(companyName);

        }
        [HttpGet("CheckLeadCompanyEmailExist/{leadEmailAddress}")]
        public bool CheckLeadCompanyEmailExist(string leadEmailAddress)
        {
            return _activeDAL.IsLeadCompanyEmailAlreadyExist(leadEmailAddress);

        }
        [HttpPost]
        public clsResult Post([FromBody] clsLeadCompany value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateLeadCompany(ValidateData(value));
                    result.id = value.id;
                    result.message = messageModel.updateMessage;

                }
                else
                {
                    // Insert Query
                    int Id =ValidateData(value).id;
                    result.id = Id;
                    result.message = messageModel.insertMessage;
                }
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        [HttpPost("UpdateLeadStatusByLeadCompanyId")]
        public clsResult UpdateLeadStatusByLeadCompanyId(int leadCompanyId , int leadStatusId ,int userId)
        {
            try
            {
                clsLeadCompany obj = new clsLeadCompany();
                obj.id = leadCompanyId;
                obj.leadStatusId = leadStatusId;
                obj.modifiedBy = userId;
                obj.modifiedOn = DateTime.Now;
                //Update Query
                _activeDAL.UpdateLeadStatusByLeadCompanyId(obj);
                result.id = leadCompanyId;
                result.message = "Update Successfully";

                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private clsLeadCompany ValidateData(clsLeadCompany objLead)
        {
            //Add Logic For Insert And Update
            clsLeadCompany obj = new clsLeadCompany();
            if (objLead.id > 0)
            {
                objLead.modifiedBy = objLead.userId;
                objLead.modifiedOn = DateTime.Now;
            }
            else
            {
                objLead.leadStatusId = 1;
                objLead.active = true;
                objLead.createdBy = objLead.userId;
                objLead.createdOn = DateTime.Now;
                objLead.id = _activeDAL.InsertLeadCompany(objLead);
                if (objLead.id > 0)
                {
                    CreateLeadUser(objLead);     
                }
            }
            obj = objLead;
            return obj;
        }
        private bool CreateLeadUser(clsLeadCompany objLeadComp)
        {
            clsUserLogin objUser = new clsUserLogin();
            clsUserLogin objuserLogin = new clsUserLogin();
            objuserLogin.leadCompanyId = objLeadComp.id;
            objuserLogin.companyId = 0;
            objuserLogin.officeId = 0;
            objuserLogin.designationId = 0;

            objuserLogin.createdBy = 0;
            objuserLogin.createdOn = DateTime.Now;
            objuserLogin.userName = objLeadComp.leadUserName;
            objuserLogin.userCode = objLeadComp.leadUserName + "@" + objLeadComp.leadCompanyName;
            objuserLogin.userPassword = objLeadComp.leadUserPassword != null && objLeadComp.leadUserPassword != "" ? objLeadComp.leadUserPassword  : objLeadComp.leadCompanyName+"@123";
            objuserLogin.userEmail = objLeadComp.leadEmailAddress;
            objuserLogin.dbName = "";
            objuserLogin.lastLogin = DateTime.Now;
            objuserLogin.isLogin = false;
            objuserLogin.approvalStatus = "Approved";
            objuserLogin.approvalDate = DateTime.Now;
            objuserLogin.approvalBy = 0;
            objuserLogin.active = true;
            userLoginDAL loginDAL = new userLoginDAL();
            if(loginDAL.InsertUserLogin(objuserLogin, null) > 0)
            {
                EmailSend(objuserLogin.userEmail,objuserLogin.userPassword);
                return true;
            }
            else { return false; }
        }
        private void EmailSend(string userEmail,string userPassword)
        {
            emailSendModel emailSendModel = new emailSendModel();
          string mailbody =  emailSendModel.PopulateWelcomeUserEmailBody(userEmail, userPassword, "www.google.com");
            emailSendModel.EmailSend(userEmail,mailbody, "LeadUserEmail");
        }
    }
}
