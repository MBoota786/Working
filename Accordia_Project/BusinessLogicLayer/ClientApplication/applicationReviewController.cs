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
    public class applicationReviewController : ControllerBase
    {
        applicationReviewDAL _activeDAL = new applicationReviewDAL();
        clsResult result = new clsResult();
        appReviewerCommentsController appRevCont = new appReviewerCommentsController();
        clsResult revCommentRes = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try 
            {
                List<clsApplicationReview> offList = _activeDAL.SelectAllApplicationReview(dbName);
                if (offList != null )
                {
                    foreach (var item in offList)
                    {
                        revCommentRes = appRevCont.GetByApplicationReviewId(item.id,dbName);
                        item.appReviewerComments = new List<clsAppReviewerComments>();
                        item.appReviewerComments = revCommentRes.Data.Cast<clsAppReviewerComments>().ToList();
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
                clsApplicationReview off = _activeDAL.SelectApplicationReviewById(id, dbName).FirstOrDefault();
                if (off != null)
                {
                        revCommentRes = appRevCont.GetByApplicationReviewId(off.id, dbName);
                        off.appReviewerComments = revCommentRes.Data.Cast<clsAppReviewerComments>().ToList();
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
        [HttpGet("GetByAppId")]
        public clsResult GetByAppId(int appId, string dbName)
        {
           
            try
            {
                List<clsApplicationReview> offList = _activeDAL.SelectApplicationReviewByAppId(appId,dbName);
                if (offList != null)
                {
                    foreach (var item in offList)
                    {
                        revCommentRes = appRevCont.GetByApplicationReviewId(item.id, dbName);
                        item.appReviewerComments = new List<clsAppReviewerComments>();
                        item.appReviewerComments = revCommentRes.Data.Cast<clsAppReviewerComments>().ToList();
                    }
                }
                result.Data = new List<object>();
                result.Data.Add(offList);
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
        public clsResult Post([FromBody] clsApplicationReview value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateApplicationReview(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertApplicationReview(ValidateData(value));
                    value.id = Id;
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                if (value.appReviewerComments != null)
                {
                    foreach (var item in value.appReviewerComments)
                    {
                        item.applicationReviewId = value.id;
                        item.dbName = value.dbName;
                        item.userId = value.userId;
                     revCommentRes = appRevCont.Post(item);
                        if (!revCommentRes.isSuccess)
                        {
                            result.message += "," + revCommentRes.message;
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

        private clsApplicationReview ValidateData(clsApplicationReview value)
        {
            //Add Logic For Insert And Update
            clsApplicationReview obj = new clsApplicationReview();
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
