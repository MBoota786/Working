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
   public class appSiteShiftsDayMapDAL : SQLDataAccess
    {
        public int InsertAppSiteShiftsDayMap(clsAppSiteShiftsDayMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appSiteShiftsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appSiteShiftsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.weekDayId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppSiteShiftsDayMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppSiteShiftsDayMap(clsAppSiteShiftsDayMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appSiteShiftsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appSiteShiftsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@weekDayId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.weekDayId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppSiteShiftsDayMap", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAppSiteShiftsDayMap> SelectAllAppSiteShiftsDayMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppSiteShiftsDayMap");

                List<clsAppSiteShiftsDayMap> adressList = new List<clsAppSiteShiftsDayMap>();
                TExecuteReaderCmd<clsAppSiteShiftsDayMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteShiftsDayMap>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteShiftsDayMap>();
        }
        public List<clsAppSiteShiftsDayMap> SelectAppSiteShiftsDayMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteShiftsDayMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppSiteShiftsDayMap> adressList = new List<clsAppSiteShiftsDayMap>();
                TExecuteReaderCmd<clsAppSiteShiftsDayMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteShiftsDayMap>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteShiftsDayMap>();
        }
        public List<clsAppSiteShiftsDayMap> SelectAppSiteShiftsDayMapByAppSiteShiftsId(int appSiteShiftsId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteShiftsDayMapByAppSiteShiftsId");
                comand.Parameters.AddWithValue("@appSiteShiftsId", appSiteShiftsId);
                List<clsAppSiteShiftsDayMap> adressList = new List<clsAppSiteShiftsDayMap>();
                TExecuteReaderCmd<clsAppSiteShiftsDayMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteShiftsDayMap>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteShiftsDayMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppSiteShiftsDayMap> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppSiteShiftsDayMap obj = new clsAppSiteShiftsDayMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appSiteShiftsId = returnData["appSiteShiftsId"] is DBNull ? (int)0 : (int)returnData["appSiteShiftsId"];
                    obj.weekDayId = returnData["weekDayId"] is DBNull ? (int)0 : (int)returnData["weekDayId"];
                    obj.dayName =ColumnExists(returnData, "dayName")? returnData["dayName"] is DBNull ? (string) string.Empty : (string)returnData["dayName"] : string.Empty;
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
