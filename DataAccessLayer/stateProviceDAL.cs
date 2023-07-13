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
   public class stateProviceDAL :SQLDataAccess
    {
        public int InsertStateProvince(clsStateProvince ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.stateProvinceName ?? DBNull.Value);
                ExecuteInsertCommandReturnId(comm, "spInsertStateProvince", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStateProvince(clsStateProvince ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.stateProvinceName ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStateProvince", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStateProvince> SelectAllStateProvince(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStateProvince");

                List<clsStateProvince> stateProvinceList = new List<clsStateProvince>();
                TExecuteReaderCmd<clsStateProvince>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsStateProvince>, ref stateProvinceList);
                if (stateProvinceList != null)
                {
                    return stateProvinceList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsStateProvince> SelectStateProvinceById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStateProvinceById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStateProvince> stateProvinceList = new List<clsStateProvince>();
                TExecuteReaderCmd<clsStateProvince>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsStateProvince>, ref stateProvinceList);
                if (stateProvinceList != null)
                {
                    return stateProvinceList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsStateProvince> SelectStateProvinceByCountryId(int countryId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStateProvinceByCountryId");
                comand.Parameters.AddWithValue("@countryId", countryId);
                List<clsStateProvince> stateProvinceList = new List<clsStateProvince>();
                TExecuteReaderCmd<clsStateProvince>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsStateProvince>, ref stateProvinceList);
                if (stateProvinceList != null)
                {
                    return stateProvinceList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsStateProvince> activeLegalStatus)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStateProvince obj = new clsStateProvince();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.countryName = returnData["countryName"] is DBNull ? (string)string.Empty : (string)returnData["countryName"];
                    obj.stateProvinceName = returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"];
                    obj.stateProvinceCode = returnData["stateProvinceCode"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceCode"];
                    obj.stateProvinceLatitude = returnData["stateProvinceLatitude"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceLatitude"];
                    obj.stateProvinceLongitude = returnData["stateProvinceLongitude"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceLongitude"];
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
