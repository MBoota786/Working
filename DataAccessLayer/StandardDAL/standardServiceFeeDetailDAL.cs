using Dapper;
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
   public class standardServiceFeeDetailDAL : SQLDataAccess
    {
        public int InsertStandardServiceFeeDetail(clsStandardServiceFeeDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.feeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAmount", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardFeeCriteriaId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardFeeCriteriaId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isPercent", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.isPercent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isOtherCharge", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.isOtherCharge ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardServiceFeeDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardServiceFeeDetail(clsStandardServiceFeeDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.feeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAmount", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAmount ?? DBNull.Value); 
                AddParamToSQLCmd(comm, "@feeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardFeeCriteriaId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardFeeCriteriaId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isPercent", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.isPercent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isOtherCharge", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.isOtherCharge ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardServiceFeeDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardServiceFeeDetail> SelectAllStandardServiceFeeDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardServiceFeeDetail");

                List<clsStandardServiceFeeDetail> activeList = new List<clsStandardServiceFeeDetail>();
                TExecuteReaderCmd<clsStandardServiceFeeDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardServiceFeeDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardServiceFeeDetail>();
        }
      
        public List<clsStandardServiceFeeDetail> SelectAllStandardServiceFeeDetailByStandardServiceFeeId(int standardServiceFeeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardServiceFeeDetailByStandardServiceFeeId");
                comand.Parameters.AddWithValue("@standardServiceFeeId", standardServiceFeeId);
                List<clsStandardServiceFeeDetail> activeList = new List<clsStandardServiceFeeDetail>();
                TExecuteReaderCmd<clsStandardServiceFeeDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardServiceFeeDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardServiceFeeDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardServiceFeeDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardServiceFeeDetail obj = new clsStandardServiceFeeDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.standardServiceFeeId = returnData["standardServiceFeeId"] is DBNull ? (int)0 : (int)returnData["standardServiceFeeId"];
                    obj.serviceId = returnData["serviceId"] is DBNull ? (int)0 : (int)returnData["serviceId"];
                    obj.feeName = returnData["feeName"] is DBNull ? (string) string.Empty : (string)returnData["feeName"];
                    obj.isAmount = returnData["isAmount"] is DBNull ? (bool)false : (bool)returnData["isAmount"];
                    obj.feeValue = returnData["feeValue"] is DBNull ? (decimal) 0 : (decimal)returnData["feeValue"];
                    obj.currencyId = returnData["currencyId"] is DBNull ? (int)0 : (int)returnData["currencyId"];
                    obj.standardFeeCriteriaId = returnData["standardFeeCriteriaId"] is DBNull ? (int)0 : (int)returnData["standardFeeCriteriaId"];
                    obj.isPercent = returnData["isPercent"] is DBNull ? (bool)true : (bool)returnData["isPercent"];
                    obj.standardServiceFeeDetailId = returnData["standardServiceFeeDetailId"] is DBNull ? (int)0 : (int)returnData["standardServiceFeeDetailId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.isOtherCharge = returnData["isOtherCharge"] is DBNull ? (bool)true : (bool)returnData["isOtherCharge"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];

                    obj.symbol = ColumnExists(returnData, "symbol") ? returnData["symbol"] is DBNull ? (string)string.Empty : (string)returnData["symbol"] : string.Empty;
                    obj.criteriaName = ColumnExists(returnData, "criteriaName") ? returnData["criteriaName"] is DBNull ? (string)string.Empty : (string)returnData["criteriaName"] : string.Empty;
                    obj.auditTypeName = ColumnExists(returnData, "auditTypeName") ? returnData["auditTypeName"] is DBNull ? (string)string.Empty : (string)returnData["auditTypeName"] : string.Empty;

                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsStandardServiceFeeDetail> SelectStandardFeeDetailForTariffByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@accreditationStandardId", accreditationStandardId, DbType.Int32, ParameterDirection.Input);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsStandardServiceFeeDetail>("spSelectStandardFeeDetailForTariffByAccreditationStandardId", parameters,commandType:CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
