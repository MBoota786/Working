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
   public class leadCompanyContactPersonDAL : SQLDataAccess
    {
        public int InsertLeadCompanyContactPersons(clsLeadCompanyContactPerson obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadCompanyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminUserFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminUserFirstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminUserMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminUserMiddleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminUserLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminUserLastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminCountryCode", SqlDbType.NVarChar, 5 , ParameterDirection.Input, (object)obj.adminCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminAreaCode", SqlDbType.NVarChar, 5 , ParameterDirection.Input, (object)obj.adminAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminContactNumber", SqlDbType.NVarChar, 50 , ParameterDirection.Input, (object)obj.adminContactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminExtension", SqlDbType.NVarChar, 5 , ParameterDirection.Input, (object)obj.adminExtension ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminCellNumber", SqlDbType.NVarChar, 50 , ParameterDirection.Input, (object)obj.adminCellNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminCellCountryCode", SqlDbType.NVarChar, 5 , ParameterDirection.Input, (object)obj.adminCellCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminEmailAddress", SqlDbType.NVarChar, 50 , ParameterDirection.Input, (object)obj.adminEmailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAdminEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAdminEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupUserFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupUserFirstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupUserMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupUserMiddleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupUserLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupUserLastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupCountryCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupAreaCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupContactNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupContactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupExtension", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupExtension ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupCellNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupCellNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupCellCountryCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupCellCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupEmailAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupEmailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSetupEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSetupEmailSent ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
               Id = ExecuteInsertCommandReturnId(comm, "spInsertLeadCompanyContactPersons", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateLeadCompanyContactPersons(clsLeadCompanyContactPerson obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadCompanyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminUserFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminUserFirstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminUserMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminUserMiddleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminUserLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminUserLastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminCountryCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.adminCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminAreaCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.adminAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminContactNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminContactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminExtension", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.adminExtension ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminCellNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminCellNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminCellCountryCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.adminCellCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adminEmailAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.adminEmailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAdminEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAdminEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupUserFirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupUserFirstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupUserMiddleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupUserMiddleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupUserLastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupUserLastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupCountryCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupAreaCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupContactNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupContactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupExtension", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupExtension ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupCellNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupCellNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupCellCountryCode", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.setupCellCountryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@setupEmailAddress", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.setupEmailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSetupEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSetupEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateLeadCompanyContactPersons", null);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsLeadCompanyContactPerson> SelectAllLeadCompanyContactPersons(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
               // SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllLeadCompanyContactPersons");

                List<clsLeadCompanyContactPerson> activeList = new List<clsLeadCompanyContactPerson>();
                TExecuteReaderCmd<clsLeadCompanyContactPerson>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLeadCompanyContactPerson>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsLeadCompanyContactPerson>();
        }
        public List<clsLeadCompanyContactPerson> SelectLeadCompanyContactPersonsById(int id,string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
               // SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectLeadCompanyContactPersonsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsLeadCompanyContactPerson> activeList = new List<clsLeadCompanyContactPerson>();
                TExecuteReaderCmd<clsLeadCompanyContactPerson>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLeadCompanyContactPerson>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsLeadCompanyContactPerson>();
        }
        public List<clsLeadCompanyContactPerson> SelectLeadCompanyContactPersonsByLeadCompanyId(int id,string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
               // SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectLeadCompanyContactPersonsByLeadCompanyId");
                comand.Parameters.AddWithValue("@id", id);
                List<clsLeadCompanyContactPerson> activeList = new List<clsLeadCompanyContactPerson>();
                TExecuteReaderCmd<clsLeadCompanyContactPerson>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLeadCompanyContactPerson>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsLeadCompanyContactPerson>();
        }
     
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsLeadCompanyContactPerson> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsLeadCompanyContactPerson obj = new clsLeadCompanyContactPerson();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.leadCompanyId = returnData["leadCompanyId"] is DBNull ? (int)0 : (int)returnData["leadCompanyId"];
                    obj.adminUserFirstName = returnData["adminUserFirstName"] is DBNull ? (string)string.Empty : (string)returnData["adminUserFirstName"];
                    obj.adminUserMiddleName = returnData["adminUserMiddleName"] is DBNull ? (string)string.Empty : (string)returnData["adminUserMiddleName"];
                    obj.adminUserLastName = returnData["adminUserLastName"] is DBNull ? (string)string.Empty : (string)returnData["adminUserLastName"];
                    obj.adminCountryCode = returnData["adminCountryCode"] is DBNull ? (string)string.Empty : (string)returnData["adminCountryCode"];
                    obj.adminAreaCode = returnData["adminAreaCode"] is DBNull ? (string)string.Empty : (string)returnData["adminAreaCode"];
                    obj.adminContactNumber = returnData["adminContactNumber"] is DBNull ? (string)string.Empty : (string)returnData["adminContactNumber"];
                    obj.adminExtension = returnData["adminExtension"] is DBNull ? (string)string.Empty : (string)returnData["adminExtension"];
                    obj.adminCellNumber = returnData["adminCellNumber"] is DBNull ? (string)string.Empty : (string)returnData["adminCellNumber"];
                    obj.adminCellCountryCode = returnData["adminCellCountryCode"] is DBNull ? (string)string.Empty : (string)returnData["adminCellCountryCode"];
                    obj.adminEmailAddress = returnData["adminEmailAddress"] is DBNull ? (string)string.Empty : (string)returnData["adminEmailAddress"];
                    obj.isAdminEmailSent = returnData["isAdminEmailSent"] is DBNull ? (bool)false : (bool)returnData["isAdminEmailSent"];
                    obj.setupUserFirstName = returnData["setupUserFirstName"] is DBNull ? (string)string.Empty : (string)returnData["setupUserFirstName"];
                    obj.setupUserMiddleName = returnData["setupUserMiddleName"] is DBNull ? (string)string.Empty : (string)returnData["setupUserMiddleName"];
                    obj.setupUserLastName = returnData["setupUserLastName"] is DBNull ? (string)string.Empty : (string)returnData["setupUserLastName"];
                    obj.setupCountryCode = returnData["setupCountryCode"] is DBNull ? (string)string.Empty : (string)returnData["setupCountryCode"];
                    obj.setupAreaCode = returnData["setupAreaCode"] is DBNull ? (string)string.Empty : (string)returnData["setupAreaCode"];
                    obj.setupContactNumber = returnData["setupContactNumber"] is DBNull ? (string)string.Empty : (string)returnData["setupContactNumber"];
                    obj.setupExtension = returnData["setupExtension"] is DBNull ? (string)string.Empty : (string)returnData["setupExtension"];
                    obj.setupCellNumber = returnData["setupCellNumber"] is DBNull ? (string)string.Empty : (string)returnData["setupCellNumber"];
                    obj.setupCellCountryCode = returnData["setupCellCountryCode"] is DBNull ? (string)string.Empty : (string)returnData["setupCellCountryCode"];
                    obj.setupEmailAddress = returnData["setupEmailAddress"] is DBNull ? (string)string.Empty : (string)returnData["setupEmailAddress"];
                    obj.isSetupEmailSent = returnData["isSetupEmailSent"] is DBNull ? (bool)false : (bool)returnData["isSetupEmailSent"];
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
    }
}
