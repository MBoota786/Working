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
   public class appQuotationFeesTaxDAL : SQLDataAccess
    {
        public int InsertAppQuotationFeesTax(clsAppQuotationFeesTax obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appQuotationFeesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appQuotationFeesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feesTaxRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feesTaxRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feesTaxValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feesTaxValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppQuotationFeesTax", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppQuotationFeesTax(clsAppQuotationFeesTax obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appQuotationFeesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appQuotationFeesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feesTaxRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feesTaxRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feesTaxValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feesTaxValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppQuotationFeesTax", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppQuotationFeesTax> SelectAllAppQuotationFeesTax(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppQuotationFeesTax");

                List<clsAppQuotationFeesTax> adressList = new List<clsAppQuotationFeesTax>();
                TExecuteReaderCmd<clsAppQuotationFeesTax>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFeesTax>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFeesTax>();
        }
        public List<clsAppQuotationFeesTax> SelectAppQuotationFeesTaxById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationFeesTaxById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppQuotationFeesTax> adressList = new List<clsAppQuotationFeesTax>();
                TExecuteReaderCmd<clsAppQuotationFeesTax>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFeesTax>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFeesTax>();
        } 
        public List<clsAppQuotationFeesTax> SelectAppQuotationFeesTaxByAppQuotationFeesId(int appQuotationFeesId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationFeesTaxByAppQuotationFeesId");
                comand.Parameters.AddWithValue("@appQuotationFeesId", appQuotationFeesId);
                List<clsAppQuotationFeesTax> adressList = new List<clsAppQuotationFeesTax>();
                TExecuteReaderCmd<clsAppQuotationFeesTax>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFeesTax>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFeesTax>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppQuotationFeesTax> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppQuotationFeesTax obj = new clsAppQuotationFeesTax();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appQuotationFeesId = returnData["appQuotationFeesId"] is DBNull ? (int)0 : (int)returnData["appQuotationFeesId"];
                    obj.officeTaxDtlId = returnData["officeTaxDtlId"] is DBNull ? (int)0 : (int)returnData["officeTaxDtlId"];
                    obj.feesTaxRate = returnData["feesTaxRate"] is DBNull ? (decimal)0 : (decimal)returnData["feesTaxRate"];
                    obj.feesTaxValue = returnData["feesTaxValue"] is DBNull ? (decimal)0 : (decimal)returnData["feesTaxValue"];
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
