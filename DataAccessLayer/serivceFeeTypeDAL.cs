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
   public class serivceFeeTypeDAL : SQLDataAccess
    {
        public int InsertServiceFeeType(clsServiceFeeType obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceFeeTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertServiceFeeType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateServiceFeeType(clsServiceFeeType obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceFeeTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceFeeTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateServiceFeeType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsServiceFeeType> SelectAllServiceFeeType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllServiceFeeType");

                List<clsServiceFeeType> activeList = new List<clsServiceFeeType>();
                TExecuteReaderCmd<clsServiceFeeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsServiceFeeType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsServiceFeeType>();
        }
        public List<clsServiceFeeType> SelectServiceFeeTypeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectServiceFeeTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsServiceFeeType> activeList = new List<clsServiceFeeType>();
                TExecuteReaderCmd<clsServiceFeeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsServiceFeeType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsServiceFeeType>();
        } 
        public List<clsServiceFeeType> SelectServiceFeeTypeByServiceTypeId(int serviceTypeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectServiceFeeTypeByServiceTypeId");
                comand.Parameters.AddWithValue("@serviceTypeId", serviceTypeId);
                List<clsServiceFeeType> activeList = new List<clsServiceFeeType>();
                TExecuteReaderCmd<clsServiceFeeType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsServiceFeeType>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsServiceFeeType>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsServiceFeeType> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsServiceFeeType obj = new clsServiceFeeType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    if (ColumnExists(returnData,"serviceTypeId"))
                    {
                        obj.serviceTypeId = returnData["serviceTypeId"] is DBNull ? (int)0 : (int)returnData["serviceTypeId"];
                    }
                    obj.serviceFeeTypeName = returnData["serviceFeeTypeName"] is DBNull ? (string)string.Empty : (string)returnData["serviceFeeTypeName"];
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
