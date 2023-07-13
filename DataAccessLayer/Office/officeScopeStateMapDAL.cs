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
   public class officeScopeStateMapDAL : SQLDataAccess
    {
        public int InsertOfficeScopeStateMap(clsOfficeScopeStateMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeScopeStateMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeScopeStateMap(clsOfficeScopeStateMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeScopeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeScopeStateMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool DeleteOfficeScopeStateMap(int officeScopeId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeScopeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeScopeId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteOfficeScopeStateMap", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeScopeStateMap> spSelectOfficeScopeStateMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeStateMap");

                List<clsOfficeScopeStateMap> activeList = new List<clsOfficeScopeStateMap>();
                TExecuteReaderCmd<clsOfficeScopeStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeStateMap>();
        }
        public List<clsOfficeScopeStateMap> SelectOfficeScopeStateMapById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeStateMap");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeScopeStateMap> activeList = new List<clsOfficeScopeStateMap>();
                TExecuteReaderCmd<clsOfficeScopeStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeStateMap>();
        } 
        public List<clsOfficeScopeStateMap> spSelectOfficeScopeStateMapByOfficeScopeId(int officeScopeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeScopeStateMapByOfficeScopeId");
                comand.Parameters.AddWithValue("@officeScopeId", officeScopeId);
                List<clsOfficeScopeStateMap> activeList = new List<clsOfficeScopeStateMap>();
                TExecuteReaderCmd<clsOfficeScopeStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeScopeStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeScopeStateMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeScopeStateMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeScopeStateMap obj = new clsOfficeScopeStateMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeScopeId = returnData["officeScopeId"] is DBNull ? (int)0 : (int)returnData["officeScopeId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.stateProvinceName = ColumnExists(returnData, "stateProvinceName") ? returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"] : string.Empty;

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
