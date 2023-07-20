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
    public class officeCategoryRelationStandardMapDAL:SQLDataAccess
    {
        public int InsertOfficeCategoryRelationStandardMap(clsOfficeCategoryRelationStandardMap obj)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeCategoryRelationStandardMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }

        public bool UpdateOfficeCategoryRelationStandardMap(clsOfficeCategoryRelationStandardMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeCategoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeCategoryRelationStandardMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool DeleteOfficeCategoryRelationStandardMap(int officeCategoryRelationId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeCategoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeCategoryRelationId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteOfficeCategoryRelationStandardMap", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<clsOfficeCategoryRelationStandardMap> SelectOfficeCategoryRelationStandardMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationStandardMap");

                List<clsOfficeCategoryRelationStandardMap> activeList = new List<clsOfficeCategoryRelationStandardMap>();
                TExecuteReaderCmd<clsOfficeCategoryRelationStandardMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryRelationStandardMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryRelationStandardMap>();
        }

        public List<clsOfficeCategoryRelationStandardMap> SelectOfficeCategoryRelationStandardMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationStandardMap");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeCategoryRelationStandardMap> activeList = new List<clsOfficeCategoryRelationStandardMap>();
                TExecuteReaderCmd<clsOfficeCategoryRelationStandardMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryRelationStandardMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryRelationStandardMap>();
        }

        public List<clsOfficeCategoryRelationStandardMap> spSelectOfficeCategoryRelationStandardMapByOfficeScopeId(int officeCategoryRelationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeCategoryRelationStandardMapByOfficeCateRelId");
                comand.Parameters.AddWithValue("@officeCategoryRelationId", officeCategoryRelationId);
                List<clsOfficeCategoryRelationStandardMap> activeList = new List<clsOfficeCategoryRelationStandardMap>();
                TExecuteReaderCmd<clsOfficeCategoryRelationStandardMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeCategoryRelationStandardMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeCategoryRelationStandardMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeCategoryRelationStandardMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeCategoryRelationStandardMap obj = new clsOfficeCategoryRelationStandardMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeCategoryRelationId = returnData["officeCategoryRelationId"] is DBNull ? (int)0 : (int)returnData["officeCategoryRelationId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.standardName = ColumnExists(returnData, "standardName") ? returnData["standardName"] is DBNull ? (string)string.Empty : (string)returnData["standardName"] : string.Empty;
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
