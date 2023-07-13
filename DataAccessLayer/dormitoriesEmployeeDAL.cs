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
   public class dormitoriesEmployeeDAL : SQLDataAccess
    {
        public int InsertDormitoriesEmployee(clsDormitoriesEmployee obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dormitoriesEmployeeStartRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.dormitoriesEmployeeStartRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dormitoriesEmployeeEndRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.dormitoriesEmployeeEndRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dormitoriesAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.dormitoriesAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertDormitoriesEmployee");
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
        public bool UpdateDormitoriesEmployee(clsDormitoriesEmployee obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dormitoriesEmployeeStartRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.dormitoriesEmployeeStartRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dormitoriesEmployeeEndRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.dormitoriesEmployeeEndRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dormitoriesAuditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.dormitoriesAuditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateDormitoriesEmployee");
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
        public List<clsDormitoriesEmployee> SelectAllDormitoriesEmployee()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllDormitoriesEmployee");

                List<clsDormitoriesEmployee> activeList = new List<clsDormitoriesEmployee>();
                TExecuteReaderCmd<clsDormitoriesEmployee>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsDormitoriesEmployee>, ref activeList);
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
        public List<clsDormitoriesEmployee> SelectDormitoriesEmployeeById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectDormitoriesEmployeeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsDormitoriesEmployee> activeList = new List<clsDormitoriesEmployee>();
                TExecuteReaderCmd<clsDormitoriesEmployee>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsDormitoriesEmployee>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsDormitoriesEmployee> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsDormitoriesEmployee obj = new clsDormitoriesEmployee();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardSetupId = returnData["standardSetupId"] is DBNull ? (int)0 : (int)returnData["standardSetupId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.dormitoriesEmployeeStartRange = returnData["dormitoriesEmployeeStartRange"] is DBNull ? (int)0 : (int)returnData["dormitoriesEmployeeStartRange"];
                    obj.dormitoriesEmployeeEndRange = returnData["dormitoriesEmployeeEndRange"] is DBNull ? (int)0 : (int)returnData["dormitoriesEmployeeEndRange"];
                    obj.dormitoriesAuditDays = returnData["dormitoriesAuditDays"] is DBNull ? (int)0 : (int)returnData["dormitoriesAuditDays"];
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
