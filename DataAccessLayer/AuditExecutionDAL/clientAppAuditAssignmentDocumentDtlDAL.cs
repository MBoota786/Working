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
   public class clientAppAuditAssignmentDocumentDtlDAL : SQLDataAccess
    {
        public int InsertClientAppAuditAssignmentDocumentDtl(clsClientAppAuditAssignmentDocumentDtl obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAppAuditAssignmentDocumentMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAppAuditAssignmentDocumentMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExpiry", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isExpiry ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@expiryDate", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.expiryDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.documentSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.documentPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentDate", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.documentDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAppAuditAssignmentDocumentDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAppAuditAssignmentDocumentDtl(clsClientAppAuditAssignmentDocumentDtl obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAppAuditAssignmentDocumentMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAppAuditAssignmentDocumentMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExpiry", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isExpiry ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@expiryDate", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.expiryDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.documentSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.documentPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentDate", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.documentDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAppAuditAssignmentDocumentDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAppAuditAssignmentDocumentDtl> SelectAllClientAppAuditAssignmentDocumentDtl(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAppAuditAssignmentDocumentDtl");

                List<clsClientAppAuditAssignmentDocumentDtl> activeList = new List<clsClientAppAuditAssignmentDocumentDtl>();
                TExecuteReaderCmd<clsClientAppAuditAssignmentDocumentDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditAssignmentDocumentDtl>, ref activeList);
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
        public List<clsClientAppAuditAssignmentDocumentDtl> SelectClientAppAuditAssignmentDocumentDtlById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAppAuditAssignmentDocumentDtlById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAppAuditAssignmentDocumentDtl> activeList = new List<clsClientAppAuditAssignmentDocumentDtl>();
                TExecuteReaderCmd<clsClientAppAuditAssignmentDocumentDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditAssignmentDocumentDtl>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAppAuditAssignmentDocumentDtl> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAppAuditAssignmentDocumentDtl obj = new clsClientAppAuditAssignmentDocumentDtl();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAppAuditAssignmentDocumentMasterId = returnData["clientAppAuditAssignmentDocumentMasterId"] is DBNull ? (int)0 : (int)returnData["clientAppAuditAssignmentDocumentMasterId"];
                    obj.isExpiry = returnData["isExpiry"] is DBNull ? (bool)false : (bool)returnData["isExpiry"];
                    obj.expiryDate = returnData["expiryDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["expiryDate"];
                    obj.documentSrNo = returnData["documentSrNo"] is DBNull ? (string)string.Empty : (string)returnData["documentSrNo"];
                    obj.documentPath = returnData["documentPath"] is DBNull ? (string)string.Empty: (string)returnData["documentPath"];
                    obj.documentDate = returnData["documentDate"] is DBNull ? (DateTime?) null : (DateTime)returnData["documentDate"];
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
