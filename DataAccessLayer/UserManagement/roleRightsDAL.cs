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
   public class roleRightsDAL : SQLDataAccess
    {
        public int InsertRoleRights(clsRoleRights obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.moduleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEnter", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permEnter ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permVerify", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permVerify ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permCheck", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permCheck ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permApprove", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permApprove ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permPrint", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permPrint ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permDelete", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permDelete ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEdit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permEdit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permExtend", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permExtend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertRoleRights", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateRoleRights(clsRoleRights obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@roleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.roleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.moduleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEnter", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permEnter ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permVerify", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permVerify ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permCheck", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permCheck ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permApprove", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permApprove ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permPrint", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permPrint ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permDelete", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permDelete ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permEdit", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permEdit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@permExtend", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.permExtend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateRoleRights", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsRoleRights> SelectAllRoleRights(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllRoleRights");

                List<clsRoleRights> activeList = new List<clsRoleRights>();
                TExecuteReaderCmd<clsRoleRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRights>();
        }
        public List<clsRoleRights> SelectAllModuleForRoleRights(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllModuleForRoleRights");

                List<clsRoleRights> activeList = new List<clsRoleRights>();
                TExecuteReaderCmd<clsRoleRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRights>();
        }
        public List<clsRoleRights> SelectRoleRightsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectRoleRightsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsRoleRights> activeList = new List<clsRoleRights>();
                TExecuteReaderCmd<clsRoleRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRights>();
        } 
        public List<clsRoleRights> SelectRoleRightsByRoleId(int roleId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectRoleRightsByRoleId");
                comand.Parameters.AddWithValue("@roleId", roleId);
                List<clsRoleRights> activeList = new List<clsRoleRights>();
                TExecuteReaderCmd<clsRoleRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRights>();
        }     
        public List<clsRoleRights> SelectAllModuleForRoleRightsByRoleId(int roleId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllModuleForRoleRightsByRoleId");
                comand.Parameters.AddWithValue("@roleId", roleId);
                List<clsRoleRights> activeList = new List<clsRoleRights>();
                TExecuteReaderCmd<clsRoleRights>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRoleRights>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRoleRights>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsRoleRights> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsRoleRights obj = new clsRoleRights();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.roleId = returnData["roleId"] is DBNull ? (int)0 : (int)returnData["roleId"];
                    obj.moduleId = returnData["moduleId"] is DBNull ? (int)0 : (int)returnData["moduleId"];
                    obj.permEnter = returnData["permEnter"] is DBNull ? (bool)false : (bool)returnData["permEnter"];
                    obj.permVerify = returnData["permVerify"] is DBNull ? (bool)false : (bool)returnData["permVerify"];
                    obj.permCheck = returnData["permCheck"] is DBNull ? (bool)false : (bool)returnData["permCheck"];
                    obj.permApprove = returnData["permApprove"] is DBNull ? (bool)false : (bool)returnData["permApprove"];
                    obj.permPrint = returnData["permPrint"] is DBNull ? (bool)false : (bool)returnData["permPrint"];
                    obj.permDelete = returnData["permDelete"] is DBNull ? (bool)false : (bool)returnData["permDelete"];
                    obj.permEdit = returnData["permEdit"] is DBNull ? (bool)false : (bool)returnData["permEdit"];
                    obj.permExtend = returnData["permExtend"] is DBNull ? (bool)false : (bool)returnData["permExtend"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    if (ColumnExists(returnData, "createdOn"))
                    {
                        obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    }
                    if (ColumnExists(returnData, "moduleName"))
                    {
                        obj.moduleName = returnData["moduleName"] is DBNull ? (string) string.Empty : (string)returnData["moduleName"];
                    }  
                    if (ColumnExists(returnData, "RightType"))
                    {
                        obj.RightType = returnData["RightType"] is DBNull ? (string) string.Empty : (string)returnData["RightType"];
                    }
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
