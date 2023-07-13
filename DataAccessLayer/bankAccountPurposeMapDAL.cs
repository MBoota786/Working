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
   public class bankAccountPurposeMapDAL : SQLDataAccess
    {
        public int InsertBankAccountPurposeMap(clsBankAccountPurposeMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@bankAccountPurposeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.bankAccountPurposeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeBankDetailsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeBankDetailsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertBankAccountPurposeMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateBankAccountPurposeMap(clsBankAccountPurposeMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@bankAccountPurposeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.bankAccountPurposeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeBankDetailsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeBankDetailsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateBankAccountPurposeMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool DeleteBankAccountPurposeMapByOfficeBankDetailsId(int officeBankDetailsId,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeBankDetailsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeBankDetailsId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteBankAccountPurposeMapByOfficeBankDetailsId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsBankAccountPurposeMap> SelectAllBankAccountPurposeMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllBankAccountPurposeMap");

                List<clsBankAccountPurposeMap> activeList = new List<clsBankAccountPurposeMap>();
                TExecuteReaderCmd<clsBankAccountPurposeMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankAccountPurposeMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsBankAccountPurposeMap>();
        }
        public List<clsBankAccountPurposeMap> SelectBankAccountPurposeMapByOfficeBankDetailsId(int officeBankDetailsId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBankAccountPurposeMapByOfficeBankDetailsId");
                comand.Parameters.AddWithValue("@officeBankDetailsId", officeBankDetailsId);
                List<clsBankAccountPurposeMap> activeList = new List<clsBankAccountPurposeMap>();
                TExecuteReaderCmd<clsBankAccountPurposeMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankAccountPurposeMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsBankAccountPurposeMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsBankAccountPurposeMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsBankAccountPurposeMap obj = new clsBankAccountPurposeMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.bankAccountPurposeId = returnData["bankAccountPurposeId"] is DBNull ? (int)0 : (int)returnData["bankAccountPurposeId"];
                    obj.officeBankDetailsId = returnData["officeBankDetailsId"] is DBNull ? (int)0 : (int)returnData["officeBankDetailsId"];
                    obj.bankAccountPurpose = returnData["bankAccountPurpose"] is DBNull ? (string) string.Empty : (string)returnData["bankAccountPurpose"];
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
