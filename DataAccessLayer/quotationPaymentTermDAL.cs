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
   public class quotationPaymentTermDAL : SQLDataAccess
    {
        public int InsertQuotationPaymentTerm(clsQuotationPaymentTerm obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentTermDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentTermDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentTerm", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.paymentTerm ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertQuotationPaymentTerm", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateQuotationPaymentTerm(clsQuotationPaymentTerm obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentTermDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentTermDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentTerm", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.paymentTerm ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateQuotationPaymentTerm", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsQuotationPaymentTerm> spSelectAllQuotationPaymentTerm(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllQuotationPaymentTerm");
                List<clsQuotationPaymentTerm> activeList = new List<clsQuotationPaymentTerm>();
                TExecuteReaderCmd<clsQuotationPaymentTerm>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotationPaymentTerm>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsQuotationPaymentTerm> SelectQuotationPaymentTermById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuotationPaymentTermById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsQuotationPaymentTerm> activeList = new List<clsQuotationPaymentTerm>();
                TExecuteReaderCmd<clsQuotationPaymentTerm>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotationPaymentTerm>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsQuotationPaymentTerm> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsQuotationPaymentTerm obj = new clsQuotationPaymentTerm();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.paymentTermDays = returnData["paymentTermDays"] is DBNull ? (int)0 : (int)returnData["paymentTermDays"];
                    obj.paymentTerm = returnData["paymentTerm"] is DBNull ? (string)string.Empty : (string)returnData["paymentTerm"];
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
