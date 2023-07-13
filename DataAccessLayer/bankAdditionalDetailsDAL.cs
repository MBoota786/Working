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
  public  class bankAdditionalDetailsDAL : SQLDataAccess
    {
        public int InsertbankAdditionalDetails(clsBankAdditionalDetails ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@fieldTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.fieldTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@fieldInformation", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.fieldInformation ?? DBNull.Value);
             
               
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertBankAdditionalDetails", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdatebankAdditionalDetails(clsBankAdditionalDetails ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@fieldTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.fieldTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@fieldInformation", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.fieldInformation ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateBankAdditionalDetails", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsBankAdditionalDetails> SelectAllBankAdditionalDetails(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllBankAdditionalDetails");

                List<clsBankAdditionalDetails> contactList = new List<clsBankAdditionalDetails>();
                TExecuteReaderCmd<clsBankAdditionalDetails>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankAdditionalDetails>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsBankAdditionalDetails> SelectBankAdditionalDetailsById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBankAdditionalDetailsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsBankAdditionalDetails> contactList = new List<clsBankAdditionalDetails>();
                TExecuteReaderCmd<clsBankAdditionalDetails>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankAdditionalDetails>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsBankAdditionalDetails> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsBankAdditionalDetails obj = new clsBankAdditionalDetails();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeBankId = returnData["officeBankId"] is DBNull ? (int)0 : (int)returnData["officeBankId"];
                    obj.bankName = returnData["bankName"] is DBNull ? (string)string.Empty : (string)returnData["bankName"];
                    obj.fieldTitle = returnData["fieldTitle"] is DBNull ? (string)string.Empty : (string)returnData["fieldTitle"];
                    obj.fieldInformation = returnData["fieldInformation"] is DBNull ? (string)string.Empty : (string)returnData["fieldInformation"];
      
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
