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
   public class appQuotationFeesDAL : SQLDataAccess
    {
        public int InsertAppQuotationFees(clsAppQuotationFees obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationQuotationDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationQuotationDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculateFeeValueInUSD", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.calculateFeeValueInUSD ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalFeeValueInUSD", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.finalFeeValueInUSD ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalAfterTax", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.totalAfterTax ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppQuotationFees", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppQuotationFees(clsAppQuotationFees obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationQuotationDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationQuotationDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculateFeeValueInUSD", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.calculateFeeValueInUSD ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalFeeValueInUSD", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.finalFeeValueInUSD ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalAfterTax", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.totalAfterTax ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppQuotationFees", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppQuotationFees> SelectAllAppQuotationFees(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppQuotationFees");

                List<clsAppQuotationFees> adressList = new List<clsAppQuotationFees>();
                TExecuteReaderCmd<clsAppQuotationFees>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFees>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFees>();
        }
        public List<clsAppQuotationFees> spSelectAppQuotationFeesById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationFeesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppQuotationFees> adressList = new List<clsAppQuotationFees>();
                TExecuteReaderCmd<clsAppQuotationFees>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFees>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFees>();
        } 
        public List<clsAppQuotationFees> SelectAppQuotationFeesByApplicationQuotationDtlId(int applicationQuotationDtlId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationFeesByApplicationQuotationDtlId");
                comand.Parameters.AddWithValue("@applicationQuotationDtlId", applicationQuotationDtlId);
                List<clsAppQuotationFees> adressList = new List<clsAppQuotationFees>();
                TExecuteReaderCmd<clsAppQuotationFees>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFees>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFees>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppQuotationFees> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppQuotationFees obj = new clsAppQuotationFees();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.applicationQuotationDtlId = returnData["applicationQuotationDtlId"] is DBNull ? (int)0 : (int)returnData["applicationQuotationDtlId"];
                    obj.standardServiceFeeId = returnData["standardServiceFeeId"] is DBNull ? (int)0 : (int)returnData["standardServiceFeeId"];
                    obj.calculateFeeValueInUSD = returnData["calculateFeeValueInUSD"] is DBNull ? (decimal)0 : (decimal)returnData["calculateFeeValueInUSD"];
                    obj.finalFeeValueInUSD = returnData["finalFeeValueInUSD"] is DBNull ? (decimal)0 : (decimal)returnData["finalFeeValueInUSD"];
                    obj.taxValue = returnData["taxValue"] is DBNull ? (decimal)0 : (decimal)returnData["taxValue"];
                    obj.totalAfterTax = returnData["totalAfterTax"] is DBNull ? (decimal)0 : (decimal)returnData["totalAfterTax"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
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
