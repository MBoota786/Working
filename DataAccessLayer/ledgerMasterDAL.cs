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
   public class ledgerMasterDAL : SQLDataAccess
    {
        public int InsertLedgerMaster(clsLedgerMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@trTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.trTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.invoiceTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.invoiceNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@payableId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.payableId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.invoiceDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dueDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.dueDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClient", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClient ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isChildOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isChildOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.invoiceStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nextInvoiceNumber", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.nextInvoiceNumber?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertLedgerMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateLedgerMaster(clsLedgerMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@trTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.trTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.invoiceTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.invoiceNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@payableId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.payableId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.invoiceDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dueDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.dueDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClient", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClient ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isChildOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isChildOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.invoiceStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nextInvoiceNumber", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.nextInvoiceNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateLedgerMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsLedgerMaster> SelectAllLedgerMaster(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllLedgerMaster");
                SetDBName(dbName);
                List<clsLedgerMaster> activeList = new List<clsLedgerMaster>();
                TExecuteReaderCmd<clsLedgerMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLedgerMaster>, ref activeList);
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
        public List<clsLedgerMaster> SelectLedgerMasterById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectLedgerMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsLedgerMaster> activeList = new List<clsLedgerMaster>();
                TExecuteReaderCmd<clsLedgerMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLedgerMaster>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsLedgerMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsLedgerMaster obj = new clsLedgerMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.trTypeId = returnData["trTypeId"] is DBNull ? (int)0 : (int)returnData["trTypeId"];
                    obj.invoiceTypeId = returnData["invoiceTypeId"] is DBNull ? (int)0 : (int)returnData["invoiceTypeId"];
                    obj.invoiceNo = returnData["invoiceNo"] is DBNull ? (string)string.Empty : (string)returnData["invoiceNo"];
                    obj.payableId = returnData["payableId"] is DBNull ? (int)0 : (int)returnData["payableId"];
                    obj.invoiceDate = returnData["invoiceDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["invoiceDate"];
                    obj.dueDate = returnData["dueDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["dueDate"];
                    obj.isClient = returnData["isClient"] is DBNull ? (bool)false : (bool)returnData["isClient"];
                    obj.isParentOffice = returnData["isParentOffice"] is DBNull ? (bool)false : (bool)returnData["isParentOffice"];
                    obj.isBuyer = returnData["isBuyer"] is DBNull ? (bool)false : (bool)returnData["isBuyer"];
                    obj.isChildOffice = returnData["isChildOffice"] is DBNull ? (bool)false : (bool)returnData["isChildOffice"];
                    obj.invoiceStatusId = returnData["invoiceStatusId"] is DBNull ? (int)0 : (int)returnData["invoiceStatusId"];
                    obj.nextInvoiceNumber = returnData["nextInvoiceNumber"] is DBNull ? (int)0 : (int)returnData["nextInvoiceNumber"];
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
