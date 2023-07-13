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
   public class clientAuditAssignmentDAL : SQLDataAccess
    {
        public int InsertClientAuditAssignment(clsClientAuditAssignment obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientApplicationAuditId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientApplicationAuditId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardProcessStageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardProcessStageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentSummary", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.assignmentSummary ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignById", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignByRoleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignByRoleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignProposedDateFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignProposedDateFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignProposedDateTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignProposedDateTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignToId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignToId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignToRoleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignToRoleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@acceptStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.acceptStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@acceptedDateFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.acceptedDateFrom?? DBNull.Value);
                AddParamToSQLCmd(comm, "@acceptedDateTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.acceptedDateTo?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentFinalDateFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignmentFinalDateFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentFinalDateTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignmentFinalDateTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignByInstruction", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.assignByInstruction ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignToReply", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.assignToReply ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentActualDateFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignmentActualDateFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentActualDateTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignmentActualDateTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientOfficeIdForVisit", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientOfficeIdForVisit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAuditAssignment", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAuditAssignment(clsClientAuditAssignment obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientApplicationAuditId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientApplicationAuditId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardProcessStageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardProcessStageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentSummary", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.assignmentSummary ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignById", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignByRoleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignByRoleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignProposedDateFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignProposedDateFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignProposedDateTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignProposedDateTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignToId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignToId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignToRoleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignToRoleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@acceptStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.acceptStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@acceptedDateFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.acceptedDateFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@acceptedDateTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.acceptedDateTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentFinalDateFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignmentFinalDateFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentFinalDateTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.assignmentFinalDateTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignByInstruction", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.assignByInstruction ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignToReply", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.assignToReply ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentActualDateFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignmentActualDateFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@assignmentActualDateTo", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.assignmentActualDateTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientOfficeIdForVisit", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientOfficeIdForVisit ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAuditAssignment", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAuditAssignment> SelectAllClientAuditAssignment(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAuditAssignment");

                List<clsClientAuditAssignment> activeList = new List<clsClientAuditAssignment>();
                TExecuteReaderCmd<clsClientAuditAssignment>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditAssignment>, ref activeList);
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
        public List<clsClientAuditAssignment> SelectClientAuditAssignmentById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAuditAssignmentById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAuditAssignment> activeList = new List<clsClientAuditAssignment>();
                TExecuteReaderCmd<clsClientAuditAssignment>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAuditAssignment>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAuditAssignment> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAuditAssignment obj = new clsClientAuditAssignment();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientApplicationAuditId = returnData["clientApplicationAuditId"] is DBNull ? (int)0 : (int)returnData["clientApplicationAuditId"];
                    obj.standardProcessStageId = returnData["standardProcessStageId"] is DBNull ? (int)0 : (int)returnData["standardProcessStageId"];
                    obj.assignmentSummary = returnData["assignmentSummary"] is DBNull ? (string) string.Empty : (string)returnData["assignmentSummary"];
                    obj.assignById = returnData["assignById"] is DBNull ? (int)0 : (int)returnData["assignById"];
                    obj.assignByRoleId = returnData["assignByRoleId"] is DBNull ? (int) 0 : (int)returnData["assignByRoleId"];
                    obj.assignProposedDateFrom = returnData["assignProposedDateFrom"] is DBNull ? (DateTime?)null : (DateTime)returnData["assignProposedDateFrom"];
                    obj.assignProposedDateTo = returnData["assignProposedDateTo"] is DBNull ? (DateTime?)null : (DateTime)returnData["assignProposedDateTo"];
                    obj.assignToId = returnData["assignToId"] is DBNull ? (int) 0 : (int)returnData["assignToId"];
                    obj.assignToRoleId = returnData["assignToRoleId"] is DBNull ? (int) 0 : (int)returnData["assignToRoleId"];
                    obj.acceptStatusId = returnData["acceptStatusId"] is DBNull ? (int) 0 : (int)returnData["acceptStatusId"];
                    obj.acceptedDateFrom = returnData["acceptedDateFrom"] is DBNull ? (DateTime?)null : (DateTime)returnData["acceptedDateFrom"];
                    obj.acceptedDateTo = returnData["acceptedDateTo"] is DBNull ? (DateTime?)null : (DateTime)returnData["acceptedDateTo"];
                    obj.assignmentFinalDateFrom = returnData["assignmentFinalDateFrom"] is DBNull ? (DateTime?)null : (DateTime)returnData["assignmentFinalDateFrom"];
                    obj.assignmentFinalDateTo = returnData["assignmentFinalDateTo"] is DBNull ? (DateTime?)null : (DateTime)returnData["assignmentFinalDateTo"];
                    obj.assignByInstruction = returnData["assignByInstruction"] is DBNull ? (string)string.Empty : (string)returnData["assignByInstruction"];
                    obj.assignToReply = returnData["assignToReply"] is DBNull ? (string)string.Empty : (string)returnData["assignToReply"];
                    obj.assignmentActualDateFrom = returnData["assignmentActualDateFrom"] is DBNull ? (DateTime?)null : (DateTime)returnData["assignmentActualDateFrom"];
                    obj.assignmentActualDateTo = returnData["assignmentActualDateTo"] is DBNull ? (DateTime?)null : (DateTime)returnData["assignmentActualDateTo"];
                    obj.clientAuditAssignmentStatusId = returnData["clientAuditAssignmentStatusId"] is DBNull ? (int)0: (int)returnData["clientAuditAssignmentStatusId"];
                    obj.clientOfficeIdForVisit = returnData["clientOfficeIdForVisit"] is DBNull ? (int)0: (int)returnData["clientOfficeIdForVisit"];
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
