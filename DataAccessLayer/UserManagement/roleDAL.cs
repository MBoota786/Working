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
   public class roleDAL : SQLDataAccess
    {
        public int InsertRole(clsRole obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.roleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleDescription ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.roleDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertRole", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateRole(clsRole obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.roleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleDescription ", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.roleDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateRole", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsRole> SelectAllRole(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllRole");

                List<clsRole> activeList = new List<clsRole>();
                TExecuteReaderCmd<clsRole>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRole>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRole>();
        } 
        public List<clsRole> SelectAllRoleForList(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllRoleForList");

                List<clsRole> activeList = new List<clsRole>();
                TExecuteReaderCmd<clsRole>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRole>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRole>();
        }
        public List<clsRole> SelectRoleById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectRoleById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsRole> activeList = new List<clsRole>();
                TExecuteReaderCmd<clsRole>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRole>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRole>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsRole> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsRole obj = new clsRole();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.roleName = returnData["roleName"] is DBNull ? (string)string.Empty : (string)returnData["roleName"];
                    obj.roleDescription = returnData["roleDescription"] is DBNull ? (string)string.Empty : (string)returnData["roleDescription"];
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
