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
   public class officeActiveLogDAL : SQLDataAccess
    {
        public int InsertOfficeActiveLog(clsOfficeActiveLog ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reqActiveSts", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.reqActiveSts ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.approvalById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@remarks", SqlDbType.VarChar, 500, ParameterDirection.Input, (object)ls.remarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.requestById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestTime", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestTime ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestRemarks", SqlDbType.VarChar, 500, ParameterDirection.Input, (object)ls.requestRemarks ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertOfficeActiveLog");
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
        public bool UpdateOfficeActiveLog(clsOfficeActiveLog ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reqActiveSts", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.reqActiveSts ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.approvalById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@remarks", SqlDbType.VarChar, 500, ParameterDirection.Input, (object)ls.remarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestById", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.requestById ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestTime", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.requestTime ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requestRemarks", SqlDbType.VarChar, 500, ParameterDirection.Input, (object)ls.requestRemarks ?? DBNull.Value);

                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateOfficeActiveLog");
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
        public List<clsOfficeActiveLog> SelectAllOfficeActiveLog()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeActiveLog");

                List<clsOfficeActiveLog> activeList = new List<clsOfficeActiveLog>();
                TExecuteReaderCmd<clsOfficeActiveLog>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsOfficeActiveLog>, ref activeList);
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
        public List<clsOfficeActiveLog> SelectOfficeActiveLogById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeActiveLogById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeActiveLog> activeList = new List<clsOfficeActiveLog>();
                TExecuteReaderCmd<clsOfficeActiveLog>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsOfficeActiveLog>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsOfficeActiveLog> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeActiveLog obj = new clsOfficeActiveLog();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.officeName = returnData["officeName"] is DBNull ? (string)string.Empty : (string)returnData["officeName"];
                    obj.reqActiveSts = returnData["reqActiveSts"] is DBNull ? (bool)false : (bool)returnData["reqActiveSts"];
                    obj.approvalById = returnData["approvalById"] is DBNull ? (int)0 : (int)returnData["approvalById"];
                    obj.approvalDate = returnData["approvalDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["approvalDate"];
                    obj.remarks = returnData["remarks"] is DBNull ? (string)string.Empty : (string)returnData["remarks"];
                    obj.requestById = returnData["requestById"] is DBNull ? (int)0 : (int)returnData["requestById"];
                    obj.requestDate = returnData["requestDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["requestDate"];
                    obj.requestTime = returnData["requestTime"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["requestTime"];
                    obj.requestRemarks = returnData["requestRemarks"] is DBNull ? (string)string.Empty : (string)returnData["requestRemarks"];

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
