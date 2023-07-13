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
  public  class countryDAL : SQLDataAccess
    {
        public int InsertCountry(clsCountry ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.countryName ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertCountry", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCountry(clsCountry ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.countryName ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCountry", ls.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsCountry> SelectAllCountry(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCountry");

                List<clsCountry> countryList = new List<clsCountry>();
                TExecuteReaderCmd<clsCountry>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCountry>, ref countryList);
                if (countryList != null)
                {
                    return countryList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsCountry>();
        } 
        public List<clsCountry> SelectAllCountryForDemographicScope(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCountryForDemographicScope");

                List<clsCountry> countryList = new List<clsCountry>();
                TExecuteReaderCmd<clsCountry>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCountry>, ref countryList);
                if (countryList != null)
                {
                    return countryList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsCountry>();
        }
        public List<clsCountry> SelectCountryById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCountryById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCountry> countryList = new List<clsCountry>();
                TExecuteReaderCmd<clsCountry>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCountry>, ref countryList);
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
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsCountry> activeLegalStatus)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCountry obj = new clsCountry();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.countryName = returnData["countryName"] is DBNull ? (string)string.Empty : (string)returnData["countryName"];
                    obj.countryIso2 = returnData["countryIso2"] is DBNull ? (string)string.Empty : (string)returnData["countryIso2"];
                    obj.countryIso3 = returnData["countryIso3"] is DBNull ? (string)string.Empty : (string)returnData["countryIso3"];
                    obj.currency = returnData["currency"] is DBNull ? (string)string.Empty : (string)returnData["currency"];
                    obj.currencyName = returnData["currencyName"] is DBNull ? (string)string.Empty : (string)returnData["currencyName"];
                    obj.currencySymbol = returnData["currencySymbol"] is DBNull ? (string)string.Empty : (string)returnData["currencySymbol"];
                    obj.region = returnData["region"] is DBNull ? (string)string.Empty : (string)returnData["region"];
                    obj.subRegion = returnData["subRegion"] is DBNull ? (string)string.Empty : (string)returnData["subRegion"];
                    obj.countryLatitude = returnData["countryLatitude"] is DBNull ? (string)string.Empty : (string)returnData["countryLatitude"];
                    obj.countryLongitude = returnData["countryLongitude"] is DBNull ? (string)string.Empty : (string)returnData["countryLongitude"];
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
