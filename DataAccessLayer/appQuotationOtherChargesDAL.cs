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
   public class appQuotationOtherChargesDAL : SQLDataAccess
   {
        public int InsertAppQuotationOtherCharges(clsAppQuotationOtherCharges obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationQuotationDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationQuotationDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceFeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.chargeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isTBD", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isTBD ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                //_____ saqib  : 6/20/2023 byHuzafa _____
                AddParamToSQLCmd(comm, "@expenseTypeTax", SqlDbType.VarChar, 20, ParameterDirection.Input, (object)obj.expenseTypeTax ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppQuotationOtherCharges", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }

        public bool UpdateAppQuotationOtherCharges(clsAppQuotationOtherCharges obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationQuotationDtlId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationQuotationDtlId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceFeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.chargeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isTBD", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isTBD ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeTaxDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.taxValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@expenseTypeTax", SqlDbType.VarChar, 20, ParameterDirection.Input, (object)obj.expenseTypeTax ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppQuotationOtherCharges", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public List<clsAppQuotationOtherCharges> SelectAllAppQuotationOtherCharges(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppQuotationOtherCharges");

                List<clsAppQuotationOtherCharges> activeList = new List<clsAppQuotationOtherCharges>();
                TExecuteReaderCmd<clsAppQuotationOtherCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationOtherCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationOtherCharges>();
        }
      
        public List<clsAppQuotationOtherCharges> SelectAppQuotationOtherChargesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationOtherChargesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppQuotationOtherCharges> activeList = new List<clsAppQuotationOtherCharges>();
                TExecuteReaderCmd<clsAppQuotationOtherCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationOtherCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationOtherCharges>();
        }


        public List<clsAppQuotationOtherCharges> SelectAppQuotationOtherChargesByApplicationQuotationDtlId(int applicationQuotationDtlId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationOtherChargesByApplicationQuotationDtlId");
                comand.Parameters.AddWithValue("@applicationQuotationDtlId", applicationQuotationDtlId);
                List<clsAppQuotationOtherCharges> activeList = new List<clsAppQuotationOtherCharges>();
                TExecuteReaderCmd<clsAppQuotationOtherCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationOtherCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationOtherCharges>();
        } 

        public List<clsAppQuotationOtherCharges> SelectAppQuotationOtherChargesForPrintByClientSiteIdAndQuotationId(int clientSiteId,int quotationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationOtherChargesForPrintByClientSiteIdAndQuotationId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                comand.Parameters.AddWithValue("@quotationId", quotationId);
                List<clsAppQuotationOtherCharges> activeList = new List<clsAppQuotationOtherCharges>();
                TExecuteReaderCmd<clsAppQuotationOtherCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationOtherCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationOtherCharges>();
        }   

        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppQuotationOtherCharges> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppQuotationOtherCharges obj = new clsAppQuotationOtherCharges();
                    obj.id = ColumnExists(returnData,"id")? returnData["id"] is DBNull ? (int)0 : (int)returnData["id"] : 0;
                    obj.applicationQuotationDtlId = ColumnExists(returnData, "applicationQuotationDtlId") ? returnData["applicationQuotationDtlId"] is DBNull ? (int)0 : (int)returnData["applicationQuotationDtlId"] : 0;
                    obj.serviceFeeTypeId = ColumnExists(returnData, "serviceFeeTypeId") ? returnData["serviceFeeTypeId"] is DBNull ? (int)0 : (int)returnData["serviceFeeTypeId"] : 0;
                    obj.chargeValue = ColumnExists(returnData, "chargeValue") ? returnData["chargeValue"] is DBNull ? (decimal)0 : (decimal)returnData["chargeValue"] : 0;
                    obj.isTBD = ColumnExists(returnData, "isTBD") ? returnData["isTBD"] is DBNull ? (bool)false : (bool)returnData["isTBD"] : false;
                    obj.taxRate = ColumnExists(returnData, "taxRate") ? returnData["taxRate"] is DBNull ? (decimal) 0 : (decimal)returnData["taxRate"] : 0;
                    obj.taxValue = ColumnExists(returnData, "taxValue") ? returnData["taxValue"] is DBNull ? (decimal) 0 : (decimal)returnData["taxValue"] : 0;
                    obj.currencyId = ColumnExists(returnData, "currencyId") ? returnData["currencyId"] is DBNull ? (int)0 : (int)returnData["currencyId"] : 0;
                    obj.serviceFeeTypeName = ColumnExists(returnData, "serviceFeeTypeName") ? returnData["serviceFeeTypeName"] is DBNull ? (string) string.Empty : (string)returnData["serviceFeeTypeName"] : string.Empty;
                    obj.currencyShortName = ColumnExists(returnData, "currencyShortName") ? returnData["currencyShortName"] is DBNull ? (string) string.Empty : (string)returnData["currencyShortName"] : string.Empty;
                    obj.symbol = ColumnExists(returnData, "symbol") ? returnData["symbol"] is DBNull ? (string) string.Empty : (string)returnData["symbol"] : string.Empty;
                    //_____ saqib  : 6/20/2023 by_Huzafa _____
                    obj.expenseTypeTax = ColumnExists(returnData, "expenseTypeTax") ? returnData["expenseTypeTax"] is DBNull ? (string) string.Empty : (string)returnData["expenseTypeTax"] : string.Empty;
                    //----
                    obj.active = ColumnExists(returnData, "active") ? returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"] : false;
                    obj.createdOn = ColumnExists(returnData, "createdOn") ? returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"] : DateTime.Now;
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
