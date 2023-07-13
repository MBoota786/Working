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
   public class quotationPaymentStatusDAL : SQLDataAccess
    {
        public int InsertQuotationPaymentStatus(clsQuotationPaymentStatus obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationPaymentStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.quotationPaymentStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertQuotationPaymentStatus", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateQuotationPaymentStatus(clsQuotationPaymentStatus obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationPaymentStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.quotationPaymentStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateQuotationPaymentStatus", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsQuotationPaymentStatus> SelectAllQuotationPaymentStatus(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllQuotationPaymentStatus");
          
                List<clsQuotationPaymentStatus> activeList = new List<clsQuotationPaymentStatus>();
                TExecuteReaderCmd<clsQuotationPaymentStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotationPaymentStatus>, ref activeList);
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
        public List<clsQuotationPaymentStatus> SelectQuotationPaymentStatusById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuotationPaymentStatusById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsQuotationPaymentStatus> activeList = new List<clsQuotationPaymentStatus>();
                TExecuteReaderCmd<clsQuotationPaymentStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotationPaymentStatus>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsQuotationPaymentStatus> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsQuotationPaymentStatus obj = new clsQuotationPaymentStatus();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.quotationPaymentStatus = returnData["quotationPaymentStatus"] is DBNull ? (string)string.Empty : (string)returnData["quotationPaymentStatus"];
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
