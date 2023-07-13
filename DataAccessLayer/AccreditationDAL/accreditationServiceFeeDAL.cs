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
   public class accreditationServiceFeeDAL : SQLDataAccess
    {
        public int InsertAccreditationServiceFee(clsAccreditationServiceFee obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.feeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feeAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id=  ExecuteInsertCommandReturnId(comm, "spInsertAccreditationServiceFee", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationServiceFee(clsAccreditationServiceFee obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.feeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@feeAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.feeAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationServiceFee", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationServiceFee> SelectAllAccreditationServiceFee(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationServiceFee");

                List<clsAccreditationServiceFee> activeList = new List<clsAccreditationServiceFee>();
                TExecuteReaderCmd<clsAccreditationServiceFee>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationServiceFee>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationServiceFee>();
        }
        public List<clsAccreditationServiceFee> SelectAccreditationServiceFeeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationServiceFeeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationServiceFee> activeList = new List<clsAccreditationServiceFee>();
                TExecuteReaderCmd<clsAccreditationServiceFee>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationServiceFee>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationServiceFee>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationServiceFee> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationServiceFee obj = new clsAccreditationServiceFee();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.serviceId = returnData["serviceId"] is DBNull ? (int)0 : (int)returnData["serviceId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.feeName = returnData["feeName"] is DBNull ? (string)string.Empty : (string)returnData["feeName"];
                    obj.feeAmount = returnData["feeAmount"] is DBNull ? (decimal)0: (decimal)returnData["feeAmount"];
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
