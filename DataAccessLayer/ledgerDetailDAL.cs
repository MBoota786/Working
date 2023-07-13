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
   public class ledgerDetailDAL : SQLDataAccess
    {
        public int InsertLedgerDetail(clsLedgerDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@ledgerMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.ledgerMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@srNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.srNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@payableId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.payableId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@trTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.trTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@debitAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.debitAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@creditAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.creditAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClient", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClient ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isChildOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isChildOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.feeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@IsFeeId", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.IsFeeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@IsTaxId", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.IsTaxId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@refLedgerMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.refLedgerMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertLedgerDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateLedgerDetail(clsLedgerDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@ledgerMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.ledgerMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@srNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.srNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@payableId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.payableId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@trTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.trTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@debitAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.debitAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@creditAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.creditAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClient", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClient ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isChildOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isChildOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.feeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@IsFeeId", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.IsFeeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@IsTaxId", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.IsTaxId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@refLedgerMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.refLedgerMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateLedgerDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsLedgerDetail> SelectAllLedgerDetail(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllLedgerDetail");
                SetDBName(dbName);
                List<clsLedgerDetail> activeList = new List<clsLedgerDetail>();
                TExecuteReaderCmd<clsLedgerDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLedgerDetail>, ref activeList);
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
        public List<clsLedgerDetail> SelectLedgerDetailById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectLedgerDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsLedgerDetail> activeList = new List<clsLedgerDetail>();
                TExecuteReaderCmd<clsLedgerDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLedgerDetail>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsLedgerDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsLedgerDetail obj = new clsLedgerDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.ledgerMasterId = returnData["ledgerMasterId"] is DBNull ? (int)0 : (int)returnData["ledgerMasterId"];
                    obj.srNo = returnData["srNo"] is DBNull ? (int)0 : (int)returnData["srNo"];
                    obj.payableId = returnData["payableId"] is DBNull ? (int)0 : (int)returnData["payableId"];
                    obj.trTypeId = returnData["trTypeId"] is DBNull ? (int)0 : (int)returnData["trTypeId"];
                    obj.debitAmount = returnData["debitAmount"] is DBNull ? (decimal)0 : (decimal)returnData["debitAmount"];
                    obj.creditAmount = returnData["creditAmount"] is DBNull ? (decimal)0 : (decimal)returnData["creditAmount"];
                    obj.isClient = returnData["isClient"] is DBNull ? (bool)false : (bool)returnData["isClient"];
                    obj.isBuyer = returnData["isBuyer"] is DBNull ? (bool)false : (bool)returnData["isBuyer"];
                    obj.isChildOffice = returnData["isChildOffice"] is DBNull ? (bool)false : (bool)returnData["isChildOffice"];
                    obj.feeId = returnData["feeId"] is DBNull ? (int)0 : (int)returnData["feeId"];
                    obj.IsFeeId = returnData["IsFeeId"] is DBNull ? (bool)true : (bool)returnData["IsFeeId"];
                    obj.IsTaxId = returnData["IsTaxId"] is DBNull ? (bool)true : (bool)returnData["IsTaxId"];
                    obj.refLedgerMasterId = returnData["refLedgerMasterId"] is DBNull ? (int)0 : (int)returnData["refLedgerMasterId"];
                   
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
