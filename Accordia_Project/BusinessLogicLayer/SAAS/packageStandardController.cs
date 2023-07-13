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
    public class packageStandardController : ControllerBase
    {
        packageStandardDAL _activeDAL = new packageStandardDAL();
        clsResult result = new clsResult();
        [HttpGet()]
        public List<clsPackageStandard> Get(string dbName)
        {
            List<clsPackageStandard> offList = _activeDAL.SelectAllPackageStandard(dbName);
            return offList;
        }

       
        [HttpGet("{id}")]
        public clsPackageStandard Get(int id, string dbName)
        {
            clsPackageStandard off = _activeDAL.SelectPackageStandardById(id,dbName).FirstOrDefault();
            return off;
        }
        [HttpGet("PackageStandardGetByPackageId/{packageId}")]
        public List<clsPackageStandard> PackageStandardGetByPackageId(int packageId, string dbName)
        {
            List<clsPackageStandard> activeList = _activeDAL.SelectPackageStandardByPackageId(packageId, dbName);
            return activeList;
        }
        [HttpGet("GetByCompanyId/{companyId}")]
        public clsResult GetByCompanyId(int companyId,string dbName)
        {
            try
            {
                List<clsPackageStandard> offList = _activeDAL.SelectPackageStandardByCompanyId(companyId,dbName);
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
        public string Post([FromBody] clsPackageStandard value)
        {
            if (value.id > 0)
            {
                //Update Query
                _activeDAL.UpdatePackageStandard(ValidateData(value));
                return "Update";
            }
            else
            {
                // Insert Query
                _activeDAL.InsertPackageStandard(ValidateData(value));
                return "Insert";
            }
        }

        private clsPackageStandard ValidateData(clsPackageStandard value)
        {
            //Add Logic For Insert And Update
            clsPackageStandard obj = new clsPackageStandard();
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
