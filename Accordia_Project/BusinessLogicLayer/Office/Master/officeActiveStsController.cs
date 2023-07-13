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
    public class officeActiveStsController : ControllerBase
    {
        officeActiveStsDAL _activeDAL = new officeActiveStsDAL();
      
        [HttpGet]
        public List<clsOfficeActiveSts> Get(string dbName)
        {
            List<clsOfficeActiveSts> offList = _activeDAL.SelectAllOfficeActiveSts(dbName);
            return offList;
        }

    
    }
}
