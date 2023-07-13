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
   public class employeeBreakDownDtlDAL : SQLDataAccess
    {
        public int InsertEmployeeBreakDownDtl(clsEmployeeBreakDownDtl obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeBreakDownMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeBreakDownMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@formulaStepNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.formulaStepNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditEmployeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditEmployeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@formulaOperation", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.formulaOperation ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@empBreakDownDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.empBreakDownDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertEmployeeBreakDownDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateEmployeeBreakDownDtl(clsEmployeeBreakDownDtl obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeBreakDownMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeBreakDownMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@formulaStepNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.formulaStepNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditEmployeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditEmployeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@formulaOperation", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.formulaOperation ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@empBreakDownDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.empBreakDownDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateEmployeeBreakDownDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsEmployeeBreakDownDtl> SelectAllEmployeeBreakDownDtl(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllEmployeeBreakDownDtl");

                List<clsEmployeeBreakDownDtl> activeList = new List<clsEmployeeBreakDownDtl>();
                TExecuteReaderCmd<clsEmployeeBreakDownDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsEmployeeBreakDownDtl>, ref activeList);
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
        public List<clsEmployeeBreakDownDtl> SelectEmployeeBreakDownDtlById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectEmployeeBreakDownDtlById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsEmployeeBreakDownDtl> activeList = new List<clsEmployeeBreakDownDtl>();
                TExecuteReaderCmd<clsEmployeeBreakDownDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsEmployeeBreakDownDtl>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsEmployeeBreakDownDtl> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsEmployeeBreakDownDtl obj = new clsEmployeeBreakDownDtl();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.employeeBreakDownMasterId = returnData["employeeBreakDownMasterId"] is DBNull ? (int)0 : (int)returnData["employeeBreakDownMasterId"];
                    obj.formulaStepNo = returnData["formulaStepNo"] is DBNull ? (int)0 : (int)returnData["formulaStepNo"];
                    obj.auditEmployeeTypeId = returnData["auditEmployeeTypeId"] is DBNull ? (int)0 : (int)returnData["auditEmployeeTypeId"];
                    obj.formulaOperation = returnData["formulaOperation"] is DBNull ? (string) string.Empty : (string)returnData["formulaOperation"];
                    obj.empBreakDownDtlId = returnData["empBreakDownDtlId"] is DBNull ? (int)0 : (int)returnData["empBreakDownDtlId"];
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
