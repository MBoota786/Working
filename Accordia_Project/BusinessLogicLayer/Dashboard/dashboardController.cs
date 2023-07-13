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
    public class dashboardController : ControllerBase
    {
        dashboardDAL _activeDAL = new dashboardDAL();
        clsResult result = new clsResult();
        [HttpGet]
        public clsResult GetByOfficeId(int officeId,string dbName)
        {
            try
            {
                List<clsDashboard> offList = _activeDAL.SelectDashBoardCardByOfficeId(officeId,dbName);
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
    }
}
