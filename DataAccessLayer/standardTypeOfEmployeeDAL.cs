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
   public class standardTypeOfEmployeeDAL : SQLDataAccess
    {
        public int InsertStandardTypeOfEmployee(clsStandardTypeOfEmployee obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@empTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.empTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentEmpTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentEmpTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardTypeOfEmployee", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardTypeOfEmployee(clsStandardTypeOfEmployee obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@empTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.empTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentEmpTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentEmpTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardTypeOfEmployee", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardTypeOfEmployee> SelectAllStandardTypeOfEmployee(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardTypeOfEmployee");

                List<clsStandardTypeOfEmployee> activeList = new List<clsStandardTypeOfEmployee>();
                TExecuteReaderCmd<clsStandardTypeOfEmployee>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardTypeOfEmployee>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardTypeOfEmployee>();
        }
        public List<clsStandardTypeOfEmployee> SelectStandardTypeOfEmployeeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardTypeOfEmployeeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardTypeOfEmployee> activeList = new List<clsStandardTypeOfEmployee>();
                TExecuteReaderCmd<clsStandardTypeOfEmployee>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardTypeOfEmployee>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardTypeOfEmployee>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardTypeOfEmployee> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardTypeOfEmployee obj = new clsStandardTypeOfEmployee();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.empTypeName = returnData["empTypeName"] is DBNull ? (string)string.Empty : (string)returnData["empTypeName"];
                    obj.parentEmpTypeId = returnData["parentEmpTypeId"] is DBNull ? (int)0 : (int)returnData["parentEmpTypeId"];
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
