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
   public class employeeBreakDownMasterDAL : SQLDataAccess
    {
        public int InsertEmployeeBreakDownMaster(clsEmployeeBreakDownMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfShifts", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfShifts ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isShiftWiseBreakDown", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isShiftWiseBreakDown ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertEmployeeBreakDownMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateEmployeeBreakDownMaster(clsEmployeeBreakDownMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfShifts", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfShifts ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isShiftWiseBreakDown", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isShiftWiseBreakDown ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateEmployeeBreakDownMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsEmployeeBreakDownMaster> SelectAllEmployeeBreakDownMaster(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllEmployeeBreakDownMaster");

                List<clsEmployeeBreakDownMaster> activeList = new List<clsEmployeeBreakDownMaster>();
                TExecuteReaderCmd<clsEmployeeBreakDownMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsEmployeeBreakDownMaster>, ref activeList);
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
        public List<clsEmployeeBreakDownMaster> SelectEmployeeBreakDownMasterById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectEmployeeBreakDownMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsEmployeeBreakDownMaster> activeList = new List<clsEmployeeBreakDownMaster>();
                TExecuteReaderCmd<clsEmployeeBreakDownMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsEmployeeBreakDownMaster>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsEmployeeBreakDownMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsEmployeeBreakDownMaster obj = new clsEmployeeBreakDownMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.isShiftWiseBreakDown = returnData["isShiftWiseBreakDown"] is DBNull ? (bool)false: (bool)returnData["isShiftWiseBreakDown"];
                    obj.noOfShifts = returnData["noOfShifts"] is DBNull ? (int)0 : (int)returnData["noOfShifts"];
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
