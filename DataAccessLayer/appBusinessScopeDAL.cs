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
   public class appBusinessScopeDAL : SQLDataAccess
    {
        public int InsertAppBusinessScope(clsAppBusinessScope obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isProduct", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isProduct ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isService", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isService?? DBNull.Value);
                AddParamToSQLCmd(comm, "@scopeDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.scopeDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@scopeRemarks", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.scopeRemarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppBusinessScope", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }

        public bool UpdateAppBusinessScope(clsAppBusinessScope obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isProduct", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isProduct ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isService", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isService ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@scopeDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.scopeDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@scopeRemarks", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.scopeRemarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppBusinessScope", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppBusinessScope> SelectAllBusinessScope(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllBusinessScope");

                List<clsAppBusinessScope> activeList = new List<clsAppBusinessScope>();
                TExecuteReaderCmd<clsAppBusinessScope>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppBusinessScope>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppBusinessScope>();
        }
        public List<clsAppBusinessScope> SelectBusinessScopeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBusinessScopeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppBusinessScope> activeList = new List<clsAppBusinessScope>();
                TExecuteReaderCmd<clsAppBusinessScope>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppBusinessScope>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppBusinessScope>();
        }
        public List<clsAppBusinessScope> SelectBusinessScopeByAppId(int appId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBusinessScopeByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsAppBusinessScope> activeList = new List<clsAppBusinessScope>();
                TExecuteReaderCmd<clsAppBusinessScope>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppBusinessScope>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppBusinessScope>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppBusinessScope> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppBusinessScope obj = new clsAppBusinessScope();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.isProduct = returnData["isProduct"] is DBNull ? (bool)false : (bool)returnData["isProduct"];
                    obj.isService = returnData["isService"] is DBNull ? (bool)false : (bool)returnData["isService"];
                    obj.scopeDescription = returnData["scopeDescription"] is DBNull ? (string)string.Empty : (string)returnData["scopeDescription"];
                    obj.scopeRemarks = returnData["scopeRemarks"] is DBNull ? (string)string.Empty : (string)returnData["scopeRemarks"];
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
