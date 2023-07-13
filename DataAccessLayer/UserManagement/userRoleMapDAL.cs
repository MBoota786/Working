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
   public class userRoleMapDAL : SQLDataAccess
    {
        public int InsertUserRoleMap(clsUserRoleMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userLoginId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.userLoginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleApprovalStatus ", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.roleApprovalStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertUserRoleMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateUserRoleMap(clsUserRoleMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userLoginId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.userLoginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleApprovalStatus ", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.roleApprovalStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateUserRoleMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsUserRoleMap> SelectAllUserRoleMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllUserRoleMap");

                List<clsUserRoleMap> activeList = new List<clsUserRoleMap>();
                TExecuteReaderCmd<clsUserRoleMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRoleMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRoleMap>();
        }
        public List<clsUserRoleMap> SelectUserRoleMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserRoleMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsUserRoleMap> activeList = new List<clsUserRoleMap>();
                TExecuteReaderCmd<clsUserRoleMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRoleMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRoleMap>();
        }  
        public List<clsUserRoleMap> SelectUserRoleMapByUserId(int userLoginId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserRoleMapByUserId");
                comand.Parameters.AddWithValue("@userLoginId", userLoginId);
                List<clsUserRoleMap> activeList = new List<clsUserRoleMap>();
                TExecuteReaderCmd<clsUserRoleMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRoleMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRoleMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsUserRoleMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsUserRoleMap obj = new clsUserRoleMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.userLoginId = returnData["userLoginId"] is DBNull ? (int)0 : (int)returnData["userLoginId"];
                    obj.roleId = returnData["roleId"] is DBNull ? (int)0 : (int)returnData["roleId"];
                    obj.roleApprovalStatus = returnData["roleApprovalStatus"] is DBNull ? (string)string.Empty : (string)returnData["roleApprovalStatus"];
                    obj.roleName = returnData["roleName"] is DBNull ? (string)string.Empty : (string)returnData["roleName"];
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
