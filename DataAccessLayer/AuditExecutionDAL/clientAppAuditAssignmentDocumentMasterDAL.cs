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
   public class clientAppAuditAssignmentDocumentMasterDAL : SQLDataAccess
    {
        public int InsertClientAppAuditAssignmentDocumentMaster(clsClientAppAuditAssignmentDocumentMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.documentTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.documentTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAppAuditAssignmentDocumentMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAppAuditAssignmentDocumentMaster(clsClientAppAuditAssignmentDocumentMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.documentTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.documentTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAppAuditAssignmentDocumentMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAppAuditAssignmentDocumentMaster> SelectAllClientAppAuditAssignmentDocumentMaster(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAppAuditAssignmentDocumentMaster");

                List<clsClientAppAuditAssignmentDocumentMaster> activeList = new List<clsClientAppAuditAssignmentDocumentMaster>();
                TExecuteReaderCmd<clsClientAppAuditAssignmentDocumentMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditAssignmentDocumentMaster>, ref activeList);
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
        public List<clsClientAppAuditAssignmentDocumentMaster> SelectClientAppAuditAssignmentDocumentMasterById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAppAuditAssignmentDocumentMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAppAuditAssignmentDocumentMaster> activeList = new List<clsClientAppAuditAssignmentDocumentMaster>();
                TExecuteReaderCmd<clsClientAppAuditAssignmentDocumentMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditAssignmentDocumentMaster>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAppAuditAssignmentDocumentMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAppAuditAssignmentDocumentMaster obj = new clsClientAppAuditAssignmentDocumentMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientAuditAssignmentId = returnData["clientAuditAssignmentId"] is DBNull ? (int)0 : (int)returnData["clientAuditAssignmentId"];
                    obj.documentTypeId = returnData["documentTypeId"] is DBNull ? (int) 0 : (int)returnData["documentTypeId"];
                    obj.documentTitle = returnData["documentTitle"] is DBNull ? (string)string.Empty : (string)returnData["documentTitle"];
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
