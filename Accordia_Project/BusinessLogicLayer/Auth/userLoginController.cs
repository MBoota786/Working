using Accordia_Project.BusinessLogicLayer.General;
using DataAccessLayer;
using EntityLayer;
using EntityLayer.clsNoticeBoard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accordia_Project.BusinessLogicLayer.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class userLoginController : ControllerBase
    {
        userLoginDAL _activeDAL = new userLoginDAL();
        clsResult result = new clsResult();
        // GET: api/<LoginController>
        // [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpPost]
        public clsResult Post([FromBody] clsUserLogin value)
        {
            try
            {
                if (value.id > 0)
                {
                    //Update Query
                    _activeDAL.UpdateUserLogin(ValidateData(value));
                    result.id = value.id;
                    result.message = General.messageModel.updateMessage;
                    result.isSuccess = true;
                }
                else
                {
                    // Insert Query
                    // Insert Query
                    if (value.dbName != null && value.dbName != "")
                    {
                        _activeDAL.InsertUserLogin(ValidateData(value), null);
                        result.id = _activeDAL.InsertUserLogin(ValidateData(value), value.dbName);
                    }
                    else
                    {
                        result.id = _activeDAL.InsertUserLogin(ValidateData(value), null);
                    }
                    result.message = General.messageModel.insertMessage;
                    result.isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpPost("ForgotPasswordEmail")]
        public clsResult ForgotPasswordEmail(clsForgotPassword objValue)
        {
            try
            {
                if (objValue.userEmail != "")
                {
                    clsUserLogin obj = _activeDAL.SelectUserInfoForEmailByUserEmail(objValue.userEmail, null);
                    if (obj != null)
                    {
                        Random rnd = new Random();
                        int randomOTP = rnd.Next(1000, 9999);
                        DateTime otpTime = DateTime.Now.AddHours(1);
                        _activeDAL.UpdateOtpPasswordById(obj.id, randomOTP.ToString(), otpTime);
                        emailSendModel model = new emailSendModel();
                        string resetUrl = objValue.changePasswordUrl + "?id=" + obj.id;
                        model.ResetPasswordEmailSend(obj.userEmail, randomOTP.ToString(), obj.userName, resetUrl);
                        result.isSuccess = true;
                        result.message = "OTP Email Sent , Email Expire After 1 Hours";
                        result.id = obj.id;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.message = "Email Not Found";
                    }
                }
                else
                {
                    result.isSuccess = false;
                    result.error = "Email Cannot Be Null";
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        [HttpPost("POSTOTPVerification")]
        public clsResult POSTOTPVerification(clsOTPVerification objValue)
        {
            try
            {
                if (objValue.otpCode > 0)
                {
                    bool verifyOTP = _activeDAL.OTPCheckVerify(objValue.id, DateTime.Now);
                    if (verifyOTP)
                    {

                        result.isSuccess = true;
                        result.message = "OTP Verify";
                        result.id = objValue.id;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.message = "OTP Expire";
                    }
                }
                else
                {
                    result.isSuccess = false;
                    result.error = "OTP Cannot Be Null";
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }


        [HttpPost("POSTChagePasswordById")]
        public clsResult POSTChagePasswordById(clsChangePassword objValue)
        {
            try
            {
                if (objValue.id > 0)
                {
                    bool passwordChange = _activeDAL.ChangePasswordById(objValue.id, objValue.newPassword, null);
                    if (passwordChange)
                    {

                        result.isSuccess = true;
                        result.message = "Password Successfully Changed";
                        result.id = objValue.id;
                    }
                    else
                    {
                        result.isSuccess = false;
                        result.error = "Password Not Change";
                    }
                }
                else
                {
                    result.isSuccess = false;
                    result.error = "Password Cannot Be Null";
                }
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }
        [HttpGet("ChangePasswordByUserCode/{userCode,userPassword,oldPassword}")]
        public string ChangePasswordByUserCode(string userCode, string newPassword, string oldPassword)
        {

            if (userCode != null)
            {
                string[] DBName = userCode.Split('@');
                clsUserLogin obj = _activeDAL.GetPasswordById(userCode, DBName[1]);
                if (obj != null && obj.id > 0)
                {
                    //Password Check Logic Here
                    if (obj.userPassword == oldPassword)
                    {
                        _activeDAL.ChangePasswordById(obj.id, newPassword, DBName[1]);
                        return "Password Changed";
                    }
                    else
                    {
                        return "Password Not Match";
                    }

                }
                return "Password Change";
            }
            else
            {
                return "Id Is Null";
            }
        }
        // GET api/<LoginController>/5
        [HttpGet]
        public clsResult Get(string UserEmail, string UserPassword)
        {
            try
            {

                //   ClsRegister objReg = new ClsRegister();
                clsUserLogin objULogin = new clsUserLogin();
                if (!string.IsNullOrEmpty(UserEmail) && !string.IsNullOrEmpty(UserPassword))
                {
                    objULogin.userEmail = UserEmail;
                    objULogin.userPassword = UserPassword;
                    #region old
                    // string[] DBName = logins.LoginCode.Split('@');

                    //  if (DBName[1].ToLower()=="evolve")
                    //  {
                    //   objULogin=  LogDAL.SelectAndCheckLoginEvolve(objULogin);
                    //    if (objULogin != null)
                    //    {
                    //        objULogin.companyName = "Evolve";
                    //       objULogin.LoginStatus = "Login";
                    //        objULogin.Token = GenerateToken();
                    //   }
                    //     else
                    // {
                    //       objULogin = new clsUserLogin();
                    //      objULogin.LoginStatus = "Invalid";
                    //  }
                    //  }
                    //  else
                    // {
                    #endregion 
                    userLoginDAL uLoginDAL = new userLoginDAL();

                    objULogin = uLoginDAL.SelectAndCheckLoginClient(objULogin, null);

                    if (objULogin != null)
                    {
                        clsUserLogin objClientULogin = new clsUserLogin();
                        objClientULogin.userEmail = UserEmail;
                        objClientULogin.userPassword = UserPassword;
                        objClientULogin = uLoginDAL.SelectAndCheckLoginClient(objClientULogin, objULogin.dbName);
                        if (objClientULogin != null)
                        {
                            objClientULogin.LoginStatus = "Login";
                            objClientULogin.Token = GenerateToken(UserEmail, new List<clsUserRoles>(),objClientULogin.id);
                            result.isSuccess = true;
                            result.message = "Login";
                            result.Data = new List<object>();
                            result.Data.Add(objClientULogin);
                        }
                        else
                        {
                            objULogin = new clsUserLogin();
                            result.isSuccess = false;
                            result.message = "Email & Password Not Match";
                            objULogin.LoginStatus = "Invalid";
                        }
                    }
                    else
                    {
                        objULogin = new clsUserLogin();
                        result.isSuccess = false;
                        result.message = "Email & Password Not Exist";
                        objULogin.LoginStatus = "Invalid";
                    }
                }
                else
                {
                    result.isSuccess = false;
                    result.message = "Email & Password Not Fill";
                    objULogin.LoginStatus = "Invalid";
                }
                //JsonResult js = new JsonResult(objULogin);
            }
            catch (Exception ex)
            {
                result.isSuccess = false;
                result.error = ex.Message;
            }
            return result;
        }

        #region old
        //private string GenerateToken()
        //{
        //    var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EvolveKeyword@123456"));
        //    //  var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EvolveKey@123"));
        //    var signingCredentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);

        //    var tokenOptions = new JwtSecurityToken(
        //        issuer: "http://localhost:4200",
        //        audience: "http://localhost:4200",
        //        claims: new List<Claim>(),
        //        expires: DateTime.Now.AddHours(9),
        //        signingCredentials: signingCredentials
        //        );
        //    var tokenstring = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //    //return Ok(new { Token = tokenstring });
        //    return tokenstring;
        //}
        #endregion
        //7/5/2023     M : SAQIB
        private string GenerateToken(string userName, List<clsUserRoles>? userRoles , int userId)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EvolveKeyword@123456"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            //________ 1. Add UserName Claims _____________
            var claims = new List<Claim>
            {

                new Claim(ClaimTypes.Name, userName),  // Adding the UserName claim
                new Claim("userId", userId.ToString())  // Adding the UserName claim
            };

            //________ 2. Add Roles Claims _____________
            if (userRoles != null && userRoles.Any())
            {
                foreach (var userRole in userRoles)
                {
                    //claims.Add(new Claim(ClaimTypes.Role, userRole.RoleName));
                }
            }

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:4200",
                audience: "http://localhost:4200",
                claims: claims,
                expires: DateTime.Now.AddHours(9),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }


        private clsUserLogin ValidateData(clsUserLogin value)
        {
            //Add Logic For Insert And Update
            clsUserLogin obj = new clsUserLogin();
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
