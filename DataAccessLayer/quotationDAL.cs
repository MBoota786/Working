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
   public class quotationDAL : SQLDataAccess
    {
        public int InsertQuotation(clsQuotation obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.quotationDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationValidityUpto", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.quotationValidityUpto ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentByUserId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationSentByUserId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationVersionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationVersionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationSentTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertQuotation", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateQuotation(clsQuotation obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.quotationDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationValidityUpto", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.quotationValidityUpto ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentByUserId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationSentByUserId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationVersionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationVersionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationSentTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateQuotation", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsQuotation> SelectAllQuotation(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllQuotation");
                SetDBName(dbName);
                List<clsQuotation> activeList = new List<clsQuotation>();
                TExecuteReaderCmd<clsQuotation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotation>, ref activeList);
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
        public List<clsQuotation> SelectQuotationById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuotationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsQuotation> activeList = new List<clsQuotation>();
                TExecuteReaderCmd<clsQuotation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuotation>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsQuotation> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsQuotation obj = new clsQuotation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.quotationStatusId = returnData["quotationStatusId"] is DBNull ? (int)0 : (int)returnData["quotationStatusId"];
                    obj.quotationDate = returnData["quotationDate"] is DBNull ? (DateTime?)null: (DateTime)returnData["quotationDate"];
                    obj.quotationValidityUpto = returnData["quotationValidityUpto"] is DBNull ? (DateTime?)null : (DateTime)returnData["quotationValidityUpto"];
                    obj.quotationSentByUserId = returnData["quotationSentByUserId"] is DBNull ? (int)0 : (int)returnData["quotationSentByUserId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.quotationVersionId = returnData["quotationVersionId"] is DBNull ? (int)0 : (int)returnData["quotationVersionId"];
                    obj.quotationNo = returnData["quotationNo"] is DBNull ? (int)0 : (int)returnData["quotationNo"];
                    obj.quotationSentTo = returnData["quotationSentTo"] is DBNull ? (int)0 : (int)returnData["quotationSentTo"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
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
