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
   public class moduleDAL : SQLDataAccess
    {
        public int InsertModule(clsModule obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.moduleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isModule", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isModule ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSubModule", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSubModule ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForm", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isForm ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subForm", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subForm ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentModuleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentModuleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleUrl", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.moduleUrl ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modulePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.modulePath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertModule", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateModule(clsModule obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.moduleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isModule", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isModule ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSubModule", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSubModule ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForm", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isForm ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subForm", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.subForm ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentModuleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentModuleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@moduleUrl", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.moduleUrl ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modulePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.modulePath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateModule", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsModule> SelectAllModule(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllModule");

                List<clsModule> activeList = new List<clsModule>();
                TExecuteReaderCmd<clsModule>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsModule>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsModule>();
        }  
        public List<clsModule> SelectAllModuleForRights(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllModuleForRights");

                List<clsModule> activeList = new List<clsModule>();
                TExecuteReaderCmd<clsModule>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsModule>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsModule>();
        }
        public List<clsModule> SelectModuleById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectModuleById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsModule> activeList = new List<clsModule>();
                TExecuteReaderCmd<clsModule>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsModule>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsModule>();
        }
        public List<clsModule> SelectModuleByParentModuleId(int parentModuleId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectModuleByParentModuleId");
                comand.Parameters.AddWithValue("@parentModuleId", parentModuleId);
                List<clsModule> activeList = new List<clsModule>();
                TExecuteReaderCmd<clsModule>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsModule>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsModule>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsModule> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsModule obj = new clsModule();
                    if (ColumnExists(returnData, "id"))
                    {
                        obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    }
                    if (ColumnExists(returnData, "parentModuleId"))
                    {
                        obj.parentModuleId = returnData["parentModuleId"] is DBNull ? (int)0 : (int)returnData["parentModuleId"];
                    }
                    if (ColumnExists(returnData, "moduleName"))
                    {
                        obj.moduleName = returnData["moduleName"] is DBNull ? (string)string.Empty : (string)returnData["moduleName"];
                    }
                    if (ColumnExists(returnData, "moduleUrl"))
                    {
                        obj.moduleUrl = returnData["moduleUrl"] is DBNull ? (string)string.Empty : (string)returnData["moduleUrl"];
                    }
                    if (ColumnExists(returnData, "modulePath"))
                    {
                        obj.modulePath = returnData["modulePath"] is DBNull ? (string)string.Empty : (string)returnData["modulePath"];
                    }
                    if (ColumnExists(returnData, "subForm"))
                    {
                        obj.subForm = returnData["subForm"] is DBNull ? (string)string.Empty : (string)returnData["subForm"];
                    }
                    if (ColumnExists(returnData, "isModule"))
                    {
                        obj.isModule = returnData["isModule"] is DBNull ? (bool)true : (bool)returnData["isModule"];
                    }
                    if (ColumnExists(returnData, "isSubModule"))
                    {
                        obj.isSubModule = returnData["isSubModule"] is DBNull ? (bool)true : (bool)returnData["isSubModule"];
                    }
                    if (ColumnExists(returnData, "isForm"))
                    {
                        obj.isForm = returnData["isForm"] is DBNull ? (bool)true : (bool)returnData["isForm"];
                    }
                    if (ColumnExists(returnData, "isTab"))
                    {
                        obj.isTab = returnData["isTab"] is DBNull ? (bool)true : (bool)returnData["isTab"];
                    }
                    if (ColumnExists(returnData, "RightType"))
                    {
                        obj.RightType = returnData["RightType"] is DBNull ? (string) string.Empty : (string)returnData["RightType"];
                    }
                    if (ColumnExists(returnData, "active"))
                    {
                        obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    }
                    if (ColumnExists(returnData, "createdOn"))
                    {
                        obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime?)null : (DateTime)returnData["createdOn"];
                    }
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
