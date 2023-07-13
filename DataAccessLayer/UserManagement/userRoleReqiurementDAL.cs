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
   public class userRoleReqiurementDAL : SQLDataAccess
    {
        public int InsertUserRoleRequirement(clsUserRoleRequirement obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userLoginId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.userLoginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleRequirementId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleRequirementId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleRequirementText ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.roleRequirementText ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleRequirementDocPath ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.roleRequirementDocPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userRequirementStatus ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.userRequirementStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertUserRoleRequirement", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateUserRoleRequirement(clsUserRoleRequirement obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userLoginId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.userLoginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleRequirementId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleRequirementId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleRequirementText ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.roleRequirementText ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleRequirementDocPath ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.roleRequirementDocPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userRequirementStatus ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.userRequirementStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateUserRoleRequirement", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsUserRoleRequirement> SelectAllUserRoleRequirement(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllUserRoleRequirement");

                List<clsUserRoleRequirement> activeList = new List<clsUserRoleRequirement>();
                TExecuteReaderCmd<clsUserRoleRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRoleRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRoleRequirement>();
        }
        public List<clsUserRoleRequirement> SelectUserRoleRequirementById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserRoleRequirementById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsUserRoleRequirement> activeList = new List<clsUserRoleRequirement>();
                TExecuteReaderCmd<clsUserRoleRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRoleRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRoleRequirement>();
        }  
        public List<clsUserRoleRequirement> SelectUserRoleRequirementByUserLoginId(int userLoginId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserRoleRequirementByUserLoginId");
                comand.Parameters.AddWithValue("@userLoginId", userLoginId);
                List<clsUserRoleRequirement> activeList = new List<clsUserRoleRequirement>();
                TExecuteReaderCmd<clsUserRoleRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsUserRoleRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsUserRoleRequirement>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsUserRoleRequirement> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsUserRoleRequirement obj = new clsUserRoleRequirement();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.userLoginId = returnData["userLoginId"] is DBNull ? (int)0 : (int)returnData["userLoginId"];
                    obj.roleId = returnData["roleId"] is DBNull ? (int)0 : (int)returnData["roleId"];
                    obj.roleRequirementId = returnData["roleRequirementId"] is DBNull ? (int)0 : (int)returnData["roleRequirementId"];
                    obj.roleRequirementText = returnData["roleRequirementText"] is DBNull ? (string)string.Empty : (string)returnData["roleRequirementText"];
                    obj.roleRequirementDocPath = returnData["roleRequirementDocPath"] is DBNull ? (string)string.Empty : (string)returnData["roleRequirementDocPath"];
                    obj.userRequirementStatus = returnData["userRequirementStatus"] is DBNull ? (string)string.Empty : (string)returnData["userRequirementStatus"];
                    obj.roleName = returnData["roleName"] is DBNull ? (string)string.Empty : (string)returnData["roleName"];
                    obj.userName = returnData["userName"] is DBNull ? (string)string.Empty : (string)returnData["userName"];
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
