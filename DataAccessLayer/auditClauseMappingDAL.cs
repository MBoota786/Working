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
  public class auditClauseMappingDAL : SQLDataAccess
    {
        public int InsertAuditClauseMapping(clsAuditClauseMapping ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauseId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditClauseId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertAuditClauseMapping");
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
        public bool UpdateAuditClauseMapping(clsAuditClauseMapping ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditClauseId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.auditClauseId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateAuditClauseMapping");
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
        public List<clsAuditClauseMapping> SelectAllAuditClauseMapping()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditClauseMapping");

                List<clsAuditClauseMapping> activeList = new List<clsAuditClauseMapping>();
                TExecuteReaderCmd<clsAuditClauseMapping>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditClauseMapping>, ref activeList);
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
        public List<clsAuditClauseMapping> SelectAuditClauseMappingById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditClauseMappingById");
                comand.Parameters.AddWithValue("@id", id);

                List<clsAuditClauseMapping> activeList = new List<clsAuditClauseMapping>();
                TExecuteReaderCmd<clsAuditClauseMapping>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditClauseMapping>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditClauseMapping> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditClauseMapping obj = new clsAuditClauseMapping();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.auditClauseId = returnData["auditClauseId"] is DBNull ? (int)0 : (int)returnData["auditClauseId"];
                    obj.standardSetupId = returnData["standardSetupId"] is DBNull ? (int)0 : (int)returnData["standardSetupId"];
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
