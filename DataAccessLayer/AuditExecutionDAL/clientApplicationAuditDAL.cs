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
   public class clientApplicationAuditDAL : SQLDataAccess
    {
        public int InsertClientApplicationAudit(clsClientApplicationAudit obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadAuditor", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.leadAuditor ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@startDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.startDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@endDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.endDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentFolder", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignmentFolder ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isActive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isActive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isPasaSend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDocSend", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDocSend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAuditAccepted", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAuditAccepted ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAppTimeLine", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientAppTimeLine ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditStageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditStageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientApplicationAudit", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientApplicationAudit(clsClientApplicationAudit obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadAuditor", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.leadAuditor ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@startDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.startDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@endDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.endDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentFolder", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignmentFolder ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isActive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isActive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isPasaSend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDocSend", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDocSend ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAuditAccepted", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAuditAccepted ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAppTimeLine", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientAppTimeLine ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditStageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditStageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientApplicationAudit", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientApplicationAudit> SelectAllClientApplicationAudit(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientApplicationAudit");

                List<clsClientApplicationAudit> activeList = new List<clsClientApplicationAudit>();
                TExecuteReaderCmd<clsClientApplicationAudit>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientApplicationAudit>, ref activeList);
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
        public List<clsClientApplicationAudit> SelectClientApplicationAuditById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientApplicationAuditById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientApplicationAudit> activeList = new List<clsClientApplicationAudit>();
                TExecuteReaderCmd<clsClientApplicationAudit>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientApplicationAudit>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientApplicationAudit> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientApplicationAudit obj = new clsClientApplicationAudit();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.leadAuditor = returnData["leadAuditor"] is DBNull ? (string)string.Empty : (string)returnData["leadAuditor"];
                    obj.reviewBy = returnData["reviewBy"] is DBNull ? (int)0 : (int)returnData["reviewBy"];
                    obj.startDate = returnData["startDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["startDate"];
                    obj.endDate = returnData["endDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["endDate"];
                    obj.assignmentFolder = returnData["assignmentFolder"] is DBNull ? (string)string.Empty : (string)returnData["assignmentFolder"];
                    obj.isActive = returnData["isActive"] is DBNull ? (bool)false: (bool)returnData["isActive"];
                    obj.isPasaSend = returnData["isPasaSend"] is DBNull ? (bool)false: (bool)returnData["isPasaSend"];
                    obj.isDocSend = returnData["isDocSend"] is DBNull ? (bool)false: (bool)returnData["isDocSend"];
                    obj.isAuditAccepted = returnData["isAuditAccepted"] is DBNull ? (bool)false: (bool)returnData["isAuditAccepted"];
                    obj.clientAppTimeLine = returnData["clientAppTimeLine"] is DBNull ? (string)string.Empty: (string)returnData["clientAppTimeLine"];
                    obj.auditStageId = returnData["auditStageId"] is DBNull ? (int) 0: (int)returnData["auditStageId"];
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
