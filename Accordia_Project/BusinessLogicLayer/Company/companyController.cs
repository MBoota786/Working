using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.General.Company
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class companyController : ControllerBase
    {
        companyDAL activeDAL = new companyDAL();
        // GET: api/<CompanyController>
        private IConfiguration configuration;
        public companyController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }
        [HttpGet()]
        public List<clsCompany> Get(string dbName)
        {
            List<clsCompany> lst = new List<clsCompany>();
           lst = activeDAL.SelectAllCompany(dbName);
           
            return lst;
        }
        
        // GET api/<CompanyController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        [HttpGet("{id}")]
        public bool Get(string id,string dbName)
        {
           return activeDAL.IsCompanyNameAlreadyExist(id,dbName);
            
        }
       

        // POST api/<CompanyController>
        [HttpPost]
        public string Post([FromBody] clsCompany value)
        {
            
            if (value.id > 0)
            {
                //Update Query
                if (ValidateData(value))
                { return "Successfully Update"; }
                else
                {
                    return "Error In Company Update";
                }
            }
            else
            {
                // Insert Query
               if(ValidateData(value))
                { return "Successfully Insert"; }
                else
                {
                    return "Error In Company Insert";
                }
                
            }

        }
        private bool RegisterClientAndCreateDB(clsCompany objcompany)
        {
            bool RegisterStatus = false;
            clsUserLogin objuserLogin = new clsUserLogin();
            objuserLogin.companyId = objcompany.id;
            objuserLogin.officeId = 0;
            objuserLogin.designationId = 0;

            objuserLogin.createdBy = objcompany.userId;
            objuserLogin.createdOn = DateTime.Now;
            objcompany.dbName = objcompany.companyName.Replace(" ", "").ToString();
            objuserLogin.userName = "admin";
            objuserLogin.userCode= "admin@" + objcompany.dbName;
            objuserLogin.userPassword = objcompany.encrPassword;
            objuserLogin.userEmail = "admin@"+ objcompany.dbName + ".com";
            objuserLogin.dbName = objcompany.dbName;
            objuserLogin.lastLogin = DateTime.Now;
            objuserLogin.isLogin = false;
            objuserLogin.approvalStatus = "Approved";
            objuserLogin.approvalDate = DateTime.Now;
            objuserLogin.approvalBy = objcompany.userId;
            objuserLogin.active = true;
            userLoginDAL loginDAL = new userLoginDAL();
            string CreateNewDB = "";
            string fromFile = configuration.GetValue<string>("dbCreateSetting:fromFile");
            string toFile = configuration.GetValue<string>("dbCreateSetting:toFile");
            //  if (loginDAL.InsertUserLogin(objuserLogin,null) > 0)
            // {
            CreateNewDB = "RESTORE DATABASE " + objcompany.dbName + " FROM DISK = '"+fromFile+"' WITH MOVE 'EvolveMain' TO '"+ toFile + objcompany.dbName + ".mdf',MOVE 'EvolveMain_Log' TO '"+toFile + objcompany.dbName + ".ldf'";
            // }
            loginDAL.InsertUserLogin(objuserLogin, null);
            companyDAL compDAL = new companyDAL();
            compDAL.CreateDatabaseForClient(CreateNewDB);
            objcompany.id = activeDAL.InsertCompany(objcompany, objcompany.dbName);
            loginDAL.InsertUserLogin(objuserLogin, objcompany.dbName);
            //if (loginDAL.InsertUserLogin(objuserLogin, objcompany.dbName) > 0)
            //{

            //}
            RegisterStatus = true;
            return RegisterStatus;
        }
        private void RegisterUser(int leadCompanyId,int companyId)
        {

        }
        private string InitializeCode(string dbName)
        {
            string Code = "CM-001";
            try
            {

                companyDAL dal = new companyDAL();
                string MaxCode = dal.GetMaxCode(null);
                if (!string.IsNullOrEmpty(MaxCode))
                {
                    var substring = MaxCode.Substring(MaxCode.LastIndexOf('-') + 1);
                    int Add = Convert.ToInt32(substring);
                    Add = Add + 1;
                    substring = Regex.Replace(substring, "\\d+", m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
                    Code = "CM-" + substring;
                }
                else
                {
                    Code = "CM-001";
                }

                return Code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateData(clsCompany value)
        {
            //Add Logic For Insert And Update
            clsCompany obj = new clsCompany();
            if (value.id > 0)
            {
                value.modifiedBy = value.userId;
                value.modifiedOn = DateTime.Now;
                value.dbName = value.companyName.Replace(" ", "").ToString();
                activeDAL.UpdateCompany(value);
                //Map Standard
                //MapStandard(value);
            }
            else
            {
                value.createdBy = value.userId;
                value.createdOn = DateTime.Now;
                
                value.dbName = value.companyName.Replace(" ", "").ToString();
                value.code = InitializeCode(value.dbName);
                value.createdOn = DateTime.Now;
                value.createdBy = value.userId;
                //Set Folder Path For Azure
                value.folderPath = value.companyName + value.code;
                //End
                //For Evolve
                value.id = activeDAL.InsertCompany(value, null);
                //End
                if (value.id>0)
                {
                    //Map Standard
                    //  MapStandard(value);
                    //Register New DB And Create User
                    RegisterClientAndCreateDB(value);


                }
                else
                {
                    return false;
                }
            }
            return true ;
        }
        private bool MapStandard(clsCompany objCompany)
        {
            bool MapStatus = false;
            if (objCompany.listStandard != null && objCompany.listStandard.Count > 0)
            {
                companyStandardsDAL activeDAL = new companyStandardsDAL();
               
                if (activeDAL.IsExistCompanyStandardsByCompanyId(objCompany.id))
                {
                    //If Standards Exist By Company , Set Active
                    //False All Company Standards & Check Is Exist Update 
                    //Active True & Which Not Exists Insert Here

                    clsCompanyStandards objstndrd = new clsCompanyStandards();
                    objstndrd.companyId = objCompany.id;
                    objstndrd.modifiedBy = objCompany.userId;
                    objstndrd.modifiedOn = DateTime.Now;
                    activeDAL.SetActiveFalseCompanyStandardsByCompanyId(objstndrd);
                    foreach (var item in objCompany.listStandard)
                    {
                        objstndrd.companyId = objCompany.id;
                        objstndrd.accreditationStandardId = item;
                        objstndrd.active = true;
                        objstndrd.modifiedBy = objCompany.userId;
                        objstndrd.modifiedOn = DateTime.Now;
                        if (activeDAL.IsExistCompanyStandards(item))
                        {
                            //Which Standard Exist Update Here Active
                            activeDAL.UpdateCompanyStandards(objstndrd);
                        }
                        else
                        {
                            // Which Not Exist At the time of Update , Insert Here
                            objstndrd.createdBy = objCompany.userId;
                            objstndrd.createdOn = DateTime.Now;
                            activeDAL.InsertCompanyStandards(objstndrd);
                        }
                        MapStatus = true;
                    }
                }
                else
                {
                    // this Code For Insert New Company Standard On New Company Insert
                    foreach (var item in objCompany.listStandard)
                    {
                        clsCompanyStandards objstndrd = new clsCompanyStandards();
                        objstndrd.companyId = objCompany.id;
                        objstndrd.accreditationStandardId = item;
                        objstndrd.active = true;
                        objstndrd.createdBy = objCompany.userId;
                        objstndrd.createdOn = DateTime.Now;
                        if (activeDAL.InsertCompanyStandards(objstndrd) > 0)
                        {
                            MapStatus = true;
                        }
                        else
                        {
                            MapStatus = false;
                            break;
                        }
                    }
                }
            }
            return MapStatus;
        }

    }
    public class dbCreateSetting
    {
        public string fromFile { get; set; }
        public string toFile { get; set; }
    }
}
