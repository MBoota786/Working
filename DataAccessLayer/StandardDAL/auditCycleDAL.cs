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
  public class auditCycleDAL : SQLDataAccess
    {
        public int InsertAuditCycle(clsAuditCycle ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@durationInYearsq", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.durationInYear ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditCycle", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditCycle(clsAuditCycle ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@durationInYearsq", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.durationInYear ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditCycle", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditCycle> SelectAllAuditCycle(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditCycle");

                List<clsAuditCycle> activeList = new List<clsAuditCycle>();
                TExecuteReaderCmd<clsAuditCycle>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditCycle>, ref activeList);
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
        public List<clsAuditCycle> SelectAuditCycleById(int id , string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditCycleById");
                comand.Parameters.AddWithValue("@id", id);
        
                List<clsAuditCycle> activeList = new List<clsAuditCycle>();
                TExecuteReaderCmd<clsAuditCycle>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditCycle>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditCycle> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditCycle obj = new clsAuditCycle();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.durationInYear = returnData["durationInYear"] is DBNull ? (int)0 : (int)returnData["durationInYear"];
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
