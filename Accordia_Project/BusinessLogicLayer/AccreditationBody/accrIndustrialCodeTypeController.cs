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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class accrIndustrialCodeTypeController : ControllerBase
    {
        accrIndustrialCodeTypeDAL _activeDAL = new accrIndustrialCodeTypeDAL();
        naceSectionDAL _sectionDAL = new naceSectionDAL();
        naceDivisionDAL _divisionDAL = new naceDivisionDAL();
        naceGroupDAL _groupDAL = new naceGroupDAL();
        naceClassDAL _classDAL = new naceClassDAL();

        clsResult result = new clsResult();
        [HttpGet]
        public clsResult Get(string dbName)
        {
            try
            {
                List<clsAccrIndustrialCodeType> offList = _activeDAL.SelectAllAccrIndustrialCodeType(dbName);
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
                clsAccrIndustrialCodeType off = _activeDAL.SelectAccrIndustrialCodeTypeById(id, dbName).FirstOrDefault();
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
        public clsResult Post([FromBody] clsAccrIndustrialCodeType value)
        {
            try
            {
                List<listExcel> listExcels = FilterExcelData(value);
                listExcels.RemoveAt(0);
                value.id = 1;
                value.officeId = 4;
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateAccrIndustrialCodeType(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    int Id = _activeDAL.InsertAccrIndustrialCodeType(ValidateData(value));
                    result.id = Id;
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                    InsertNaceExcelData(listExcels, value);
                }

            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }
        private void InsertNaceExcelData(List<listExcel> listExcels, clsAccrIndustrialCodeType value)
        {
            clsNaceSection sectObj = new clsNaceSection();
            clsNaceDivision divObj = new clsNaceDivision();
            clsNaceGroup grpOjb = new clsNaceGroup();
            clsNaceClass clsOjb = new clsNaceClass();
            if (listExcels != null)
            {
                foreach (var item in listExcels)
                {
                    if (!String.IsNullOrEmpty(item.section))
                    {
                        sectObj = _sectionDAL.SelectNaceSectionByNaceSection(item.section, value.dbName).FirstOrDefault();
                        if (sectObj == null)
                        {
                            sectObj = new clsNaceSection();
                            sectObj.accrIndustrialCodeTypeId = value.id;
                            sectObj.naceSection = item.section;
                            sectObj.naceTitle = item.sectionTitle;
                            sectObj.officeId = value.officeId;
                            sectObj.createdBy = value.userId;
                            sectObj.createdOn = DateTime.Now;
                            sectObj.dbName = value.dbName;
                            sectObj.id = _sectionDAL.InsertNaceSection(sectObj);
                        }
                    }
                    if (!String.IsNullOrEmpty(item.division))
                    {
                        divObj = _divisionDAL.SelectNaceDivisionByDivisionNo(item.division, value.dbName).FirstOrDefault();
                        if (divObj == null && sectObj.id > 0)
                        {
                            divObj = new clsNaceDivision();
                            divObj.createdBy = value.userId;
                            divObj.createdOn = DateTime.Now;
                            divObj.dbName = value.dbName;
                            divObj.active = true;
                            divObj.naceSectionId = sectObj.id;
                            divObj.divisionNo = item.division;
                            divObj.divisionTitle = item.divisionTitle;
                            divObj.id = _divisionDAL.InsertNaceDivision(divObj);
                        }
                    }
                    if (!String.IsNullOrEmpty(item.group))
                    {
                        grpOjb = _groupDAL.SelectNaceGroupByNaceGroup(item.group, value.dbName).FirstOrDefault();
                        if (grpOjb == null && divObj.id > 0)
                        {
                            grpOjb = new clsNaceGroup();
                            grpOjb.createdBy = value.userId;
                            grpOjb.createdOn = DateTime.Now;
                            grpOjb.dbName = value.dbName;
                            grpOjb.active = true;
                            grpOjb.naceDivisionId = divObj.id;
                            grpOjb.naceGroup = item.group;
                            grpOjb.groupTitle = item.groupTitle;
                            grpOjb.groupDescription = item.groupDescription;
                            grpOjb.id = _groupDAL.InsertNaceGroup(grpOjb);
                        }
                    }
                    if (!String.IsNullOrEmpty(item.className))
                    {
                        clsOjb = _classDAL.SelectNaceClassByNaceClass(item.className, value.dbName).FirstOrDefault();
                        if (clsOjb == null && grpOjb.id > 0)
                        {
                            clsOjb = new clsNaceClass();
                            clsOjb.createdBy = value.userId;
                            clsOjb.createdOn = DateTime.Now;
                            clsOjb.dbName = value.dbName;
                            clsOjb.active = true;
                            clsOjb.naceGroupId = grpOjb.id;
                            clsOjb.naceClass = item.group;
                            clsOjb.classTitle = item.groupTitle;
                            clsOjb.classDescription = item.classDescription;
                            clsOjb.id = _classDAL.InsertNaceClass(clsOjb);
                        }
                    }
                }
            }
        }
        private List<listExcel> FilterExcelData(clsAccrIndustrialCodeType value)
        {
            List<listExcel> excellist = new List<listExcel>();
             
            foreach (var item in value.listExcel)
            {
                if (item.Count > 0)
                {
                    listExcel obj = new listExcel();
                    obj.section = item[0] != null ? item[0].ToString() : string.Empty;
                    obj.sectionTitle = item[1] != null ? item[1].ToString() : string.Empty;
                    obj.division = item[2] != null ? item[2].ToString() : string.Empty;
                    obj.divisionTitle = item[3] != null ? item[3].ToString() : string.Empty;
                    if (item.Count > 4)
                    {
                        obj.group = item[4] != null ? item[4].ToString() : string.Empty;
                    }
                    if (item.Count > 5)
                    {
                        obj.groupTitle = item[5] != null ? item[5].ToString() : string.Empty;
                    }
                    if (item.Count > 6)
                    {
                        obj.groupDescription = item[6] != null ? item[6].ToString() : string.Empty;
                    }
                    if (item.Count > 7)
                    {
                        obj.className = item[7] != null ? item[7].ToString() : string.Empty;
                    }
                    if (item.Count > 8)
                    {
                        obj.classTitle = item[8] != null ? item[8].ToString() : string.Empty;
                    }
                    if (item.Count > 9)
                    {
                        obj.classDescription = item[9] != null ? item[9].ToString() : string.Empty;
                    }
                    excellist.Add(obj);
                }
            }
            return excellist;

        }
        private clsAccrIndustrialCodeType ValidateData(clsAccrIndustrialCodeType value)
        {
            //Add Logic For Insert And Update
            clsAccrIndustrialCodeType obj = new clsAccrIndustrialCodeType();
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
