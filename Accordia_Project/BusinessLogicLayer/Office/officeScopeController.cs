using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeScopeController : ControllerBase
    {
        officeScopeDAL _activeDAL = new officeScopeDAL();
        officeScopeStandardMapDAL standardMapDAL = new officeScopeStandardMapDAL();
        officeScopeStateMapDAL stateMapDAL = new officeScopeStateMapDAL();
        officeScopeCityMapDAL cityMapDAL = new officeScopeCityMapDAL();

        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeScope> offList = _activeDAL.SelectAllOfficeScope(dbName);
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
                List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeById(id, dbName);
                if (offList != null)
                {
                    offList = GetMapData(offList, dbName);
                }
                result.Data = new List<object>();
                result.Data.Add(offList.FirstOrDefault());
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        [HttpGet("GetByOfficeId")]
        public clsResult GetByOfficeId(int id, string dbName)
        {
            try
            {
                List<clsOfficeScope> offScopList = _activeDAL.SelectOfficeScopeByOfficeId(id, dbName);
                if (offScopList != null)
                {
                    offScopList = GetMapData(offScopList, dbName);
                }
                result.Data = new List<object>();
                result.Data.Add(offScopList.FirstOrDefault());
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        /*
        //[HttpPost]
        //public clsResult Post([FromBody] List<clsOfficeScope> list)
        //{
        //    try
        //    {
        //        if (list != null)
        //        {
        //            foreach (var value in list)
        //            {

        //                if (value.id > 0)
        //                {
        //                    //Update Query
        //                    _activeDAL.UpdateOfficeScope(ValidateData(value));
        //                    result.id = value.id;
        //                    if (value.id > 0)
        //                    {
        //                        InsertMapStandardData(value);
        //                        InsertMapStateData(value);
        //                        InsertMapCityData(value);
        //                    }
        //                    result.message = General.messageModel.updateMessage;
        //                    result.isSuccess = true;
        //                    log(value, "Update", value.dbName, "Office Scope");
        //                }
        //                else
        //                {
        //                    // Insert Query
        //                    //_______________ 1. check State of scope _______________
        //                    bool exist = false;
        //                    List<clsOfficeScope> offScopList = _activeDAL.SelectAllOfficeScope(null);
        //                    foreach (var offScop in offScopList)
        //                    {
        //                        if (offScop.isExclusive)
        //                        {
        //                            List<clsOfficeScopeStateMap> SelectOfficeScopeStateMap = stateMapDAL.spSelectOfficeScopeStateMapByOfficeScopeId(offScop.id, null);
        //                            foreach (var state in SelectOfficeScopeStateMap)
        //                            {
        //                                foreach (var scopstate in value.scopeState)
        //                                {
        //                                    if (state.id == scopstate.stateProvinceId)
        //                                    {
        //                                        result.message = string.Format("{0} State is already taken", state.stateProvinceName);
        //                                        result.isSuccess = false;
        //                                        exist = true;  
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                    //_______________ 2. check City of scope _______________

        //                    //___________ at the end insert Record _____________
        //                    if (exist == false)
        //                    {
        //                        int Id = _activeDAL.InsertOfficeScope(ValidateData(value));
        //                        result.id = Id;
        //                        value.id = Id;
        //                        if (value.id > 0)
        //                        {
        //                            InsertMapStandardData(value);
        //                            InsertMapStateData(value);
        //                            InsertMapCityData(value);
        //                        }
        //                        result.message = General.messageModel.insertMessage;
        //                        result.isSuccess = true;
        //                        log(value, "Insert", value.dbName, "Office Scope");
        //                    }
        //                }
        //            }
        //            List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeByOfficeId(list[0].officeId, list[0].dbName);
        //            if (offList != null)
        //            {
        //                offList = GetMapData(offList, list[0].dbName);
        //            }
        //            result.Data = new List<object>();
        //            result.Data.Add(offList.FirstOrDefault());
        //        }
        //        else
        //        {
        //            result.message = General.messageModel.listEmpMessage;
        //            result.isSuccess = false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.isSuccess = false;
        //        result.error = ex.Message;
        //    }
        //    return result;
        //}
        */

        /*________ Modified by  M : SAQIB ________*/
        //check  isExclusive base  state,City
        [HttpPost]
        public clsResult Post([FromBody] List<clsOfficeScope> list)
        {
            clsResult result = new clsResult();

            try
            {
                if (list != null)
                {

                    foreach (var value in list)
                    {
                        //Checking
                        bool stateExist = false;
                        bool cityExist = false;
                        string stateMessage = "";
                        string cityMessage = "";

                        List<clsOfficeScope> offScopList = _activeDAL.SelectAllOfficeScope(null);
                        if (offScopList.Count > 0)
                        {
                            //_______________ 1. check State _______________
                            foreach (var offScop in offScopList)
                            {
                                if (offScop.id != value.id)
                                {
                                    if (offScop.isExclusive)
                                    {
                                        List<clsOfficeScopeStateMap> SelectOfficeScopeStateMap = stateMapDAL.spSelectOfficeScopeStateMapByOfficeScopeId(offScop.id, null);

                                        foreach (var state in SelectOfficeScopeStateMap)
                                        {
                                            foreach (var scopstate in value.scopeState)
                                            {
                                                if (state.stateProvinceId == scopstate.stateProvinceId)
                                                {
                                                    //string errorMessage = string.Format("{0} : State is already taken", state.stateProvinceName);
                                                    //result.message = errorMessage;
                                                    //return result;
                                                    stateMessage = string.Format("{0} State is already taken", state.stateProvinceName);
                                                    stateExist = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            //_______________ 2. check City  _______________
                            foreach (var offScop in offScopList.Where(x => x.isExclusive && x.id != value.id))
                            {
                                List<clsOfficeScopeCityMap> SelectOfficeScopeStateMap = cityMapDAL.spSelectOfficeScopeCityMapByOfficeScopeId(offScop.id, null);
                                foreach (var state in SelectOfficeScopeStateMap)
                                {
                                    foreach (var scopstate in value.scopeCity)
                                    {
                                        if (state.cityId == scopstate.cityId)
                                        {
                                            string errorMessage = string.Format("{0} : City is already taken", state.cityName);
                                            //result.message = errorMessage;
                                            //return result;
                                            cityMessage = string.Format("{0} City is already taken", state.cityName);
                                            cityExist = true;
                                        }
                                    }
                                }
                            }


                            if (cityExist || cityExist)
                            {
                                var errorMessage = "";

                                if (cityExist && stateExist)
                                {
                                    errorMessage = cityMessage + " <br> " + stateMessage;
                                }
                                else if (cityExist)
                                {
                                    errorMessage = cityMessage;
                                }
                                else if (stateExist)
                                {
                                    errorMessage = stateMessage;
                                }

                                throw new Exception(errorMessage);
                            }
                        }


                        //Insert  || update 
                        if (value.id > 0)
                        {
                            // Update Query
                            _activeDAL.UpdateOfficeScope(ValidateData(value));
                            result.id = value.id;

                            if (value.id > 0)
                            {
                                InsertMapStandardData(value);
                                InsertMapStateData(value);
                                InsertMapCityData(value);
                            }

                            result.message = General.messageModel.updateMessage;
                            result.isSuccess = true;
                            log(value, "Update", value.dbName, "Office Scope");
                        }
                        else
                        {
                            //Insert Query
                            //Check if State of scope already exists
                            //bool exist = false;
                            //List<clsOfficeScope> offScopList = _activeDAL.SelectAllOfficeScope(null);
                            //foreach (var offScop in offScopList)
                            //{
                            //    if (offScop.isExclusive)
                            //    {
                            //        List<clsOfficeScopeStateMap> SelectOfficeScopeStateMap = stateMapDAL.spSelectOfficeScopeStateMapByOfficeScopeId(offScop.id, null);

                            //        foreach (var state in SelectOfficeScopeStateMap)
                            //        {
                            //            foreach (var scopstate in value.scopeState)
                            //            {
                            //                if (state.id == scopstate.stateProvinceId)
                            //                {
                            //                    string errorMessage = string.Format("{0} State is already taken", state.stateProvinceName);
                            //                    throw new Exception(errorMessage);
                            //                }
                            //            }
                            //        }
                            //    }
                            //}
                            
                            
                            int Id = _activeDAL.InsertOfficeScope(ValidateData(value));
                            result.id = Id;
                            value.id = Id;

                            if (value.id > 0)
                            {
                                InsertMapStandardData(value);
                                InsertMapStateData(value);
                                InsertMapCityData(value);
                            }

                            result.message = General.messageModel.insertMessage;
                            result.isSuccess = true;
                            log(value, "Insert", value.dbName, "Office Scope");
                            
                        }
                    }

                    List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeByOfficeId(list[0].officeId, list[0].dbName);

                    if (offList != null)
                    {
                        offList = GetMapData(offList, list[0].dbName);
                    }

                    result.Data = new List<object>();
                    result.Data.Add(offList.FirstOrDefault());
                }
                else
                {
                    result.message = General.messageModel.listEmpMessage;
                    result.isSuccess = false;
                }
            }
            catch (Exception ex)
            {

                result.isSuccess = false;
                result.error = ex.Message;
            }

            return result;
        }


        private void log(clsOfficeScope obj, string actionName, string dbName, string formName)
        {
            logsDAL _logsDAL = new logsDAL();
            clsLogs clsLog = new clsLogs();
            clsLog.dbName = dbName;
            clsLog.createdBy = obj.userId;
            clsLog.createdOn = DateTime.Now;
            clsLog.actionName = actionName;
            clsLog.recordId = obj.id;
            clsLog.logDetail = obj.ToString();
            clsLog.formName = formName;
            _logsDAL.InsertLogs(clsLog);
        }

        private void InsertMapStandardData(clsOfficeScope obj)
        {
            try
            {
                if (obj.id > 0)
                {
                    if (obj.scopeStandard != null)
                    {
                        var scopList= standardMapDAL.SelectOfficeScopeStandardMap(obj.dbName).Count();
                        if (scopList>0)
                        {
                            standardMapDAL.DeleteOfficeScopeStandardMap(obj.id, obj.dbName);
                        }
                        foreach (var item in obj.scopeStandard)
                        {
                            item.dbName = obj.dbName;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            item.officeScopeId = obj.id;
                            standardMapDAL.InsertOfficeScopeStandardMap(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error Throw From Office Scope Standard Insert.");
            }
        }
        private void InsertMapStateData(clsOfficeScope obj)
        {
            try
            {
                if (obj.id > 0)
                {
                    if (obj.scopeStandard != null)
                    {
                        stateMapDAL.DeleteOfficeScopeStateMap(obj.id, obj.dbName);
                        foreach (var item in obj.scopeState)
                        {
                            item.dbName = obj.dbName;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            item.officeScopeId = obj.id;
                            stateMapDAL.InsertOfficeScopeStateMap(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error Throw From Office Scope State Insert.");
            }
        }
        private void InsertMapCityData(clsOfficeScope obj)
        {
            try
            {
                if (obj.id > 0)
                {
                    if (obj.scopeStandard != null)
                    {
                        cityMapDAL.DeleteOfficeScopeCityMap(obj.id, obj.dbName);
                        foreach (var item in obj.scopeCity)
                        {
                            item.dbName = obj.dbName;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            item.officeScopeId = obj.id;
                            cityMapDAL.InsertOfficeScopeCityMap(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error Throw From Office Scope City Insert.");
            }
        }


        private List<clsOfficeScopeStandardMap> GetMapStandard(int officeScopeId, string dbName)
        {
            try
            {
                return standardMapDAL.spSelectOfficeScopeStandardMapByOfficeScopeId(officeScopeId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In Standard Get");
            }
        }
        private List<clsOfficeScopeStateMap> GetMapState(int officeScopeId, string dbName)
        {
            try
            {
                return stateMapDAL.spSelectOfficeScopeStateMapByOfficeScopeId(officeScopeId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In State Province Map Get");
            }
        }
        private List<clsOfficeScopeCityMap> GetMapCity(int officeScopeId, string dbName)
        {
            try
            {
                return cityMapDAL.spSelectOfficeScopeCityMapByOfficeScopeId(officeScopeId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In City Map Get");
            }
        }
        private List<clsOfficeScope> GetMapData(List<clsOfficeScope> list, string dbName)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    //item.id ==> officeScopeId
                    item.scopeStandard = new List<clsOfficeScopeStandardMap>();
                    item.scopeStandard = GetMapStandard(item.id, dbName);
                    item.scopeState = new List<clsOfficeScopeStateMap>();
                    item.scopeState = GetMapState(item.id, dbName);
                    item.scopeCity = new List<clsOfficeScopeCityMap>();
                    item.scopeCity = GetMapCity(item.id, dbName);
                }
            }
            return list;
        }

        private clsOfficeScope ValidateData(clsOfficeScope value)
        {
            //Add Logic For Insert And Update
            clsOfficeScope obj = new clsOfficeScope();
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


#region backup_old _ 7/17/2023
//using DataAccessLayer;
//using EntityLayer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Accordia_Project.BusinessLogicLayer.Office
//{
//    //[Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class officeScopeController : ControllerBase
//    {
//        officeScopeDAL _activeDAL = new officeScopeDAL();
//        clsResult result = new clsResult();
//        [HttpGet]
//        public clsResult Get(string dbName)
//        {
//            try
//            {
//                List<clsOfficeScope> offList = _activeDAL.SelectAllOfficeScope(dbName);
//                result.Data = new List<object>();
//                result.Data.AddRange(offList);
//                result.isSuccess = true;
//            }
//            catch (Exception ex)
//            {
//                result.isSuccess = false;
//                result.error = ex.Message;
//            }
//            return result;
//        }

//        [HttpGet("{id}")]
//        public clsResult Get(int id, string dbName)
//        {
//            try
//            {
//                List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeById(id, dbName);
//                if (offList != null)
//                {
//                    offList = GetMapData(offList, dbName);
//                }
//                result.Data = new List<object>();
//                result.Data.Add(offList.FirstOrDefault());
//                result.isSuccess = true;
//            }
//            catch (Exception ex)
//            {
//                result.isSuccess = false;
//                result.error = ex.Message;
//            }
//            return result;
//        }
//        [HttpGet("GetByOfficeId")]
//        public clsResult GetByOfficeId(int id, string dbName)
//        {
//            try
//            {
//                List<clsOfficeScope> offScopList = _activeDAL.SelectOfficeScopeByOfficeId(id, dbName);
//                if (offScopList != null)
//                {
//                    offScopList = GetMapData(offScopList, dbName);
//                }
//                result.Data = new List<object>();
//                result.Data.Add(offScopList.FirstOrDefault());
//                result.isSuccess = true;
//            }
//            catch (Exception ex)
//            {
//                result.isSuccess = false;
//                result.error = ex.Message;
//            }
//            return result;
//        }
//        [HttpPost]
//        public clsResult Post([FromBody] List<clsOfficeScope> list)
//        {
//            try
//            {
//                if (list != null)
//                {
//                    foreach (var value in list)
//                    {

//                        if (value.id > 0)
//                        {
//                            //Update Query
//                            _activeDAL.UpdateOfficeScope(ValidateData(value));
//                            result.id = value.id;
//                            if (value.id > 0)
//                            {
//                                InsertMapStandardData(value);
//                                InsertMapStateData(value);
//                                InsertMapCityData(value);
//                            }
//                            result.message = General.messageModel.updateMessage;
//                            result.isSuccess = true;
//                            log(value, "Update", value.dbName, "Office Scope");
//                        }
//                        else
//                        {

//                            // Insert Query
//                            int Id = _activeDAL.InsertOfficeScope(ValidateData(value));
//                            result.id = Id;
//                            value.id = Id;
//                            if (value.id > 0)
//                            {
//                                InsertMapStandardData(value);
//                                InsertMapStateData(value);
//                                InsertMapCityData(value);
//                            }
//                            result.message = General.messageModel.insertMessage;
//                            result.isSuccess = true;
//                            log(value, "Insert", value.dbName, "Office Scope");
//                        }
//                    }
//                    List<clsOfficeScope> offList = _activeDAL.SelectOfficeScopeByOfficeId(list[0].officeId, list[0].dbName);
//                    if (offList != null)
//                    {
//                        offList = GetMapData(offList, list[0].dbName);
//                    }
//                    result.Data = new List<object>();
//                    result.Data.Add(offList.FirstOrDefault());
//                }
//                else
//                {
//                    result.message = General.messageModel.listEmpMessage;
//                    result.isSuccess = false;
//                }

//            }
//            catch (Exception ex)
//            {
//                result.isSuccess = false;
//                result.error = ex.Message;
//            }
//            return result;
//        }
//        private void log(clsOfficeScope obj, string actionName, string dbName, string formName)
//        {
//            logsDAL _logsDAL = new logsDAL();
//            clsLogs clsLog = new clsLogs();
//            clsLog.dbName = dbName;
//            clsLog.createdBy = obj.userId;
//            clsLog.createdOn = DateTime.Now;
//            clsLog.actionName = actionName;
//            clsLog.recordId = obj.id;
//            clsLog.logDetail = obj.ToString();
//            clsLog.formName = formName;
//            _logsDAL.InsertLogs(clsLog);
//        }

//        officeScopeStandardMapDAL standardMapDAL = new officeScopeStandardMapDAL();
//        officeScopeStateMapDAL stateMapDAL = new officeScopeStateMapDAL();
//        officeScopeCityMapDAL cityMapDAL = new officeScopeCityMapDAL();

//        private void InsertMapStandardData(clsOfficeScope obj)
//        {
//            try
//            {
//                if (obj.id > 0)
//                {
//                    if (obj.scopeStandard != null)
//                    {
//                        standardMapDAL.DeleteOfficeScopeStandardMap(obj.id, obj.dbName);
//                        foreach (var item in obj.scopeStandard)
//                        {
//                            item.dbName = obj.dbName;
//                            item.createdBy = obj.userId;
//                            item.createdOn = DateTime.Now;
//                            item.officeScopeId = obj.id;
//                            standardMapDAL.InsertOfficeScopeStandardMap(item);
//                        }
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                throw new ArgumentException("Error Throw From Office Scope Standard Insert.");
//            }
//        }
//        private void InsertMapStateData(clsOfficeScope obj)
//        {
//            try
//            {
//                if (obj.id > 0)
//                {
//                    if (obj.scopeStandard != null)
//                    {
//                        stateMapDAL.DeleteOfficeScopeStateMap(obj.id, obj.dbName);
//                        foreach (var item in obj.scopeState)
//                        {
//                            item.dbName = obj.dbName;
//                            item.createdBy = obj.userId;
//                            item.createdOn = DateTime.Now;
//                            item.officeScopeId = obj.id;
//                            stateMapDAL.InsertOfficeScopeStateMap(item);
//                        }
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                throw new ArgumentException("Error Throw From Office Scope State Insert.");
//            }
//        }
//        private void InsertMapCityData(clsOfficeScope obj)
//        {
//            try
//            {
//                if (obj.id > 0)
//                {
//                    if (obj.scopeStandard != null)
//                    {
//                        cityMapDAL.DeleteOfficeScopeCityMap(obj.id, obj.dbName);
//                        foreach (var item in obj.scopeCity)
//                        {
//                            item.dbName = obj.dbName;
//                            item.createdBy = obj.userId;
//                            item.createdOn = DateTime.Now;
//                            item.officeScopeId = obj.id;
//                            cityMapDAL.InsertOfficeScopeCityMap(item);
//                        }
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                throw new ArgumentException("Error Throw From Office Scope City Insert.");
//            }
//        }
//        private List<clsOfficeScopeStandardMap> GetMapStandard(int officeScopeId, string dbName)
//        {
//            try
//            {
//                return standardMapDAL.spSelectOfficeScopeStandardMapByOfficeScopeId(officeScopeId, dbName);
//            }
//            catch (Exception)
//            {
//                throw new ArgumentException("Error In Standard Get");
//            }
//        }
//        private List<clsOfficeScopeStateMap> GetMapState(int officeScopeId, string dbName)
//        {
//            try
//            {
//                return stateMapDAL.spSelectOfficeScopeStateMapByOfficeScopeId(officeScopeId, dbName);
//            }
//            catch (Exception)
//            {
//                throw new ArgumentException("Error In State Province Map Get");
//            }
//        }
//        private List<clsOfficeScopeCityMap> GetMapCity(int officeScopeId, string dbName)
//        {
//            try
//            {
//                return cityMapDAL.spSelectOfficeScopeCityMapByOfficeScopeId(officeScopeId, dbName);
//            }
//            catch (Exception)
//            {
//                throw new ArgumentException("Error In City Map Get");
//            }
//        }
//        private List<clsOfficeScope> GetMapData(List<clsOfficeScope> list, string dbName)
//        {
//            if (list != null)
//            {
//                foreach (var item in list)
//                {
//                    //item.id ==> officeScopeId

//                    //============== Modified By Saqib ================== 10:18 , 7/17/2023
//                    //item.scopeStandard = new List<clsOfficeScopeStandardMap>();
//                    //item.scopeStandard = GetMapStandard(item.id, dbName);
//                    //item.scopeState = new List<clsOfficeScopeStateMap>();
//                    //item.scopeState = GetMapState(item.id, dbName);   
//                    //item.scopeCity = new List<clsOfficeScopeCityMap>();
//                    //item.scopeCity = GetMapCity(item.id, dbName);

//                    //============== Modified By Saqib ================== 10:18 , 7/17/2023
//                    if (item.isExclusive)
//                    {
//                        item.scopeStandard = new List<clsOfficeScopeStandardMap>();
//                        item.scopeStandard = GetMapStandard(item.id, dbName);
//                        item.scopeState = new List<clsOfficeScopeStateMap>();
//                        item.scopeState = GetMapState(item.id, dbName);
//                        item.scopeCity = new List<clsOfficeScopeCityMap>();
//                        item.scopeCity = GetMapCity(item.id, dbName);
//                    }
//                }
//            }
//            return list;
//        }
//        private clsOfficeScope ValidateData(clsOfficeScope value)
//        {
//            //Add Logic For Insert And Update
//            clsOfficeScope obj = new clsOfficeScope();
//            if (value.id > 0)
//            {
//                value.modifiedBy = value.userId;
//                value.modifiedOn = DateTime.Now;
//            }
//            else
//            {
//                value.active = true;
//                value.createdBy = value.userId;
//                value.createdOn = DateTime.Now;
//            }
//            obj = value;
//            return obj;
//        }
//    }
//}

#endregion