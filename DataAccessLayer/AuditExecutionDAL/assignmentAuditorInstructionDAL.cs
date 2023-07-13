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
   public class assignmentAuditorInstructionDAL : SQLDataAccess
    {
        public int InsertAssignmentAuditorInstruction(clsAssignmentAuditorInstruction obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@instructionDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.instructionDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@instructionForAuditorId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.instructionForAuditorId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAssignmentAuditorInstruction", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAssignmentAuditorInstruction(clsAssignmentAuditorInstruction obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAuditAssignmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientAuditAssignmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@instructionDetail", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.instructionDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@instructionForAuditorId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.instructionForAuditorId ?? DBNull.Value); AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAssignmentAuditorInstruction", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAssignmentAuditorInstruction> SelectAllAssignmentAuditorInstruction(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAssignmentAuditorInstruction");

                List<clsAssignmentAuditorInstruction> activeList = new List<clsAssignmentAuditorInstruction>();
                TExecuteReaderCmd<clsAssignmentAuditorInstruction>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAssignmentAuditorInstruction>, ref activeList);
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
        public List<clsAssignmentAuditorInstruction> SelectAssignmentAuditorInstructionById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAssignmentAuditorInstructionById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAssignmentAuditorInstruction> activeList = new List<clsAssignmentAuditorInstruction>();
                TExecuteReaderCmd<clsAssignmentAuditorInstruction>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAssignmentAuditorInstruction>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAssignmentAuditorInstruction> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAssignmentAuditorInstruction obj = new clsAssignmentAuditorInstruction();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAuditAssignmentId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.instructionDetail = returnData["instructionDetail"] is DBNull ? (string)string.Empty : (string)returnData["instructionDetail"];
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
