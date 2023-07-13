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
   public class assignmentAssociatedRiskDAL : SQLDataAccess
    {
        public int InsertAssignmentAssociatedRisk(clsAssignmentAssociatedRisk obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@riskDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.riskDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@instructionForAuditorId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.instructionForAuditorId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAssignmentAssociatedRisk", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAssignmentAssociatedRisk(clsAssignmentAssociatedRisk obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@riskDetail", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.riskDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@instructionForAuditorId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.instructionForAuditorId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAssignmentAssociatedRisk", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAssignmentAssociatedRisk> SelectAllAssignmentAssociatedRisk(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAssignmentAssociatedRisk");

                List<clsAssignmentAssociatedRisk> activeList = new List<clsAssignmentAssociatedRisk>();
                TExecuteReaderCmd<clsAssignmentAssociatedRisk>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAssignmentAssociatedRisk>, ref activeList);
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
        public List<clsAssignmentAssociatedRisk> SelectAssignmentAssociatedRiskById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAssignmentAssociatedRiskById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAssignmentAssociatedRisk> activeList = new List<clsAssignmentAssociatedRisk>();
                TExecuteReaderCmd<clsAssignmentAssociatedRisk>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAssignmentAssociatedRisk>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAssignmentAssociatedRisk> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAssignmentAssociatedRisk obj = new clsAssignmentAssociatedRisk();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAuditAssignmentId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.riskDetail = returnData["riskDetail"] is DBNull ? (string)string.Empty : (string)returnData["riskDetail"];
                    obj.instructionForAuditorId = returnData["instructionForAuditorId"] is DBNull ? (int)0 : (int)returnData["instructionForAuditorId"];
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
