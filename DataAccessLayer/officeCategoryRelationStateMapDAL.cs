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
    public class officeCategoryRelationStateMapDAL: SQLDataAccess
    {
        public int InsertOfficeCategoryRelationStateMap(clsOfficeCategoryStateMap obj)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeCategoryRelationStateMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        public bool UpdateOfficeCategoryRelationStateMap(clsOfficeCategoryStateMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeCategoryRelationStateMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool DeleteOfficeCategoryRelationMap(int officeCategoryRelationId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeCategoryRelationId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteOfficeCategoryRelationStateMap", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<clsOfficeCategoryStateMap> spSelectOfficeScopeStateMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationStateMap");

                List<clsOfficeCategoryStateMap> activeList = new List<clsOfficeCategoryStateMap>();
                TExecuteReaderCmd<clsOfficeCategoryStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryStateMap>();
        }
        public List<clsOfficeCategoryStateMap> SelectOfficeScopeStateMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationStateMap");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeCategoryStateMap> activeList = new List<clsOfficeCategoryStateMap>();
                TExecuteReaderCmd<clsOfficeCategoryStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryStateMap>();
        }
        public List<clsOfficeCategoryStateMap> spSelectOfficeCategoryRelationStateMapByOfficeCategoryRelId(int officeCategoryRelationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationStateMapByCategoryRelationId");
                comand.Parameters.AddWithValue("@officeCategoryRelationId", officeCategoryRelationId);
                List<clsOfficeCategoryStateMap> activeList = new List<clsOfficeCategoryStateMap>();
                TExecuteReaderCmd<clsOfficeCategoryStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryStateMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeCategoryStateMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeCategoryStateMap obj = new clsOfficeCategoryStateMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeCategoryRelationId = returnData["officeCategoryRelationId"] is DBNull ? (int)0 : (int)returnData["officeCategoryRelationId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.stateProvinceName = ColumnExists(returnData, "stateProvinceName") ? returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"] : string.Empty;

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
