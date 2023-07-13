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
   public class modeOfPaymentDAL : SQLDataAccess
    {
        public int InsertModeOfPayment(clsModeOfPayment obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modeOfPaymentName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.modeOfPaymentName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertModeOfPayment", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateModeOfPayment(clsModeOfPayment obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modeOfPaymentName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.modeOfPaymentName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateModeOfPayment", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsModeOfPayment> SelectAllModeOfPayment(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllModeOfPayment");

                List<clsModeOfPayment> activeList = new List<clsModeOfPayment>();
                TExecuteReaderCmd<clsModeOfPayment>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsModeOfPayment>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsModeOfPayment>();
        }
        public List<clsModeOfPayment> SelectModeOfPaymentById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectModeOfPaymentById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsModeOfPayment> activeList = new List<clsModeOfPayment>();
                TExecuteReaderCmd<clsModeOfPayment>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsModeOfPayment>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsModeOfPayment>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsModeOfPayment> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsModeOfPayment obj = new clsModeOfPayment();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.modeOfPaymentName = returnData["modeOfPaymentName"] is DBNull ? (string)string.Empty : (string)returnData["modeOfPaymentName"];
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
