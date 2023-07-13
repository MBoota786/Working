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
   public class clientSiteHolidayDAL : SQLDataAccess
    {
        public int InsertClientSiteHoliday(clsClientSiteHoliday obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.weekDayId ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientSiteHoliday", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientSiteHoliday(clsClientSiteHoliday obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.weekDayId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientSiteHoliday", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool deleteClientSiteHolidayByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)clientSiteId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spdeleteClientSiteHolidayByClientSiteId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientSiteHoliday> SelectAllClientSiteHoliday(string dbName)
        {
            try
            {

                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientSiteHoliday");

                List<clsClientSiteHoliday> activeList = new List<clsClientSiteHoliday>();
                TExecuteReaderCmd<clsClientSiteHoliday>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteHoliday>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteHoliday>();
        }
        public List<clsClientSiteHoliday> SelectClientSiteHolidayById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteHolidayById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientSiteHoliday> activeList = new List<clsClientSiteHoliday>();
                TExecuteReaderCmd<clsClientSiteHoliday>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteHoliday>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteHoliday>();
        }   
        public List<clsClientSiteHoliday> SelectClientSiteHolidayByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteHolidayByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsClientSiteHoliday> activeList = new List<clsClientSiteHoliday>();
                TExecuteReaderCmd<clsClientSiteHoliday>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteHoliday>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteHoliday>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientSiteHoliday> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientSiteHoliday obj = new clsClientSiteHoliday();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.weekDayId = returnData["weekDayId"] is DBNull ? (int)0 : (int)returnData["weekDayId"];
                    obj.dayName = ColumnExists(returnData, "dayName") ? returnData["dayName"] is DBNull ? (string) string.Empty : (string)returnData["dayName"] : string.Empty;
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
