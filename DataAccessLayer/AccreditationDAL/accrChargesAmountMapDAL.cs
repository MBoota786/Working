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
   public class accrChargesAmountMapDAL : SQLDataAccess
    {
        public int InsertAccrChargesAmountMap(clsAccrChargesAmountMap obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationChargesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationChargesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@amountValueTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.amountValueTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrCharges", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.accrCharges ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@validityFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.validityFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@validityTill", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.validityTill ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrChargesAmountMap", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrChargesAmountMap(clsAccrChargesAmountMap obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationChargesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationChargesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@amountValueTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.amountValueTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrCharges", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.accrCharges ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@validityFrom", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.validityFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@validityTill", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.validityTill ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrChargesAmountMap", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccrChargesAmountMap> SelectAllAccrChargesAmountMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrChargesAmountMap");

                List<clsAccrChargesAmountMap> activeList = new List<clsAccrChargesAmountMap>();
                TExecuteReaderCmd<clsAccrChargesAmountMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrChargesAmountMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrChargesAmountMap>();
        }
        public List<clsAccrChargesAmountMap> SelectAccrChargesAmountMapById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrChargesAmountMapById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrChargesAmountMap> activeList = new List<clsAccrChargesAmountMap>();
                TExecuteReaderCmd<clsAccrChargesAmountMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrChargesAmountMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrChargesAmountMap>();
        }
        public List<clsAccrChargesAmountMap> SelectAccrChargesAmountMapByAccreditationChargesId(int accreditationChargesId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrChargesAmountMapByAccreditationChargesId");
                comand.Parameters.AddWithValue("@accreditationChargesId", accreditationChargesId);
                List<clsAccrChargesAmountMap> activeList = new List<clsAccrChargesAmountMap>();
                TExecuteReaderCmd<clsAccrChargesAmountMap>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrChargesAmountMap>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrChargesAmountMap>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrChargesAmountMap> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrChargesAmountMap obj = new clsAccrChargesAmountMap();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationChargesId = returnData["accreditationChargesId"] is DBNull ? (int)0 : (int)returnData["accreditationChargesId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.amountValueTypeId = returnData["amountValueTypeId"] is DBNull ? (int)0 : (int)returnData["amountValueTypeId"];
                   obj.accrCharges = returnData["accrCharges"] is DBNull ? (decimal) 0 : (decimal)returnData["accrCharges"];
                    obj.validityFrom = returnData["validityFrom"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["validityFrom"];
                    obj.validityTill = returnData["validityTill"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["validityTill"];
                    obj.amountType = returnData["amountType"] is DBNull ? (string) string.Empty : (string)returnData["amountType"];
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
        public bool ActiveFalseForDeleteAccrChargesAmountMapById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spActiveFalseForDeleteAccrChargesAmountMapById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
