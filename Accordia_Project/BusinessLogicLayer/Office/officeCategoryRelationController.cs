using DataAccessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Office
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class officeCategoryRelationController : ControllerBase
    {
        officeCategoryRelationDAL _activeDAL = new officeCategoryRelationDAL();
        clsResult result =new clsResult();
        officeScopeController _scopeController = new officeScopeController();
        officeStandardsController _standardController = new officeStandardsController();
        officeStandardsDAL _standardDAL = new officeStandardsDAL();
        
        officeCategoryRelationStandardMapDAL standardMapDAL = new officeCategoryRelationStandardMapDAL();
        officeCategoryRelationStateMapDAL stateMapDAL = new officeCategoryRelationStateMapDAL();
        officeCategoryRelationCityMapDAL cityMapDAL = new officeCategoryRelationCityMapDAL();

        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsOfficeCategoryRelation> offList = _activeDAL.SelectAllOfficeCategoryRelation(dbName);
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
                clsOfficeCategoryRelation off = _activeDAL.SelectOfficeCategoryRelationById(id, dbName).FirstOrDefault();
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

        [HttpGet("GetByOfficeId")]
        public clsResult GetByOfficeId(int officeId, string dbName)
        {
            try
            {
                clsOfficeCategoryRelation off = _activeDAL.SelectOfficeCategoryRelationByOfficeId(officeId, dbName).FirstOrDefault();
                //___ get officeStandard by office Id __
                if (off != null)
                {
                    off.listOfficeStandard = _standardDAL.SelectOfficeStandardsByOfficeId(officeId,null);
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

        [HttpPost]
        public clsResult Post([FromBody] clsOfficeCategoryRelation value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateOfficeCategoryRelation(ValidateData(value));
                    result.id = value.id;
                    if (result.id > 0)
                    {
                        InsertMapStandardData(value);
                        InsertMapStateData(value);
                        InsertMapCityData(value);
                    }
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    bool stateExist = false;
                    bool cityExist = false;
                    string stateMessage = "";
                    string cityMessage = "";

                    List<clsOfficeCategoryRelation> offScopList = _activeDAL.SelectAllOfficeCategoryRelation(null);
                    if (offScopList.Count > 0)
                    {
                        //_______________ 1. check State _______________
                        foreach (var offCateg in offScopList)
                        {
                            if (offCateg.isOfficeExclusive)
                            {
                                List<clsOfficeCategoryStateMap> SelectOfficeScopeStateMap = stateMapDAL.spSelectOfficeCategoryRelationStateMapByOfficeCategoryRelId(offCateg.id, null);

                                foreach (var state in SelectOfficeScopeStateMap)
                                {
                                    foreach (var catRelstate in value.listOfficeState)
                                    {
                                        if (state.stateProvinceId == catRelstate.stateProvinceId)
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

                        //_______________ 2. check City  _______________
                        foreach (var offScop in offScopList.Where(x => x.isOfficeExclusive))
                        {
                            List<clsOfficeCategoryCityMap> SelectOfficeScopeStateMap = cityMapDAL.spSelectOfficeCategoryRelCityMapByOfficeCatRelId(offScop.id, null);
                            foreach (var state in SelectOfficeScopeStateMap)
                            {
                                foreach (var catRelCity in value.listOfficeCity)
                                {
                                    if (state.cityId == catRelCity.cityId)
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



                    int Id = _activeDAL.InsertOfficeCategoryRelation(ValidateData(value));
                    result.id = Id;
                    value.id = Id;
                    if (value.id > 0)
                    {
                        InsertMapStandardData(value);
                        InsertMapStateData(value);
                        InsertMapCityData(value);
                    }

                    //________ Fetch Last   All record   singleRecord + List ________________
                    List<clsOfficeCategoryRelation> offScopListbyId = _activeDAL.SelectOfficeCategoryRelationById(value.id, "");
                    if (value != null)
                    {
                        offScopList = GetMapData(offScopListbyId, "");
                    }
                    result.Data = new List<object>();
                    result.Data.Add(offScopListbyId.FirstOrDefault());

                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
                //if (value.listOfficeScope != null)
                //{
                //    _scopeController.Post(value.listOfficeScope);
                //}

                //_________ Change krna yaa nhin ____________

                if (value.listOfficeStandard != null)
                {
                    _standardController.Post(value.listOfficeStandard);
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }


        //__________ Added by SAQIB  -------- insert -----------   7/18/2023 _________________
        private void InsertMapStandardData(clsOfficeCategoryRelation obj)
        {
            try
            {
                if (obj.id > 0)
                {
                    if (obj.listOfficeStandard != null)
                    {
                        standardMapDAL.DeleteOfficeCategoryRelationStandardMap(obj.id, obj.dbName);
                        foreach (var item in obj.listOfficeCategoryRelStandard)
                        {
                            item.dbName = obj.dbName;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            item.officeCategoryRelationId = obj.id;
                            standardMapDAL.InsertOfficeCategoryRelationStandardMap(item);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw new ArgumentException("Error Throw From Office Scope Standard Insert.");
            }
        }
        private void InsertMapStateData(clsOfficeCategoryRelation obj)
        {
            try
            {
                if (obj.id > 0)
                {
                    if (obj.listOfficeStandard != null)
                    {
                        stateMapDAL.DeleteOfficeCategoryRelationMap(obj.id, obj.dbName);
                        foreach (var item in obj.listOfficeState)
                        {
                            item.dbName = obj.dbName;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            item.officeCategoryRelationId = obj.id;
                            stateMapDAL.InsertOfficeCategoryRelationStateMap(item);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw new ArgumentException("Error Throw From Office Scope State Insert.");
            }
        }
        private void InsertMapCityData(clsOfficeCategoryRelation obj)
        {
            try
            {
                if (obj.id > 0)
                {
                    if (obj.listOfficeStandard != null)
                    {
                        cityMapDAL.DeleteOfficeCategoryRelationCityMap(obj.id, obj.dbName);
                        foreach (var item in obj.listOfficeCity)
                        {
                            item.dbName = obj.dbName;
                            item.createdBy = obj.userId;
                            item.createdOn = DateTime.Now;
                            item.officeCategoryRelationId = obj.id;
                            cityMapDAL.InsertOfficecategoryRelationCityMap(item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Error Throw From Office Scope City Insert.");
            }
        }


        //__________ Added by SAQIB  -------- fetch -----------   7/18/2023 _________________
        private List<clsOfficeCategoryRelationStandardMap> GetMapStandard(int officeCategoryRelationId, string dbName)
        {
            try
            {
                return standardMapDAL.spSelectOfficeCategoryRelationStandardMapByOfficeScopeId(officeCategoryRelationId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In Standard Get");
            }
        }
        private List<clsOfficeCategoryStateMap> GetMapState(int officeCategoryRelationId, string dbName)
        {
            try
            {
                return stateMapDAL.spSelectOfficeCategoryRelationStateMapByOfficeCategoryRelId(officeCategoryRelationId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In State Province Map Get");
            }
        }
        private List<clsOfficeCategoryCityMap> GetMapCity(int officeCategoryRelationId, string dbName)
        {
            try
            {
                return cityMapDAL.spSelectOfficeCategoryRelCityMapByOfficeCatRelId(officeCategoryRelationId, dbName);
            }
            catch (Exception)
            {
                throw new ArgumentException("Error In City Map Get");
            }
        }
        private List<clsOfficeCategoryRelation> GetMapData(List<clsOfficeCategoryRelation> list, string dbName)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    //item.id ==> officeScopeId

                    //============== Modified By Saqib ================== 10:18 , 7/17/2023
                    //item.scopeStandard = new List<clsOfficeScopeStandardMap>();
                    //item.scopeStandard = GetMapStandard(item.id, dbName);
                    //item.scopeState = new List<clsOfficeScopeStateMap>();
                    //item.scopeState = GetMapState(item.id, dbName);   
                    //item.scopeCity = new List<clsOfficeScopeCityMap>();
                    //item.scopeCity = GetMapCity(item.id, dbName);

                    //============== Modified By Saqib ================== 10:18 , 7/17/2023
                    item.listOfficeCategoryRelStandard = new List<clsOfficeCategoryRelationStandardMap>();
                    item.listOfficeCategoryRelStandard = GetMapStandard(item.id, dbName);

                    item.listOfficeState = new List<clsOfficeCategoryStateMap>();
                    item.listOfficeState = GetMapState(item.id, dbName);

                    item.listOfficeCity = new List<clsOfficeCategoryCityMap>();
                    item.listOfficeCity = GetMapCity(item.id, dbName);
                }
            }
            return list;
        }



        private clsOfficeCategoryRelation ValidateData(clsOfficeCategoryRelation value)
        {
            //Add Logic For Insert And Update
            clsOfficeCategoryRelation obj = new clsOfficeCategoryRelation();
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
