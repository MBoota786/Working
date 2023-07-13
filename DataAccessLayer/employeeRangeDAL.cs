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
   public class employeeRangeDAL : SQLDataAccess
    {
        public int InsertEmployeeRange(clsEmployeeRange obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeStartRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeStartRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeEndRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeEndRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertEmployeeRange");
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
        public bool UpdateEmployeeRange(clsEmployeeRange obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardSetupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardSetupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeStartRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeStartRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeEndRange", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeEndRange ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateEmployeeRange");
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
        public List<clsEmployeeRange> SelectAllEmployeeRange()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllEmployeeRange");

                List<clsEmployeeRange> activeList = new List<clsEmployeeRange>();
                TExecuteReaderCmd<clsEmployeeRange>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsEmployeeRange>, ref activeList);
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
        public List<clsEmployeeRange> SelectEmployeeRangeById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectEmployeeRangeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsEmployeeRange> activeList = new List<clsEmployeeRange>();
                TExecuteReaderCmd<clsEmployeeRange>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsEmployeeRange>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsEmployeeRange> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsEmployeeRange obj = new clsEmployeeRange();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardSetupId = returnData["standardSetupId"] is DBNull ? (int)0 : (int)returnData["standardSetupId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.employeeStartRange = returnData["employeeStartRange"] is DBNull ? (int)0 : (int)returnData["employeeStartRange"];
                    obj.employeeEndRange = returnData["employeeEndRange"] is DBNull ? (int)0 : (int)returnData["employeeEndRange"];
                    obj.auditDays = returnData["auditDays"] is DBNull ? (int)0 : (int)returnData["auditDays"];
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
