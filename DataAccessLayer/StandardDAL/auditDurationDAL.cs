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
   public class auditDurationDAL     : SQLDataAccess
    {
        public int InsertAuditDuration(clsAuditDuration obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@minDurationValue", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.minDurationValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@maxDurationValue", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.maxDurationValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditDuration", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditDuration(clsAuditDuration obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@timePeriodUnitId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.timePeriodUnitId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@minDurationValue", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.minDurationValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@maxDurationValue", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.maxDurationValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditDuration", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAuditDuration> SelectAllAuditDuration(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditDuration");

                List<clsAuditDuration> activeList = new List<clsAuditDuration>();
                TExecuteReaderCmd<clsAuditDuration>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditDuration>, ref activeList);
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
        public List<clsAuditDuration> SelectAuditDurationById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditDurationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditDuration> activeList = new List<clsAuditDuration>();
                TExecuteReaderCmd<clsAuditDuration>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditDuration>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditDuration> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditDuration obj = new clsAuditDuration();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.timePeriodUnitId = returnData["timePeriodUnitId"] is DBNull ? (int)0 : (int)returnData["timePeriodUnitId"];
                    obj.minDurationValue = returnData["minDurationValue"] is DBNull ? (int)0 : (int)returnData["minDurationValue"];
                    obj.maxDurationValue = returnData["maxDurationValue"] is DBNull ? (int)0 : (int)returnData["maxDurationValue"];
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
