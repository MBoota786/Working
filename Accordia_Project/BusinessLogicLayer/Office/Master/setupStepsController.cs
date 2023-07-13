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
    public class setupStepsController : ControllerBase
    {
        setupStepsDAL _activeDAL = new setupStepsDAL();
        clsResult result = new clsResult();
      
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsSetupSteps> offList = _activeDAL.SelectAllSetupSteps(dbName);
                if (offList.Count > 0)
                {
                    foreach (var item in offList)
                    {
                        List<clsSetupSteps> childSteps = new List<clsSetupSteps>();
                        if (item.parentStepId == null || item.parentStepId == 0)
                        {
                            childSteps = _activeDAL.SelectChildStepByParentStepId(item.id, dbName);
                            item.childSteps = childSteps;
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

        [HttpGet("GetChildStepByParentStepId/{parentStepId}")]
        public clsResult GetChildStepByParentStepId(int parentStepId,string dbName)
        {
            try
            {
                List<clsSetupSteps> offList = _activeDAL.SelectChildStepByParentStepId(parentStepId, dbName);
                result.Data = new List<object>();
                result.Data.AddRange(offList);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }


    }
}
