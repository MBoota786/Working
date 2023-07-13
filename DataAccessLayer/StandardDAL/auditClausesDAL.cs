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
  public class auditClausesDAL : SQLDataAccess
    {
        public int InsertAuditClauses(clsAuditClauses ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauseSerialNumber", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.auditClauseSerialNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauses", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.auditClauses ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauseParentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditClauseParentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clauseTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseStatement", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.clauseStatement ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.clauseDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditClauses", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditClauses(clsAuditClauses ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauseSerialNumber", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.auditClauseSerialNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauses", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.auditClauses ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauseParentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditClauseParentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clauseTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseStatement", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.clauseStatement ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clauseDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.clauseDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditClauses", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditClauses> SelectAllAuditClause(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditClause");

                List<clsAuditClauses> activeList = new List<clsAuditClauses>();
                TExecuteReaderCmd<clsAuditClauses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditClauses>, ref activeList);
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
        public List<clsAuditClauses> SelectAuditClauseById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditClauseById");
                comand.Parameters.AddWithValue("@id", id);

                List<clsAuditClauses> activeList = new List<clsAuditClauses>();
                TExecuteReaderCmd<clsAuditClauses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditClauses>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditClauses> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditClauses obj = new clsAuditClauses();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.auditClauses = returnData["auditClauses"] is DBNull ? (string)string.Empty : (string)returnData["auditClauses"];
                    obj.auditClauseSerialNumber = returnData["auditClauseSerialNumber"] is DBNull ? (string)string.Empty : (string)returnData["auditClauseSerialNumber"];
                    obj.auditClauseParentId = returnData["auditClauseParentId"] is DBNull ? (int)0 : (int)returnData["auditClauseParentId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.clauseTypeId = returnData["clauseTypeId"] is DBNull ? (int)0 : (int)returnData["clauseTypeId"];
                    obj.clauseStatement = returnData["clauseStatement"] is DBNull ? (string)string.Empty : (string)returnData["clauseStatement"];
                    obj.clauseDescription = returnData["clauseDescription"] is DBNull ? (string)string.Empty : (string)returnData["clauseDescription"];
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
