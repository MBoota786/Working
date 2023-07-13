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
   public class leadCompanyDAL : SQLDataAccess
    {
        public int InsertLeadCompany(clsLeadCompany obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionPlanId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.subscriptionPlanId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadUserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadUserName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadEmailAddress", SqlDbType.VarChar, 50 , ParameterDirection.Input, (object)obj.leadEmailAddress?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyAddress", SqlDbType.VarChar, 50 , ParameterDirection.Input, (object)obj.leadCompanyAddress?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4 , ParameterDirection.Input, (object)obj.countryId?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProviceId", SqlDbType.Int, 4 , ParameterDirection.Input, (object)obj.stateProviceId?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4 , ParameterDirection.Input, (object)obj.cityId?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyWebsite", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyPoBox", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyPoBox ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyPostalCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyCountryCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyAreaCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyCellNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyExtension", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.leadCompanyExtension ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyCellCountryCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyCellCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyTypeId", SqlDbType.Int, 4 , ParameterDirection.Input, (object)obj.companyTypeId ?? DBNull.Value);
                if (obj.leadDate == null)
                {
                    obj.leadDate = DateTime.Now;
                }
                AddParamToSQLCmd(comm, "@leadDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.leadDate ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@isEmailSent", SqlDbType.Bit , 1, ParameterDirection.Input, (object)obj.isEmailSent ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@assignUser", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignUser ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@assignBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignBy ?? DBNull.Value);
                if (obj.paymentDate < DateTime.MinValue)
                {
                    obj.paymentDate = null;
                }
               AddParamToSQLCmd(comm, "@paymentDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.paymentDate ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@paymentRefNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.paymentRefNo ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
               Id = ExecuteInsertCommandReturnId(comm, "spInsertLeadCompany",null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateLeadCompany(clsLeadCompany obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionPlanId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.subscriptionPlanId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadUserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadUserName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadEmailAddress", SqlDbType.VarChar, 50, ParameterDirection.Input, (object)obj.leadEmailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyAddress", SqlDbType.VarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyWebsite", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyPoBox", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyPoBox ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyPostalCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyCountryCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyAreaCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyCellNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyPhone", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyExtension", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.leadCompanyExtension ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyCellCountryCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.leadCompanyCellCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.companyTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.leadDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignUser", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignUser ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.paymentDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentRefNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.paymentRefNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateLeadCompany", null);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public bool UpdateLeadStatusByLeadCompanyId(clsLeadCompany obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateLeadStatusByLeadCompanyId", null);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsLeadCompany> SelectAllLeadCompany(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
               // SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllLeadCompany");

                List<clsLeadCompany> activeList = new List<clsLeadCompany>();
                TExecuteReaderCmd<clsLeadCompany>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLeadCompany>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsLeadCompany>();
        }
        public List<clsLeadCompany> SelectLeadCompanyById(int id,string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
             //   SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectLeadCompanyById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsLeadCompany> activeList = new List<clsLeadCompany>();
                TExecuteReaderCmd<clsLeadCompany>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLeadCompany>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsLeadCompany>();
        }
     
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsLeadCompany> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsLeadCompany obj = new clsLeadCompany();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.leadStatusId = returnData["leadStatusId"] is DBNull ? (int)0 : (int)returnData["leadStatusId"];
                    obj.subscriptionPlanId = returnData["subscriptionPlanId"] is DBNull ? (int)0 : (int)returnData["subscriptionPlanId"];
                    obj.leadUserName = returnData["leadUserName"] is DBNull ? (string)string.Empty : (string)returnData["leadUserName"];
                    obj.leadCompanyName = returnData["leadCompanyName"] is DBNull ? (string)string.Empty : (string)returnData["leadCompanyName"];
                    obj.leadEmailAddress = returnData["leadEmailAddress"] is DBNull ? (string)string.Empty : (string)returnData["leadEmailAddress"];
                    obj.leadCompanyAddress = returnData["leadCompanyAddress"] is DBNull ? (string)string.Empty : (string)returnData["leadCompanyAddress"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.stateProviceId = returnData["stateProviceId"] is DBNull ? (int)0 : (int)returnData["stateProviceId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.leadCompanyWebsite = returnData["leadCompanyWebsite"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyWebsite"];
                    obj.leadCompanyPoBox = returnData["leadCompanyPoBox"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyPoBox"];
                    obj.leadCompanyPostalCode = returnData["leadCompanyPostalCode"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyPostalCode"];
                    obj.leadCompanyCountryCode = returnData["leadCompanyCountryCode"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyCountryCode"];
                    obj.leadCompanyAreaCode = returnData["leadCompanyAreaCode"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyAreaCode"];
                    obj.leadCompanyCellNo = returnData["leadCompanyCellNo"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyCellNo"];
                    obj.leadCompanyPhone = returnData["leadCompanyPhone"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyPhone"];
                    obj.leadCompanyExtension = returnData["leadCompanyExtension"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyExtension"];
                    obj.leadCompanyCellCountryCode = returnData["leadCompanyCellCountryCode"] is DBNull ? (string) string.Empty : (string)returnData["leadCompanyCellCountryCode"];
                    obj.companyTypeId = returnData["companyTypeId"] is DBNull ? (int)0 : (int)returnData["companyTypeId"];
                    obj.leadDate = returnData["leadDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["leadDate"];
                    obj.isEmailSent = returnData["isEmailSent"] is DBNull ? (bool)true : (bool)returnData["isEmailSent"];
                    obj.assignUser = returnData["assignUser"] is DBNull ? (int) 0 : (int)returnData["assignUser"];
                    obj.assignBy = returnData["assignBy"] is DBNull ? (int) 0 : (int)returnData["assignBy"];
                    obj.paymentDate = returnData["paymentDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["paymentDate"];
                    obj.paymentRefNo = returnData["paymentRefNo"] is DBNull ? (string) string.Empty : (string)returnData["paymentRefNo"];
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
        public bool IsLeadCompanyNameAlreadyExist(string leadCompanyName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@leadCompanyName", leadCompanyName);
                return IsRecordExistCheck(cmd, "spIsLeadCompanyNameAlreadyExist", null);
            }
        }
        public bool IsLeadCompanyEmailAlreadyExist(string leadEmailAddress)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@leadEmailAddress", leadEmailAddress);
                return IsRecordExistCheck(cmd, "spIsLeadCompanyEmailAlreadyExist", null);
            }
        }
    }
}
