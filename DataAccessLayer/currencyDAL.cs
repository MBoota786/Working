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
  public  class currencyDAL : SQLDataAccess
    {
        public int InsertCurrency(clsCurrency ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.currencyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyShortName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.currencyShortName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@symbol", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.symbol ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertCurrency", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCurrency(clsCurrency ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.currencyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyShortName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.currencyShortName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@symbol", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.symbol ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCurrency", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsCurrency> SelectAllCurrency(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCurrency");

                List<clsCurrency> countryList = new List<clsCurrency>();
                TExecuteReaderCmd<clsCurrency>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCountry>, ref countryList);
                if (countryList != null)
                {
                    return countryList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsCurrency> SelectCurrencyById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);   
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCurrencyById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCurrency> countryList = new List<clsCurrency>();
                TExecuteReaderCmd<clsCurrency>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCountry>, ref countryList);
                if (countryList != null)
                {
                    return countryList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsCurrency> activeLegalStatus)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCurrency obj = new clsCurrency();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.currencyName = returnData["currencyName"] is DBNull ? (string)string.Empty : (string)returnData["currencyName"];
                    obj.currencyShortName = returnData["currencyShortName"] is DBNull ? (string)string.Empty : (string)returnData["currencyShortName"];
                    obj.symbol = returnData["symbol"] is DBNull ? (string)string.Empty : (string)returnData["symbol"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeLegalStatus.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
