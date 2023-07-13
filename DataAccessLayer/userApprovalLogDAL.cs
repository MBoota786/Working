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
   public class userApprovalLogDAL : SQLDataAccess
    {
        public int InsertUserApprovalLog(clsUserApprovalLog ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userId", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ls.userId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reqApprovalSts", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.reqApprovalSts ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.approvalById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@remarks", SqlDbType.VarChar, 500, ParameterDirection.Input, (object)ls.remarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.requestById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestTime", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestTime ?? DBNull.Value);
               
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertUserApprovalLog");
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
        public bool UpdateUserApprovalLog(clsUserApprovalLog ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userId", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ls.userId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reqApprovalSts", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.reqApprovalSts ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.approvalById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@remarks", SqlDbType.VarChar, 500, ParameterDirection.Input, (object)ls.remarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.requestById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestTime", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestTime ?? DBNull.Value);

                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateUserApprovalLog");
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
        public List<clsUserApprovalLog> SelectAllUserApprovalLog()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllUserApprovalLog");

                List<clsUserApprovalLog> activeList = new List<clsUserApprovalLog>();
                TExecuteReaderCmd<clsUserApprovalLog>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsUserApprovalLog>, ref activeList);
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
        public List<clsUserApprovalLog> SelectUserApprovalLogById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectUserApprovalLogById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsUserApprovalLog> activeList = new List<clsUserApprovalLog>();
                TExecuteReaderCmd<clsUserApprovalLog>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsUserApprovalLog>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsUserApprovalLog> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsUserApprovalLog obj = new clsUserApprovalLog();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.reqApprovalSts = returnData["reqApprovalSts"] is DBNull ? (bool)false : (bool)returnData["reqApprovalSts"];
                    obj.approvalById = returnData["approvalById"] is DBNull ? (int)0 : (int)returnData["approvalById"];
                    obj.approvalDate = returnData["approvalDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["approvalDate"];
                    obj.remarks = returnData["remarks"] is DBNull ? (string)string.Empty : (string)returnData["remarks"];
                    obj.requestById = returnData["requestById"] is DBNull ? (int)0 : (int)returnData["requestById"];
                    obj.requestDate = returnData["requestDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["requestDate"];
                    obj.requestTime = returnData["requestTime"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["requestTime"];
                  

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
