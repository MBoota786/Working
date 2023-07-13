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
   public class clientAuditTaskPreRequisitsDAL : SQLDataAccess
    {
        public int InsertClientAuditTaskPreRequisits(clsClientAuditTaskPreRequisits obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditTaskPreRequisitsCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.clientAuditTaskPreRequisitsCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentTaskId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentTaskId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditPreRequisitesMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@downloadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.downloadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.uploadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDownload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDownload ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isUpload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isUpload ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAuditTaskPreRequisits", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAuditTaskPreRequisits(clsClientAuditTaskPreRequisits obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditTaskPreRequisitsCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.clientAuditTaskPreRequisitsCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentTaskId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentTaskId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditPreRequisitesMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@downloadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.downloadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.uploadPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDownload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDownload ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isUpload", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isUpload ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAuditTaskPreRequisits", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAuditTaskPreRequisits> SelectAllClientAuditTaskPreRequisits(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAuditTaskPreRequisits");

                List<clsClientAuditTaskPreRequisits> activeList = new List<clsClientAuditTaskPreRequisits>();
                TExecuteReaderCmd<clsClientAuditTaskPreRequisits>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditTaskPreRequisits>, ref activeList);
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
        public List<clsClientAuditTaskPreRequisits> SelectClientAuditTaskPreRequisitsById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAuditTaskPreRequisitsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAuditTaskPreRequisits> activeList = new List<clsClientAuditTaskPreRequisits>();
                TExecuteReaderCmd<clsClientAuditTaskPreRequisits>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditTaskPreRequisits>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAuditTaskPreRequisits> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAuditTaskPreRequisits obj = new clsClientAuditTaskPreRequisits();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAuditTaskPreRequisitsCode = returnData["clientAuditTaskPreRequisitsCode"] is DBNull ? (string) string.Empty : (string)returnData["clientAuditTaskPreRequisitsCode"];
                    obj.clientAuditAssignmentTaskId = returnData["clientAuditAssignmentTaskId"] is DBNull ? (int)0 : (int)returnData["clientAuditAssignmentTaskId"];
                    obj.auditPreRequisitesMasterId = returnData["auditPreRequisitesMasterId"] is DBNull ? (int)0 : (int)returnData["auditPreRequisitesMasterId"];
                    obj.downloadPath = returnData["downloadPath"] is DBNull ? (string)string.Empty : (string)returnData["downloadPath"];
                    obj.uploadPath = returnData["uploadPath"] is DBNull ? (string)string.Empty : (string)returnData["uploadPath"];
                    obj.isDownload = returnData["isDownload"] is DBNull ? (bool)false: (bool)returnData["isDownload"];
                    obj.isUpload = returnData["isUpload"] is DBNull ? (bool)false: (bool)returnData["isUpload"];
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
