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
   public class officeScopeCityMapDAL : SQLDataAccess
    {
        public int InsertOfficeScopeCityMap(clsOfficeScopeCityMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeScopeCityMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeScopeCityMap(clsOfficeScopeCityMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeScopeCityMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool DeleteOfficeScopeCityMap(int officeScopeId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeScopeId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteOfficeScopeCityMap", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeScopeCityMap> SelectAllOfficeScopeCityMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeScopeCityMap");

                List<clsOfficeScopeCityMap> activeList = new List<clsOfficeScopeCityMap>();
                TExecuteReaderCmd<clsOfficeScopeCityMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeCityMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeCityMap>();
        }
        public List<clsOfficeScopeCityMap> spSelectOfficeScopeCityMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeCityMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeScopeCityMap> activeList = new List<clsOfficeScopeCityMap>();
                TExecuteReaderCmd<clsOfficeScopeCityMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeCityMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeCityMap>();
        } 
        public List<clsOfficeScopeCityMap> spSelectOfficeScopeCityMapByOfficeScopeId(int officeScopeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeCityMapByOfficeScopeId");
                comand.Parameters.AddWithValue("@officeScopeId", officeScopeId);
                List<clsOfficeScopeCityMap> activeList = new List<clsOfficeScopeCityMap>();
                TExecuteReaderCmd<clsOfficeScopeCityMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeCityMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeCityMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeScopeCityMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeScopeCityMap obj = new clsOfficeScopeCityMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeScopeId = returnData["officeScopeId"] is DBNull ? (int)0 : (int)returnData["officeScopeId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.cityName =ColumnExists(returnData, "cityName") ? returnData["cityName"] is DBNull ? (string) string.Empty : (string)returnData["cityName"]:string.Empty;
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
