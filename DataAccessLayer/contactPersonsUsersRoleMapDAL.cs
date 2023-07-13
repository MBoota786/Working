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
   public class contactPersonsUsersRoleMapDAL : SQLDataAccess
    {
        public int InsertContactPersonsUsersRoleMap(clsContactPersonsUsersRoleMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonsUsersId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contactPersonsUsersId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertContactPersonsUsersRoleMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateContactPersonsUsersRoleMap(clsContactPersonsUsersRoleMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonsUsersId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contactPersonsUsersId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateContactPersonsUsersRoleMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsContactPersonsUsersRoleMap> SelectAllContactPersonsUsersRoleMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllContactPersonsUsersRoleMap");

                List<clsContactPersonsUsersRoleMap> activeList = new List<clsContactPersonsUsersRoleMap>();
                TExecuteReaderCmd<clsContactPersonsUsersRoleMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsContactPersonsUsersRoleMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsContactPersonsUsersRoleMap>();
        }
        public List<clsContactPersonsUsersRoleMap> SelectContactPersonsUsersRoleMapByContactPersonsUsersId(int contactPersonsUsersId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectContactPersonsUsersRoleMapByContactPersonsUsersId");
                comand.Parameters.AddWithValue("@contactPersonsUsersId", contactPersonsUsersId);
                List<clsContactPersonsUsersRoleMap> activeList = new List<clsContactPersonsUsersRoleMap>();
                TExecuteReaderCmd<clsContactPersonsUsersRoleMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsContactPersonsUsersRoleMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsContactPersonsUsersRoleMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsContactPersonsUsersRoleMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsContactPersonsUsersRoleMap obj = new clsContactPersonsUsersRoleMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.contactPersonsUsersId = returnData["contactPersonsUsersId"] is DBNull ? (int)0 : (int)returnData["contactPersonsUsersId"];
                    obj.roleId = returnData["roleId"] is DBNull ? (int)0 : (int)returnData["roleId"];
                    obj.roleName = returnData["roleName"] is DBNull ? (string) string.Empty : (string)returnData["roleName"];
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
        public bool DeleteContactPersonsUsersRoleMapByContactPersonsUsersId(int contactPersonsUsersId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@contactPersonsUsersId", SqlDbType.Int, 4, ParameterDirection.Input, (object)contactPersonsUsersId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteContactPersonsUsersRoleMapByContactPersonsUsersId", dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
    }
}
