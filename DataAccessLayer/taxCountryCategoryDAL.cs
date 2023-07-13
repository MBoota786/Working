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
   public class taxCountryCategoryDAL : SQLDataAccess
    {
        public int InsertTaxCountryCategory(clsTaxCountryCategory obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxCountryCategory", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taxCountryCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertTaxCountryCategory", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateTaxCountryCategory(clsTaxCountryCategory obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxCountryCategory", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taxCountryCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateTaxCountryCategory", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsTaxCountryCategory> SelectAllTaxCountryCategory(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllTaxCountryCategory");
                SetDBName(dbname);
                List<clsTaxCountryCategory> activeList = new List<clsTaxCountryCategory>();
                TExecuteReaderCmd<clsTaxCountryCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTaxCountryCategory>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsTaxCountryCategory> SelectTaxCountryCategoryById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbname);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectTaxCountryCategoryById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsTaxCountryCategory> activeList = new List<clsTaxCountryCategory>();
                TExecuteReaderCmd<clsTaxCountryCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTaxCountryCategory>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsTaxCountryCategory> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsTaxCountryCategory obj = new clsTaxCountryCategory();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.taxCountryCategory = returnData["taxCountryCategory"] is DBNull ? (string)string.Empty : (string)returnData["taxCountryCategory"];
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
