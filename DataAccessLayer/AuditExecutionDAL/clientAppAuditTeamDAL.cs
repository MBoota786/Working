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
   public class clientAppAuditTeamDAL : SQLDataAccess
    {
        public int InsertClientAppAuditTeam(clsClientAppAuditTeam obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientApplicationAuditId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientApplicationAuditId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@teamMemberId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.teamMemberId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@teamMemberRoleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.teamMemberRoleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditWindowStart", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.auditWindowStart ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditWindowEnd", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.auditWindowEnd ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@riskDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.windowStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAppAuditTeam", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAppAuditTeam(clsClientAppAuditTeam obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientApplicationAuditId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientApplicationAuditId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@teamMemberId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.teamMemberId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@teamMemberRoleId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.teamMemberRoleId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditWindowStart", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.auditWindowStart ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditWindowEnd", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.auditWindowEnd ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@riskDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.windowStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAppAuditTeam", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAppAuditTeam> SelectAllClientAppAuditTeam(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAppAuditTeam");

                List<clsClientAppAuditTeam> activeList = new List<clsClientAppAuditTeam>();
                TExecuteReaderCmd<clsClientAppAuditTeam>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditTeam>, ref activeList);
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
        public List<clsClientAppAuditTeam> SelectClientAppAuditTeamById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAppAuditTeamById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAppAuditTeam> activeList = new List<clsClientAppAuditTeam>();
                TExecuteReaderCmd<clsClientAppAuditTeam>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditTeam>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAppAuditTeam> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAppAuditTeam obj = new clsClientAppAuditTeam();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientApplicationAuditId = returnData["clientApplicationAuditId"] is DBNull ? (int)0 : (int)returnData["clientApplicationAuditId"];
                    obj.teamMemberId = returnData["teamMemberId"] is DBNull ? (int)0 : (int)returnData["teamMemberId"];
                    obj.teamMemberRoleId = returnData["teamMemberRoleId"] is DBNull ? (int)0 : (int)returnData["teamMemberRoleId"];
                    obj.auditWindowStart = returnData["auditWindowStart"] is DBNull ? (bool) false : (bool)returnData["auditWindowStart"];
                    obj.auditWindowEnd = returnData["auditWindowEnd"] is DBNull ? (bool) false : (bool)returnData["auditWindowEnd"];
                    obj.windowStatus = returnData["windowStatus"] is DBNull ? (string)string.Empty : (string)returnData["windowStatus"];
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
