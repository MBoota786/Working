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
    public class appBusinessActivityController : ControllerBase
    {
        appClientProcessController _clientProcessController = new appClientProcessController();
        appClientSecondaryProcessController _secondaryProcessController = new appClientSecondaryProcessController();
        appClientProductController _clientProductController = new appClientProductController();
       // appClientBuyerController _clientBuyerController = new appClientBuyerController();
        clsResult result = new clsResult();
    
        [HttpGet("GetByAppId/{appId}")]
        public clsResult GetByAppId(int appId,string dbName)
        {
            try
            {
                clsAppBusinessActivity mainList = new clsAppBusinessActivity();
                clsResult proccessList = _clientProcessController.GetByAppId(appId,dbName);
                clsResult secProcessList = _secondaryProcessController.GetByAppId(appId,dbName);
                clsResult productList = _clientProductController.GetByAppId(appId,dbName);
               // clsResult buyerList = _clientBuyerController.GetByAppId(appId,dbName);


                mainList.primaryProcessList = proccessList.Data.Cast<clsAppClientProcess>().ToList();
                mainList.secondaryProcessList = secProcessList.Data.Cast<clsAppClientSecondaryProcess>().ToList();
                mainList.productList = productList.Data.Cast<clsAppClientProduct>().ToList();
              //  mainList.buyerList = buyerList.Data.Cast<clsAppClientBuyer>().ToList();
                result.Data = new List<object>();
                result.Data.Add(mainList);
                result.isSuccess = true;
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        public static object ConvertList(List<object> value, Type type)
        {
            var containedType = type.GenericTypeArguments.First();
            return value.Select(item => Convert.ChangeType(item, containedType)).ToList();
        }
        [HttpPost]
        public clsResult Post([FromBody] clsAppBusinessActivity value)
        {
            try
            {
                clsResult resultapi = new clsResult();
                if (value != null)
                {
                    if (value.productList != null && value.productList.Count > 0)
                    {
                        value.productList.Select(c => { c.dbName = value.dbName; return c; }).ToList();
                        resultapi =  _clientProductController.Post(value.productList);
                        result.isSuccess = resultapi.isSuccess;
                        result.message ="1"+ resultapi.message;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.message = "Product List Is Empty";
                    }
                    if (value.primaryProcessList != null && value.primaryProcessList.Count > 0)
                    {
                        value.primaryProcessList.Select(c => { c.dbName = value.dbName; return c; }).ToList();
                        resultapi = _clientProcessController.Post(value.primaryProcessList);
                        result.isSuccess = resultapi.isSuccess;
                        result.message += " 2" + resultapi.message;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.message += " Primary Process List Is Empty";
                    }
                    if (value.secondaryProcessList != null && value.secondaryProcessList.Count > 0)
                    {
                        value.secondaryProcessList.Select(c => { c.dbName = value.dbName; return c; }).ToList();
                        resultapi = _secondaryProcessController.Post(value.secondaryProcessList);
                        result.isSuccess = resultapi.isSuccess;
                        result.message += " 3" + resultapi.message;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.message += " Secondary Process List Is Empty";
                    }
                    //if (value.buyerList != null)
                    //{
                    //    value.buyerList.Select(c => { c.dbName = value.dbName; return c; }).ToList();
                    //    resultapi = _clientBuyerController.Post(value.buyerList);
                    //    result.isSuccess = resultapi.isSuccess;
                    //    result.message += " 4" + resultapi.message;
                    //}
                    //else
                    //{
                    //    result.isSuccess = false;
                    //    result.message += " Buyer List Is Empty";
                    //}
                }
                else
                {
                    result.isSuccess = false;
                    result.message = "All List Is Empty";
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.message = ex.Message;
            }
            return result;
        }

        private clsAppClientBrand ValidateData(clsAppClientBrand value)
        {
            //Add Logic For Insert And Update
            clsAppClientBrand obj = new clsAppClientBrand();
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
