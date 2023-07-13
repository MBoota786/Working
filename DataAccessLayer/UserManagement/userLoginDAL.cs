using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
  public  class userLoginDAL : SQLDataAccess
    {
        public int InsertUserLogin(clsUserLogin ct,string DBName)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.leadCompanyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.companyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.designationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.userName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userCode", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ct.userCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.userPassword ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.userEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userImage", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.userImage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@lastLogin", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.lastLogin ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isLogin", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isLogin ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.approvalStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.approvalBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dbName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.dbName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@loginIp", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.loginIp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertUserLogin", DBName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateUserLogin(clsUserLogin ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.companyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.designationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.userName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userCode", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ct.userCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.userPassword ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userEmail", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.userEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userImage", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.userImage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@lastLogin", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.lastLogin ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isLogin", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isLogin ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.approvalStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.approvalBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateUserLogin", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateOtpPasswordById(int id, string resetOtp, DateTime otpTime)
        {
            try
            {

                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@resetOtp", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)resetOtp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@otpTime", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)otpTime ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOtpPasswordByIdById", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool ChangePasswordById(int id, string userPassword,string dbName)
        {
            try
            {
                
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)userPassword ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spChangePasswordById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }  
        public bool UpdateOfficeIdById(int id, int officeId, string dbName)
        {
            try
            {
                
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeIdById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsUserLogin> SelectAllUserLogin()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllUserLogin");

                List<clsUserLogin> activeList = new List<clsUserLogin>();
                TExecuteReaderCmd<clsUserLogin>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserLogin>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserLogin>();
        }
        public List<clsUserLogin> SelectUserLoginById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserLoginById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsUserLogin> activeList = new List<clsUserLogin>();
                TExecuteReaderCmd<clsUserLogin>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserLogin>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserLogin>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsUserLogin> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsUserLogin obj = new clsUserLogin();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.companyId = returnData["contactTypeid"] is DBNull ? (int)0 : (int)returnData["contactTypeid"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0: (int)returnData["officeId"];
                    obj.designationId = returnData["designationId"] is DBNull ? (int)0: (int)returnData["designationId"];
                    obj.userName = returnData["userName"] is DBNull ? (string)string.Empty : (string)returnData["userName"];
                    obj.userCode = returnData["userCode"] is DBNull ? (string)string.Empty : (string)returnData["userCode"];
                    obj.userPassword = returnData["userPassword"] is DBNull ? (string)string.Empty : (string)returnData["userPassword"];
                    obj.userEmail = returnData["userEmail"] is DBNull ? (string)string.Empty : (string)returnData["userEmail"];
                    obj.userImage = returnData["userImage"] is DBNull ? (string)string.Empty : (string)returnData["userImage"];
                    obj.lastLogin = returnData["lastLogin"] is DBNull ? (DateTime?)null : (DateTime)returnData["lastLogin"];
                    obj.isLogin = returnData["isLogin"] is DBNull ? (bool)false : (bool)returnData["isLogin"];
                    obj.approvalStatus = returnData["approvalStatus"] is DBNull ? (string)string.Empty : (string)returnData["approvalStatus"];
                    obj.approvalBy = returnData["approvalBy"] is DBNull ? (int)0 : (int)returnData["approvalBy"];
                    obj.approvalDate = returnData["approvalDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["approvalDate"];
                    obj.loginIp = returnData["loginIp"] is DBNull ? (string) string.Empty : (string)returnData["loginIp"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public clsUserLogin SelectAndCheckLoginClient(clsUserLogin obj,string dbName)
        {
            try
            {
                if (dbName != null && dbName != "")
                {
                    SQLDataAccess.dbname = dbName;
                }
                clsUserLogin objRet = new clsUserLogin();
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@LoginEmail", obj.userEmail);
                comand.Parameters.AddWithValue("@LoginPassword", obj.userPassword);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAndCheckLogin");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {

                        if (returnData.Read())
                        {
                            objRet.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                            objRet.leadCompanyId = returnData["leadCompanyId"] is DBNull ? (int)0 : (int)returnData["leadCompanyId"];
                            objRet.companyId = returnData["companyId"] is DBNull ? (int)0 : (int)returnData["companyId"];
                            objRet.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                            objRet.userEmail = returnData["userEmail"] is DBNull ? (string)string.Empty : (string)returnData["userEmail"];
                            objRet.loginIp = returnData["loginIp"] is DBNull ? (string) string.Empty : (string)returnData["loginIp"];
                            objRet.dbName = returnData["dbName"] is DBNull ? (string) string.Empty : (string)returnData["dbName"];
                            objRet.leadStatusName = returnData["leadStatusName"] is DBNull ? (string) string.Empty : (string)returnData["leadStatusName"];
                            objRet.HeadOfficeStatus = returnData["HeadOfficeStatus"] is DBNull ? (string) string.Empty : (string)returnData["HeadOfficeStatus"];
                            objRet.isAdmin = returnData["isAdmin"] is DBNull ? (bool) false : (bool)returnData["isAdmin"];
                        }
                        else
                        {
                            objRet = null;
                        }

                    }

                    con.Close();

                    return objRet;
                }
             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
        public clsUserLogin SelectAndCheckLoginEvolve(clsUserLogin obj)
        {
            try
            {

                clsUserLogin objRet = new clsUserLogin();
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@LoginCode", obj.userCode);
                comand.Parameters.AddWithValue("@LoginPassword", obj.userPassword);
                SetCommandType(comand, CommandType.StoredProcedure, "spCheckEvolveLogin");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {

                        if (returnData.Read())
                        {
                            objRet.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                            objRet.userCode = returnData["userCode"] is DBNull ? (string)string.Empty : (string)returnData["userCode"];
                        }
                        else
                        {
                            objRet = null;
                        }

                    }

                    con.Close();

                    return objRet;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public clsUserLogin GetPasswordById(string userCode, string dbName)
        {
            try
            {
                if (dbName != null)
                {
                    SQLDataAccess.dbname = dbName;
                }
                clsUserLogin objRet = new clsUserLogin();
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@userCode", userCode);
                SetCommandType(comand, CommandType.StoredProcedure, "spGetPasswordById");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {

                        if (returnData.Read())
                        {
                            objRet.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                            objRet.userPassword = returnData["userPassword"] is DBNull ? (string)string.Empty : (string)returnData["userPassword"];
                        }
                        else
                        {
                            objRet = null;
                        }

                    }

                    con.Close();

                    return objRet;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
        public clsUserLogin SelectUserInfoForEmailByUserEmail(string userEmail, string dbName)
        {
            try
            {
                if (dbName != null)
                {
                    SQLDataAccess.dbname = dbName;
                }
                clsUserLogin objRet = new clsUserLogin();
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@userEmail", userEmail);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserInfoForEmailByUserEmail");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {

                        if (returnData.Read())
                        {
                            objRet.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                            objRet.userName = returnData["userName"] is DBNull ? (string)string.Empty : (string)returnData["userName"];
                            objRet.userCode = returnData["userCode"] is DBNull ? (string)string.Empty : (string)returnData["userCode"];
                            objRet.userEmail = returnData["userEmail"] is DBNull ? (string)string.Empty : (string)returnData["userEmail"];
                        }
                        else
                        {
                            objRet = null;
                        }

                    }

                    con.Close();

                    return objRet;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
        public bool OTPCheckVerify(int id, DateTime otpCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@otpTime", otpCode);
                cmd.Parameters.AddWithValue("@id", id);
                return IsRecordExistCheck(cmd, "spOTPCheck", null);
            }
        }
    }
}
