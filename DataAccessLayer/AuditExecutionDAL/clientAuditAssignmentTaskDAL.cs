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
   public class clientAuditAssignmentTaskDAL : SQLDataAccess
    {
        public int InsertClientAuditAssignmentTask(clsClientAuditAssignmentTask obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.taskDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskCategory", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskResponce", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskResponce ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskEvaluateBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskEvaluateBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskPerformance", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskPerformance ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskRemarks", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.taskRemarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskCompletion", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskCompletion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAuditAssignmentTask", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAuditAssignmentTask(clsClientAuditAssignmentTask obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.taskDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskCategory", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskResponce", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskResponce ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskEvaluateBy", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskEvaluateBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskPerformance", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskPerformance ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskRemarks", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.taskRemarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taskCompletion", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taskCompletion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAuditAssignmentTask", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAuditAssignmentTask> SelectAllClientAuditAssignmentTask(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAuditAssignmentTask");

                List<clsClientAuditAssignmentTask> activeList = new List<clsClientAuditAssignmentTask>();
                TExecuteReaderCmd<clsClientAuditAssignmentTask>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditAssignmentTask>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsClientAuditAssignmentTask> SelectClientAuditAssignmentTaskById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAuditAssignmentTaskById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAuditAssignmentTask> activeList = new List<clsClientAuditAssignmentTask>();
                TExecuteReaderCmd<clsClientAuditAssignmentTask>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditAssignmentTask>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAuditAssignmentTask> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAuditAssignmentTask obj = new clsClientAuditAssignmentTask();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAuditAssignmentId = returnData["clientAuditAssignmentId"] is DBNull ? (int)0 : (int)returnData["clientAuditAssignmentId"];
                    obj.taskDescription = returnData["taskDescription"] is DBNull ? (string)string.Empty: (string)returnData["taskDescription"];
                    obj.taskCategory = returnData["taskCategory"] is DBNull ? (string)string.Empty: (string)returnData["taskCategory"];
                    obj.taskResponce = returnData["taskResponce"] is DBNull ? (string)string.Empty: (string)returnData["taskResponce"];
                    obj.taskEvaluateBy = returnData["taskEvaluateBy"] is DBNull ? (string)string.Empty: (string)returnData["taskEvaluateBy"];
                    obj.taskPerformance = returnData["taskPerformance"] is DBNull ? (string)string.Empty: (string)returnData["taskPerformance"];
                    obj.taskRemarks = returnData["taskRemarks"] is DBNull ? (string)string.Empty: (string)returnData["taskRemarks"];
                    obj.taskCompletion = returnData["taskCompletion"] is DBNull ? (string)string.Empty: (string)returnData["taskCompletion"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
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
