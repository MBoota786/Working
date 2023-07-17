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
   public class officeScopeStandardMapDAL : SQLDataAccess
    {
        public int InsertOfficeScopeStandardMap(clsOfficeScopeStandardMap obj)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeScopeStandardMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeScopeStandardMap(clsOfficeScopeStandardMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeScopeStandardMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }   
        public bool DeleteOfficeScopeStandardMap(int officeScopeId,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeScopeId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteOfficeScopeStandardMap", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeScopeStandardMap> SelectOfficeScopeStandardMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeStandardMap");

                List<clsOfficeScopeStandardMap> activeList = new List<clsOfficeScopeStandardMap>();
                TExecuteReaderCmd<clsOfficeScopeStandardMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeStandardMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeStandardMap>();
        }
        public List<clsOfficeScopeStandardMap> SelectOfficeScopeStandardMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeStandardMap");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeScopeStandardMap> activeList = new List<clsOfficeScopeStandardMap>();
                TExecuteReaderCmd<clsOfficeScopeStandardMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeStandardMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeStandardMap>();
        } 
        public List<clsOfficeScopeStandardMap> spSelectOfficeScopeStandardMapByOfficeScopeId(int officeScopeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeStandardMapByOfficeScopeId");
                comand.Parameters.AddWithValue("@officeScopeId", officeScopeId);
                List<clsOfficeScopeStandardMap> activeList = new List<clsOfficeScopeStandardMap>();
                TExecuteReaderCmd<clsOfficeScopeStandardMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeStandardMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeStandardMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeScopeStandardMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeScopeStandardMap obj = new clsOfficeScopeStandardMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeScopeId = returnData["officeScopeId"] is DBNull ? (int)0 : (int)returnData["officeScopeId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.standardName =ColumnExists(returnData, "standardName") ? returnData["standardName"] is DBNull ? (string) string.Empty : (string)returnData["standardName"]:string.Empty;
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
