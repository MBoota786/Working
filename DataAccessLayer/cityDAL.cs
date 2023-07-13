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
   public class cityDAL : SQLDataAccess
    {
        public int InsertCity(clsCity ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.cityName ?? DBNull.Value);
                Id =  ExecuteInsertCommandReturnId(comm, "spInsertCity", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCity(clsCity ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.cityName ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCity", ls.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsCity> SelectAllCity(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCity");

                List<clsCity> cityList = new List<clsCity>();
                TExecuteReaderCmd<clsCity>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCity>, ref cityList);
                if (cityList != null)
                {
                    return cityList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsCity> SelectCityById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCityById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCity> cityList = new List<clsCity>();
                TExecuteReaderCmd<clsCity>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCity>, ref cityList);
                if (cityList != null)
                {
                    return cityList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsCity> SelectCityByStateProvinceId(int stateProvinceId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCityByStateProvinceId");
                comand.Parameters.AddWithValue("@stateProvinceId", stateProvinceId);
                List<clsCity> cityList = new List<clsCity>();
                TExecuteReaderCmd<clsCity>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCity>, ref cityList);
                if (cityList != null)
                {
                    return cityList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsCity> activeLegalStatus)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCity obj = new clsCity();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.countryName = returnData["countryName"] is DBNull ? (string)string.Empty : (string)returnData["countryName"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.stateProvinceName = returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"];
                    obj.cityName = returnData["cityName"] is DBNull ? (string)string.Empty : (string)returnData["cityName"];
                    obj.cityLatitude = returnData["cityLatitude"] is DBNull ? (string)string.Empty : (string)returnData["cityLatitude"];
                    obj.cityLongitude = returnData["cityLongitude"] is DBNull ? (string)string.Empty : (string)returnData["cityLongitude"];
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
