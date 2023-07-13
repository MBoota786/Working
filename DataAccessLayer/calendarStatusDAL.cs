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
   public class calendarStatusDAL : SQLDataAccess
    {
        public int InsertCalendarStatus(clsCalendarStatus at)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calendarStatusName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.calendarStatusName ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertCalendarStatus", at.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCalendarStatus(clsCalendarStatus at)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calendarStatusName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.calendarStatusName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCalendarStatus", at.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsCalendarStatus> SelectAllCalendarStatus(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCalendarStatus");

                List<clsCalendarStatus> activeList = new List<clsCalendarStatus>();
                TExecuteReaderCmd<clsCalendarStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCalendarStatus>, ref activeList);
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
        public List<clsCalendarStatus> SelectCalendarStatusById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCalendarStatusById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCalendarStatus> activeList = new List<clsCalendarStatus>();
                TExecuteReaderCmd<clsCalendarStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCalendarStatus>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsCalendarStatus> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCalendarStatus obj = new clsCalendarStatus();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.calendarStatusName = returnData["calendarStatusName"] is DBNull ? (string)string.Empty : (string)returnData["calendarStatusName"];
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
