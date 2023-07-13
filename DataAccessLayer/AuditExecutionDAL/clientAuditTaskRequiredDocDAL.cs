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
   public class clientAuditTaskRequiredDocDAL : SQLDataAccess
    {
        public int InsertClientAuditTaskRequiredDoc(clsClientAuditTaskRequiredDoc obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditTaskRequiredDocCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.clientAuditTaskRequiredDocCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentTaskId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentTaskId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.requiredDocId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@downloadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.downloadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.uploadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDownload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDownloaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isUpload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isUploaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAuditTaskRequiredDoc", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAuditTaskRequiredDoc(clsClientAuditTaskRequiredDoc obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditTaskRequiredDocCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.clientAuditTaskRequiredDocCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentTaskId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentTaskId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.requiredDocId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@downloadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.downloadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.uploadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDownload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDownloaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isUpload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isUploaded ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAuditTaskRequiredDoc", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAuditTaskRequiredDoc> SelectAllClientAuditTaskRequiredDoc(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAuditTaskRequiredDoc");

                List<clsClientAuditTaskRequiredDoc> activeList = new List<clsClientAuditTaskRequiredDoc>();
                TExecuteReaderCmd<clsClientAuditTaskRequiredDoc>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditTaskRequiredDoc>, ref activeList);
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
        public List<clsClientAuditTaskRequiredDoc> SelectClientAuditTaskRequiredDocById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAuditTaskRequiredDocById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAuditTaskRequiredDoc> activeList = new List<clsClientAuditTaskRequiredDoc>();
                TExecuteReaderCmd<clsClientAuditTaskRequiredDoc>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditTaskRequiredDoc>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAuditTaskRequiredDoc> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAuditTaskRequiredDoc obj = new clsClientAuditTaskRequiredDoc();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAuditTaskRequiredDocCode = returnData["clientAuditTaskRequiredDocCode"] is DBNull ? (string) string.Empty : (string)returnData["clientAuditTaskRequiredDocCode"];
                    obj.clientAuditAssignmentTaskId = returnData["clientAuditAssignmentTaskId"] is DBNull ? (int)0 : (int)returnData["clientAuditAssignmentTaskId"];
                    obj.requiredDocId = returnData["requiredDocId"] is DBNull ? (int)0 : (int)returnData["requiredDocId"];
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
