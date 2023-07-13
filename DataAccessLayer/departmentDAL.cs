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
   public class departmentDAL : SQLDataAccess
    {
        public int InsertDepartment(clsDepartment obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentDepartmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@departmentName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.departmentName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertDepartment", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateDepartment(clsDepartment obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentDepartmentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@departmentName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.departmentName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateDepartment", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsDepartment> SelectAllDepartment(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllDepartment");

                List<clsDepartment> activeList = new List<clsDepartment>();
                TExecuteReaderCmd<clsDepartment>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsDepartment>, ref activeList);
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
        public List<clsDepartment> SelectDepartmentById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectDepartmentById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsDepartment> activeList = new List<clsDepartment>();
                TExecuteReaderCmd<clsDepartment>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsDepartment>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsDepartment> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsDepartment obj = new clsDepartment();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.parentDepartmentId = returnData["parentDepartmentId"] is DBNull ? (int)0 : (int)returnData["parentDepartmentId"];
                    obj.departmentName = returnData["departmentName"] is DBNull ? (string)string.Empty : (string)returnData["departmentName"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
