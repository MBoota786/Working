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
   public class auditExecutionProcessStepDAL : SQLDataAccess
    {
        public int InsertAuditExecutionProcessStep(clsAuditExecutionProcessStep obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@processSetup", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.processSetup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditExecutionProcessStepDuration", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.auditExecutionProcessStepDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertAuditExecutionProcessStep");
                if (ConnectionString == string.Empty)
                {
                    throw (new ArgumentOutOfRangeException("ConnectionString"));
                }
                if (comm == null)
                {
                    throw (new ArgumentNullException("SqlCmd"));
                }
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comm.Connection = con;
                    con.Open();
                    comm.ExecuteNonQuery();
                    Id = (int)comm.Parameters["@id"].Value;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditExecutionProcessStep(clsAuditExecutionProcessStep obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@processSetup", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.processSetup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditExecutionProcessStepDuration", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.auditExecutionProcessStepDuration ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateAuditExecutionProcessStep");
                if (ConnectionString == string.Empty)
                {
                    throw (new ArgumentOutOfRangeException("ConnectionString"));

                }
                if (comm == null)
                {
                    throw (new ArgumentNullException("SqlCmd"));
                }
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comm.Connection = con;
                    con.Open();
                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAuditExecutionProcessStep> SelectAllAuditExecutionProcessStep()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditExecutionProcessStep");

                List<clsAuditExecutionProcessStep> activeList = new List<clsAuditExecutionProcessStep>();
                TExecuteReaderCmd<clsAuditExecutionProcessStep>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditExecutionProcessStep>, ref activeList);
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
        public List<clsAuditExecutionProcessStep> SelectAuditExecutionProcessStepById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditExecutionProcessStepById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditExecutionProcessStep> activeList = new List<clsAuditExecutionProcessStep>();
                TExecuteReaderCmd<clsAuditExecutionProcessStep>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditExecutionProcessStep>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditExecutionProcessStep> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditExecutionProcessStep obj = new clsAuditExecutionProcessStep();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardSetupId = returnData["standardSetupId"] is DBNull ? (int)0 : (int)returnData["standardSetupId"];
                    obj.processSetup = returnData["processSetup"] is DBNull ? (string)string.Empty : (string)returnData["processSetup"];
                    obj.auditExecutionProcessStepDuration = returnData["auditExecutionProcessStepDuration"] is DBNull ? (string)string.Empty : (string)returnData["auditExecutionProcessStepDuration"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
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
