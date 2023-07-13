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
   public class appSiteShiftsDAL : SQLDataAccess
    {
        public int InsertAppSiteShifts(clsAppSiteShifts obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteShiftName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteShiftName ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@shiftFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.shiftFrom ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@shiftTo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.shiftTo ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@shiftDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.shiftDescription ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@totalShiftEmployee", SqlDbType.Int, int.MaxValue, ParameterDirection.Input, (object)obj.totalShiftEmployee ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppSiteShifts", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppSiteShifts(clsAppSiteShifts obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteShiftName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.siteShiftName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@shiftFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.shiftFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@shiftTo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.shiftTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@shiftDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.shiftDescription ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalShiftEmployee", SqlDbType.Int, int.MaxValue, ParameterDirection.Input, (object)obj.totalShiftEmployee ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppSiteShifts", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppSiteShifts> SelectAllAppSiteShifts(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppSiteShifts");

                List<clsAppSiteShifts> activeList = new List<clsAppSiteShifts>();
                TExecuteReaderCmd<clsAppSiteShifts>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteShifts>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteShifts>();
        }
        public List<clsAppSiteShifts> SelectAppSiteShiftsByAppIdClientSiteId(int appId , int clientSiteId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteShiftsByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppSiteShifts> activeList = new List<clsAppSiteShifts>();
                TExecuteReaderCmd<clsAppSiteShifts>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteShifts>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteShifts>();
        } 
        public List<clsAppSiteShifts> SelectAppSiteShiftsById(int id ,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteShiftsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppSiteShifts> activeList = new List<clsAppSiteShifts>();
                TExecuteReaderCmd<clsAppSiteShifts>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteShifts>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteShifts>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppSiteShifts> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppSiteShifts obj = new clsAppSiteShifts();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.siteShiftName = returnData["siteShiftName"] is DBNull ? (string)string.Empty : (string)returnData["siteShiftName"];
                    obj.shiftFrom = returnData["shiftFrom"] is DBNull ? (string) string.Empty : (string)returnData["shiftFrom"];
                    obj.shiftTo = returnData["shiftTo"] is DBNull ? (string) string.Empty : (string)returnData["shiftTo"];
                    obj.shiftDescription = returnData["shiftDescription"] is DBNull ? (string)string.Empty: (string)returnData["shiftDescription"];
                    obj.totalShiftEmployee = returnData["totalShiftEmployee"] is DBNull ? (int)0 : (int)returnData["totalShiftEmployee"];
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
