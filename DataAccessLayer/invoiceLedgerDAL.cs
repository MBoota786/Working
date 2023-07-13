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
   public class invoiceLedgerDAL : SQLDataAccess
    {
        public int InsertInvoiceLedger(clsInvoiceLedger obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.invoiceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buyerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.buyerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.chargesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargesAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.chargesAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@afterDueDateAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.afterDueDateAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paidAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.paidAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@balanceAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.balanceAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reInvoiceNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reInvoiceNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargesDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.chargesDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.paymentDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentRemarks", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.paymentRemarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.paymentDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertInvoiceLedger", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateInvoiceLedger(clsInvoiceLedger obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.invoiceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buyerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.buyerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.chargesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargesAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.chargesAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@afterDueDateAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.afterDueDateAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paidAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.paidAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@balanceAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.balanceAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reInvoiceNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reInvoiceNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargesDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.chargesDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentDetail", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.paymentDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentRemarks", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.paymentRemarks ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.paymentDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateInvoiceLedger", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsInvoiceLedger> SelectAllInvoiceLedger(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllInvoiceLedger");

                List<clsInvoiceLedger> activeList = new List<clsInvoiceLedger>();
                TExecuteReaderCmd<clsInvoiceLedger>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsInvoiceLedger>, ref activeList);
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
        public List<clsInvoiceLedger> SelectInvoiceLedgerById(int id,string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectInvoiceLedgerById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsInvoiceLedger> activeList = new List<clsInvoiceLedger>();
                TExecuteReaderCmd<clsInvoiceLedger>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsInvoiceLedger>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsInvoiceLedger> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsInvoiceLedger obj = new clsInvoiceLedger();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.invoiceId = returnData["invoiceId"] is DBNull ? (int)0 : (int)returnData["invoiceId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.clientId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.buyerId = returnData["buyerId"] is DBNull ? (int)0 : (int)returnData["buyerId"];
                    obj.chargesId = returnData["chargesId"] is DBNull ? (int)0 : (int)returnData["chargesId"];
                    obj.chargesAmount = returnData["chargesAmount"] is DBNull ? (decimal)0 : (decimal)returnData["chargesAmount"];
                    obj.afterDueDateAmount = returnData["afterDueDateAmount"] is DBNull ? (decimal)0 : (decimal)returnData["afterDueDateAmount"];
                    obj.paidAmount = returnData["paidAmount"] is DBNull ? (decimal)0 : (decimal)returnData["paidAmount"];
                    obj.balanceAmount = returnData["balanceAmount"] is DBNull ? (decimal)0 : (decimal)returnData["balanceAmount"];
                    obj.reInvoiceNo = returnData["reInvoiceNo"] is DBNull ? (int)0 : (int)returnData["reInvoiceNo"];
                    obj.chargesDetail = returnData["chargesDetail"] is DBNull ? (string)string.Empty : (string)returnData["chargesDetail"];
                    obj.paymentDetail = returnData["paymentDetail"] is DBNull ? (string)string.Empty : (string)returnData["paymentDetail"];
                    obj.paymentRemarks = returnData["paymentRemarks"] is DBNull ? (string)string.Empty : (string)returnData["paymentRemarks"];
                    obj.paymentDate = returnData["paymentDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["paymentDate"];
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
