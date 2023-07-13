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
  public class interviewSamplingDAL : SQLDataAccess
    {
        public int InsertInterviewSampling(clsInterviewSampling ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeStartRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.employeeStartRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeEndRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.employeeEndRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@individualInterviews", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.individualInterviews ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@groupInterviews", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.groupInterviews ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@estimatedTimeInMinutes", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.estimatedTimeInMinutes ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalRecordedViews", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.totalRecordedViews ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertInterviewSampling");
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
        public bool UpdateInterviewSampling(clsInterviewSampling ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeStartRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.employeeStartRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeEndRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.employeeEndRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@individualInterviews", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.individualInterviews ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@groupInterviews", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.groupInterviews ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@estimatedTimeInMinutes", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.estimatedTimeInMinutes ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalRecordedViews", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.totalRecordedViews ?? DBNull.Value); AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateInterviewSampling");
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
        public List<clsInterviewSampling> SelectAllInterviewSampling()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllInterviewSampling");

                List<clsInterviewSampling> activeList = new List<clsInterviewSampling>();
                TExecuteReaderCmd<clsInterviewSampling>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsInterviewSampling>, ref activeList);
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
        public List<clsInterviewSampling> SelectInterviewSamplingById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectInterviewSamplingById");
                comand.Parameters.AddWithValue("@id", id);

                List<clsInterviewSampling> activeList = new List<clsInterviewSampling>();
                TExecuteReaderCmd<clsInterviewSampling>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsInterviewSampling>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsInterviewSampling> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsInterviewSampling obj = new clsInterviewSampling();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.employeeStartRange = returnData["employeeStartRange"] is DBNull ? (int)0 : (int)returnData["employeeStartRange"];
                    obj.employeeEndRange = returnData["employeeEndRange"] is DBNull ? (int)0 : (int)returnData["employeeEndRange"];
                    obj.individualInterviews = returnData["individualInterviews"] is DBNull ? (int)0 : (int)returnData["individualInterviews"];
                    obj.groupInterviews = returnData["groupInterviews"] is DBNull ? (int)0 : (int)returnData["groupInterviews"];
                    obj.estimatedTimeInMinutes = returnData["estimatedTimeInMinutes"] is DBNull ? (int)0 : (int)returnData["estimatedTimeInMinutes"];
                    obj.totalRecordedViews = returnData["totalRecordedViews"] is DBNull ? (int)0 : (int)returnData["totalRecordedViews"];
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
