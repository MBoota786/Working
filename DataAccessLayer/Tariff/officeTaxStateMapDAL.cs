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
   public class officeTaxStateMapDAL : SQLDataAccess
    {
        public int InsertOfficeTaxStateMap(clsOfficeTaxStateMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeTaxStateMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeTaxStateMap(clsOfficeTaxStateMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeTaxStateMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool DeleteOfficeTaxStateMapByOfficeTaxDetailId(int officeTaxDetailId,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@officeTaxDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)officeTaxDetailId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteOfficeTaxStateMapByOfficeTaxDetailId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeTaxStateMap> SelectAllOfficeTaxStateMap(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeTaxStateMap");
                SetDBName(dbName);
                List<clsOfficeTaxStateMap> activeList = new List<clsOfficeTaxStateMap>();
                TExecuteReaderCmd<clsOfficeTaxStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxStateMap>();
        }
        public List<clsOfficeTaxStateMap> SelectOfficeTaxStateMapById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxStateMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeTaxStateMap> activeList = new List<clsOfficeTaxStateMap>();
                TExecuteReaderCmd<clsOfficeTaxStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxStateMap>();
        } 
        public List<clsOfficeTaxStateMap> SelectOfficeTaxStateMapByOfficeTaxDetailId(int officeTaxDetailId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxStateMapByOfficeTaxDetailId");
                comand.Parameters.AddWithValue("@officeTaxDetailId", officeTaxDetailId);
                List<clsOfficeTaxStateMap> activeList = new List<clsOfficeTaxStateMap>();
                TExecuteReaderCmd<clsOfficeTaxStateMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxStateMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxStateMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeTaxStateMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeTaxStateMap obj = new clsOfficeTaxStateMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.stateProvinceName = returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"];
                    obj.officeTaxDetailId = returnData["officeTaxDetailId"] is DBNull ? (int) 0 : (int)returnData["officeTaxDetailId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int) 0 : (int)returnData["stateProvinceId"];
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
