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
   public class officeStationaryPrefixDAL : SQLDataAccess
    {
        public int InsertOfficeStationaryPrefix(clsOfficeStationaryPrefix obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stationaryTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stationaryTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeStationaryPrefix", SqlDbType.Int, int.MaxValue, ParameterDirection.Input, (object)obj.officeStationaryPrefix ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@startFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.startFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@incrementNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.incrementNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@maxNumber", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.maxNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeStationaryPrefix", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeStationaryPrefix(clsOfficeStationaryPrefix obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stationaryTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stationaryTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeStationaryPrefix", SqlDbType.Int, int.MaxValue, ParameterDirection.Input, (object)obj.officeStationaryPrefix ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@startFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.startFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@incrementNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.incrementNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@maxNumber", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.maxNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeStationaryPrefix", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeStationaryPrefix> SelectAllOfficeStationaryPrefix(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeStationaryPrefix");

                List<clsOfficeStationaryPrefix> activeList = new List<clsOfficeStationaryPrefix>();
                TExecuteReaderCmd<clsOfficeStationaryPrefix>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeStationaryPrefix>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeStationaryPrefix>();
        }
        public List<clsOfficeStationaryPrefix> SelectOfficeStationaryPrefixById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeStationaryPrefixById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeStationaryPrefix> activeList = new List<clsOfficeStationaryPrefix>();
                TExecuteReaderCmd<clsOfficeStationaryPrefix>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeStationaryPrefix>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeStationaryPrefix>();
        }  public List<clsOfficeStationaryPrefix> SelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId(int officeId,int stationaryTypeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeStationaryPrefixByOfficeIdAndStationaryTypeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                comand.Parameters.AddWithValue("@stationaryTypeId", stationaryTypeId);
                List<clsOfficeStationaryPrefix> activeList = new List<clsOfficeStationaryPrefix>();
                TExecuteReaderCmd<clsOfficeStationaryPrefix>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeStationaryPrefix>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeStationaryPrefix>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeStationaryPrefix> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeStationaryPrefix obj = new clsOfficeStationaryPrefix();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.stationaryTypeId = returnData["stationaryTypeId"] is DBNull ? (int)0 : (int)returnData["stationaryTypeId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.officeStationaryPrefix = returnData["officeStationaryPrefix"] is DBNull ? (string)string.Empty : (string)returnData["officeStationaryPrefix"];
                    obj.startFrom = returnData["startFrom"] is DBNull ? (int)0: (int)returnData["startFrom"];
                    obj.incrementNo = returnData["incrementNo"] is DBNull ? (int)0: (int)returnData["incrementNo"];
                    obj.maxNumber = returnData["maxNumber"] is DBNull ? (int)0: (int)returnData["maxNumber"];
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
