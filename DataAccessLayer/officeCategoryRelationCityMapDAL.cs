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
    public class officeCategoryRelationCityMapDAL:SQLDataAccess
    {
        public int InsertOfficecategoryRelationCityMap(clsOfficeCategoryCityMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeCategoryRelationCityMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeScopeCityMap(clsOfficeCategoryCityMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeCategoryRelationCityMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool DeleteOfficeCategoryRelationCityMap(int officeCategoryRelationId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeCategoryRelationId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteOfficeCategoryRelationCityMap", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeCategoryCityMap> SelectAllOfficeScopeCityMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeCategoryRelationCityMap");

                List<clsOfficeCategoryCityMap> activeList = new List<clsOfficeCategoryCityMap>();
                TExecuteReaderCmd<clsOfficeCategoryCityMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryCityMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryCityMap>();
        }
        public List<clsOfficeCategoryCityMap> spSelectOfficeCategoryRelCityMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationCityMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeCategoryCityMap> activeList = new List<clsOfficeCategoryCityMap>();
                TExecuteReaderCmd<clsOfficeCategoryCityMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryCityMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryCityMap>();
        }
        public List<clsOfficeCategoryCityMap> spSelectOfficeCategoryRelCityMapByOfficeCatRelId(int officeCategoryRelationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationCityMapByOfficeCategoryRelationId");
                comand.Parameters.AddWithValue("@officeCategoryRelationId", officeCategoryRelationId);
                List<clsOfficeCategoryCityMap> activeList = new List<clsOfficeCategoryCityMap>();
                TExecuteReaderCmd<clsOfficeCategoryCityMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryCityMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryCityMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeCategoryCityMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeCategoryCityMap obj = new clsOfficeCategoryCityMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeCategoryRelationId = returnData["officeCategoryRelationId"] is DBNull ? (int)0 : (int)returnData["officeCategoryRelationId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.cityName = ColumnExists(returnData, "cityName") ? returnData["cityName"] is DBNull ? (string)string.Empty : (string)returnData["cityName"] : string.Empty;
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
