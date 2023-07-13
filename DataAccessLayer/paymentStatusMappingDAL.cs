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
   public class paymentStatusMappingDAL : SQLDataAccess
    {
        public int InsertPaymentStatusMapping(clsPaymentStatusMapping obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentStatusTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentStatusTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertPaymentStatusMapping", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdatePaymentStatusMapping(clsPaymentStatusMapping obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentStatusTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentStatusTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdatePaymentStatusMapping", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsPaymentStatusMapping> SelectAllPaymentStatusMapping(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllPaymentStatusMapping");

                List<clsPaymentStatusMapping> activeList = new List<clsPaymentStatusMapping>();
                TExecuteReaderCmd<clsPaymentStatusMapping>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPaymentStatusMapping>, ref activeList);
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
        public List<clsPaymentStatusMapping> SelectPaymentStatusMappingById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectPaymentStatusMappingById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsPaymentStatusMapping> activeList = new List<clsPaymentStatusMapping>();
                TExecuteReaderCmd<clsPaymentStatusMapping>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsPaymentStatusMapping>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsPaymentStatusMapping> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsPaymentStatusMapping obj = new clsPaymentStatusMapping();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.paymentStatusTypeId = returnData["paymentStatusTypeId"] is DBNull ? (int)0 : (int)returnData["paymentStatusTypeId"];
                    obj.paymentStatusId = returnData["paymentStatusId"] is DBNull ? (int)0 : (int)returnData["paymentStatusId"];
                    obj.paymentStatusType = returnData["paymentStatusType"] is DBNull ? (string)string.Empty : (string)returnData["paymentStatusType"];
                    obj.paymentStatus = returnData["paymentStatus"] is DBNull ? (string)string.Empty : (string)returnData["paymentStatus"];
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
