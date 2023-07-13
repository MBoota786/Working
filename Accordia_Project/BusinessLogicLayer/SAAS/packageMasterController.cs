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
    public class packageMasterController : ControllerBase
    {
        packageMasterDAL _activeDAL = new packageMasterDAL();
        clsResult result = new clsResult();
        [HttpGet()]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsPackageMaster> offList = _activeDAL.SelectAllPackageMaster(dbName);
                packageStandardDAL stndDAL = new packageStandardDAL();
                if (offList != null)
                {
                    foreach (var item in offList)
                    {
                        item.packageStandard = stndDAL.SelectPackageStandardByPackageId(item.id, dbName);
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

       
        [HttpGet("{id}")]
        public clsResult Get(int id,string dbName)
        {
            try
            {
                clsPackageMaster off = _activeDAL.SelectPackageMasterById(id, dbName).FirstOrDefault();
                result.Data = new List<object>();
                result.Data.Add(off);
            }
            catch (Exception ex)
            {
                result.error = ex.Message;
            }
            return result;
        }

       
        [HttpPost]
        public clsResult Post([FromBody] clsPackageMaster value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdatePackageMaster(ValidateData(value));
                    result.id = value.id;
                    result.message = "Update Successfully";

                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertPackageMaster(ValidateData(value));
                    result.id = Id;
                    result.message = "Insert Successfully";
                }
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }

        private clsPackageMaster ValidateData(clsPackageMaster value)
        {
            //Add Logic For Insert And Update
            clsPackageMaster obj = new clsPackageMaster();
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
