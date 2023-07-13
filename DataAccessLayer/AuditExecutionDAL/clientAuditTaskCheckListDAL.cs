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
   public class clientAuditTaskCheckListDAL : SQLDataAccess
    {
        public int InsertClientAuditCheckList(clsClientAuditTaskCheckList obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditCheckListCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.clientAuditCheckListCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentTaskId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentTaskId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardReqCheckListId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardReqCheckListId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@downloadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.downloadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.uploadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDownloaded", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDownloaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isUploaded", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isUploaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAuditCheckList", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAuditCheckList(clsClientAuditTaskCheckList obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditCheckListCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.clientAuditCheckListCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentTaskId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentTaskId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardReqCheckListId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardReqCheckListId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@downloadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.downloadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.uploadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDownloaded", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDownloaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isUploaded", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isUploaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAuditCheckList", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAuditTaskCheckList> SelectAllClientAuditTaskCheckList(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAuditTaskCheckList");

                List<clsClientAuditTaskCheckList> activeList = new List<clsClientAuditTaskCheckList>();
                TExecuteReaderCmd<clsClientAuditTaskCheckList>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditTaskCheckList>, ref activeList);
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
        public List<clsClientAuditTaskCheckList> SelectClientAuditTaskCheckListById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAuditTaskCheckListById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAuditTaskCheckList> activeList = new List<clsClientAuditTaskCheckList>();
                TExecuteReaderCmd<clsClientAuditTaskCheckList>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditTaskCheckList>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAuditTaskCheckList> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAuditTaskCheckList obj = new clsClientAuditTaskCheckList();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAuditCheckListCode = returnData["clientAuditCheckListCode"] is DBNull ? (string) string.Empty : (string)returnData["clientAuditCheckListCode"];
                    obj.clientAuditAssignmentTaskId = returnData["clientAuditAssignmentTaskId"] is DBNull ? (int)0 : (int)returnData["clientAuditAssignmentTaskId"];
                    obj.standardReqCheckListId = returnData["standardReqCheckListId"] is DBNull ? (int)0 : (int)returnData["standardReqCheckListId"];
                    obj.downloadPath = returnData["downloadPath"] is DBNull ? (string)string.Empty : (string)returnData["downloadPath"];
                    obj.uploadPath = returnData["uploadPath"] is DBNull ? (string)string.Empty : (string)returnData["uploadPath"];
                    obj.isDownloaded = returnData["isDownloaded"] is DBNull ? (bool)false: (bool)returnData["isDownloaded"];
                    obj.isUploaded = returnData["isUploaded"] is DBNull ? (bool)false: (bool)returnData["isUploaded"];
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
