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
   public class bankAccountPurposeDAL : SQLDataAccess
    {
        public int InsertBankAccountPurpose(clsBankAccountPurpose obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@bankAccountPurpose", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.bankAccountPurpose ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertBankAccountPurpose", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateBankAccountPurpose(clsBankAccountPurpose obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@bankAccountPurpose", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.bankAccountPurpose ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateBankAccountPurpose", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsBankAccountPurpose> SelectAllBankAccountPurpose(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllBankAccountPurpose");

                List<clsBankAccountPurpose> activeList = new List<clsBankAccountPurpose>();
                TExecuteReaderCmd<clsBankAccountPurpose>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankAccountPurpose>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsBankAccountPurpose>();
        }
        public List<clsBankAccountPurpose> SelectBankAccountPurposeById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBankAccountPurposeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsBankAccountPurpose> activeList = new List<clsBankAccountPurpose>();
                TExecuteReaderCmd<clsBankAccountPurpose>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankAccountPurpose>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsBankAccountPurpose>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsBankAccountPurpose> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsBankAccountPurpose obj = new clsBankAccountPurpose();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.bankAccountPurpose = returnData["bankAccountPurpose"] is DBNull ? (string)string.Empty : (string)returnData["bankAccountPurpose"];
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
