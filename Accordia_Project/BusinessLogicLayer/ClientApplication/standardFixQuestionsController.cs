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
    public class standardFixQuestionsController : ControllerBase
    {
        standardFixQuestionsDAL _activeDAL = new standardFixQuestionsDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsStandardFixQuestions> offList = _activeDAL.SelectAllStandardFixQuestions(dbName);
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
                clsStandardFixQuestions off = _activeDAL.SelectStandardFixQuestionsById(id, dbName).FirstOrDefault();
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
        [HttpGet("GetByByAppIdAndClientSiteIdAndAccreditationBodyStandardId")]
        public clsResult GetByByAppIdAndClientSiteIdAndAccreditationBodyStandardId(int appId,int clientSiteId,int accreditationStandardId,string dbName)
        { 
            try
            {
                List<clsStandardFixQuestions> offList = _activeDAL.SelectStandardFixQuestionsByAppIdAndClientSiteIdAndAccreditationBodyStandardId(appId,clientSiteId,accreditationStandardId, dbName);
                result.Data = new List<object>();
                offList = SetNameCheckBox(offList);
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
        [HttpGet("GetByByAppIdAndClientSiteId")]
        public clsResult GetByByAppIdAndClientSiteId(int appId,int clientSiteId,string dbName)
        { 
            try
            {
                List<clsStandardFixQuestions> offList = _activeDAL.SelectStandardFixQuestionsByAppIdAndClientSiteId(appId,clientSiteId, dbName);
                result.Data = new List<object>();
                offList = SetNameCheckBox(offList);
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
        private List<clsStandardFixQuestions> SetNameCheckBox(List<clsStandardFixQuestions> list)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.isSmetaFullFollowup)
                    {
                        item.auditType = "isSmetaFullFollowup";
                        item.auditTypeId = 4;
                    }
                    else if (item.isSmetaFullInitial)
                    {
                        item.auditType = "isSmetaFullInitial";
                        item.auditTypeId = 1;
                    }
                    else if (item.isSmetaPartialFollowup)
                    {
                        item.auditType = "isSmetaPartialFollowup";
                        item.auditTypeId = 5;
                    }
                    else if (item.isSmetaPeriodic)
                    {
                        item.auditType = "isSmetaPeriodic";
                        item.auditTypeId = 2;
                    }
                    else if (item.isWrapFirstTimeAudit)
                    {
                        item.auditType = "isWrapFirstTimeAudit";
                        item.auditTypeId = 6;
                    }
                    else if (item.isWrapReCertification)
                    {
                        item.auditType = "isWrapReCertification";
                        item.auditTypeId = 7;
                    }
                    else if (item.isLapsedAudit)
                    {
                        item.auditType = "isLapsedAudit";
                        item.auditTypeId = 8;
                    }
                    if (item.isSmetaRegisterSedex)
                    {
                        item.smetaRegSedex = "isSmetaRegisterSedex";
                    }
                    if(item.isWrapOpenPcaFinded)
                    {
                        item.wrapOpenPca = "isWrapOpenPcaFinded";
                    }
                    if (item.isWrapPcaConductedFacility)
                    {
                        item.WrapPca = "isWrapPcaConductedFacility";
                    }     if (item.isCtpatFullInitial)
                    {
                        item.CtpatFullInitial = "isCtpatFullInitial";
                        item.auditTypeId = 12;
                    }
                }
            }
            return list;
        }
        [HttpPost]
        public clsResult Post([FromBody] List<clsStandardFixQuestions> value)
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
                        _activeDAL.UpdateStandardFixQuestions(ValidateData(item));
                        result.id = item.id;
                        result.message = General.messageModel.updateMessage;
                        result.isSuccess = true;
                    }
                    else
                    {
                        // Insert Query
                        int Id = _activeDAL.InsertStandardFixQuestions(ValidateData(item));
                        result.id = Id;
                        result.message = General.messageModel.insertMessage;
                        result.isSuccess = true;
                    }
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
        [HttpPost("PostUpdateForReview")]
        public clsResult PostUpdateForReview([FromBody] clsStandardFixQuestions item)
        {
            try
            {

                if (item.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateStandardFixQuestionsForReview(ValidateData(item));
                    result.id = item.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    result.message = General.messageModel.idEmpMessage;
                    result.isSuccess = true;
                }     
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsStandardFixQuestions ValidateData(clsStandardFixQuestions value)
        {
            //Add Logic For Insert And Update
            clsStandardFixQuestions obj = new clsStandardFixQuestions();
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
