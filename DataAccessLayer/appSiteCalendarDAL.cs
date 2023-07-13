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
   public class appSiteCalendarDAL : SQLDataAccess
    {
        public int InsertAppSiteCalendar(clsAppSiteCalendar obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteCalendarDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.siteCalendarDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkingDay", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkingDay ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppSiteCalendar", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppSiteCalendar(clsAppSiteCalendar obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteCalendarDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.siteCalendarDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isWorkingDay", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isWorkingDay ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppSiteCalendar", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAppSiteCalendar> SelectAllAppSiteCalendar(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppSiteCalendar");

                List<clsAppSiteCalendar> activeList = new List<clsAppSiteCalendar>();
                TExecuteReaderCmd<clsAppSiteCalendar>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteCalendar>, ref activeList);
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
        public List<clsAppSiteCalendar> SelectAppSiteCalendarById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteCalendarById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppSiteCalendar> activeList = new List<clsAppSiteCalendar>();
                TExecuteReaderCmd<clsAppSiteCalendar>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteCalendar>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppSiteCalendar> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppSiteCalendar obj = new clsAppSiteCalendar();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.siteCalendarDate = returnData["siteCalendarDate"] is DBNull ? (DateTime?)null: (DateTime)returnData["siteCalendarDate"];
                    obj.isWorkingDay = returnData["isWorkingDay"] is DBNull ? (bool)false: (bool)returnData["isWorkingDay"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
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
