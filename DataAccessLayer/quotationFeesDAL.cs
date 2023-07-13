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
   public class quotationFeesDAL : SQLDataAccess
    {
        public int InsertQuoatationFees(clsQuotationFees obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertQuoatationFees", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateQuoatationFees(clsQuotationFees obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateQuoatationFees", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsQuotationFees> SelectAllQuotationFees(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllQuotationFees");

                List<clsQuotationFees> activeList = new List<clsQuotationFees>();
                TExecuteReaderCmd<clsQuotationFees>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotationFees>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsQuotationFees>();
        }
        public List<clsQuotationFees> SelectQuotationFeesByQuotationId(int quotationId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuotationFeesByQuotationId");
                comand.Parameters.AddWithValue("@quotationId", quotationId);
                List<clsQuotationFees> activeList = new List<clsQuotationFees>();
                TExecuteReaderCmd<clsQuotationFees>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotationFees>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsQuotationFees>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsQuotationFees> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsQuotationFees obj = new clsQuotationFees();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.quotationId = returnData["quotationId"] is DBNull ? (int)0 : (int)returnData["quotationId"];
                    obj.quotationTypeId = returnData["quotationTypeId"] is DBNull ? (int)0 : (int)returnData["quotationTypeId"];
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
