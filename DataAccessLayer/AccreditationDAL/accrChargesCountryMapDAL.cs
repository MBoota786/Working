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
   public class accrChargesCountryMapDAL : SQLDataAccess
    {
        public int InsertAccrChargesCountryMap(clsAccrChargesCountryMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrChargesAmountMapId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrChargesAmountMapId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrChargesCountryMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrChargesCountryMap(clsAccrChargesCountryMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrChargesAmountMapId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrChargesAmountMapId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrChargesCountryMap", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccrChargesCountryMap> SelectAllAccrChargesCountryMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrChargesCountryMap");

                List<clsAccrChargesCountryMap> activeList = new List<clsAccrChargesCountryMap>();
                TExecuteReaderCmd<clsAccrChargesCountryMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrChargesCountryMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrChargesCountryMap>();
        }
        public List<clsAccrChargesCountryMap> SelectAccrChargesCountryMapById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrChargesCountryMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrChargesCountryMap> activeList = new List<clsAccrChargesCountryMap>();
                TExecuteReaderCmd<clsAccrChargesCountryMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrChargesCountryMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrChargesCountryMap>();
        }
        public List<clsAccrChargesCountryMap> SelectAccrChargesCountryMapByAccrChargesAmountMapId(int accrChargesAmountMapId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrChargesCountryMapByAccrChargesAmountMapId");
                comand.Parameters.AddWithValue("@accrChargesAmountMapId", accrChargesAmountMapId);
                List<clsAccrChargesCountryMap> activeList = new List<clsAccrChargesCountryMap>();
                TExecuteReaderCmd<clsAccrChargesCountryMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrChargesCountryMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrChargesCountryMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrChargesCountryMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrChargesCountryMap obj = new clsAccrChargesCountryMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accrChargesAmountMapId = returnData["accrChargesAmountMapId"] is DBNull ? (int)0 : (int)returnData["accrChargesAmountMapId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.countryName = returnData["countryName"] is DBNull ? (string) string.Empty : (string)returnData["countryName"];
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
        public bool DeleteAccrChargesCountryMapByAccrChargesAmountMapId(int accrChargesAmountMapId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@accrChargesAmountMapId", SqlDbType.Int, 4, ParameterDirection.Input, (object)accrChargesAmountMapId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAccrChargesCountryMapByAccrChargesAmountMapId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
