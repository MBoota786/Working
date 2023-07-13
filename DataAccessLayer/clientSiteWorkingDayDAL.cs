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
   public class clientSiteWorkingDayDAL : SQLDataAccess
    {
        public int InsertClientSiteWorkingDay(clsClientSiteWorkingDay obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayFromId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.weekDayFromId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayToId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.weekDayToId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientSiteWorkingDay", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientSiteWorkingDay(clsClientSiteWorkingDay obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayFromId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.weekDayFromId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayToId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.weekDayToId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientSiteWorkingDay", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientSiteWorkingDay> SelectAllClientSiteWorkingDay(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientSiteWorkingDay");

                List<clsClientSiteWorkingDay> adressList = new List<clsClientSiteWorkingDay>();
                TExecuteReaderCmd<clsClientSiteWorkingDay>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteWorkingDay>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteWorkingDay>();
        }
        public List<clsClientSiteWorkingDay> SelectClientSiteWorkingDayById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteWorkingDayById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientSiteWorkingDay> adressList = new List<clsClientSiteWorkingDay>();
                TExecuteReaderCmd<clsClientSiteWorkingDay>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteWorkingDay>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteWorkingDay>();
        }
        public List<clsClientSiteWorkingDay> SelectClientSiteWorkingDayClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteWorkingDayClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsClientSiteWorkingDay> adressList = new List<clsClientSiteWorkingDay>();
                TExecuteReaderCmd<clsClientSiteWorkingDay>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteWorkingDay>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteWorkingDay>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientSiteWorkingDay> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientSiteWorkingDay obj = new clsClientSiteWorkingDay();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.weekDayToId = returnData["weekDayToId"] is DBNull ? (int)0 : (int)returnData["weekDayToId"];
                    obj.weekDayFromId = returnData["weekDayFromId"] is DBNull ? (int)0 : (int)returnData["weekDayFromId"];
                     obj.WeekDayToName = returnData["WeekDayToName"] is DBNull ? (string)string.Empty : (string)returnData["WeekDayToName"];
                     obj.WeekDayFromName = returnData["WeekDayFromName"] is DBNull ? (string)string.Empty : (string)returnData["WeekDayFromName"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
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
