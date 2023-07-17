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
  public  class businessTypeDAL : SQLDataAccess
    {
        public int InsertBusinessType(clsBusinessType ls)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.businessTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertBusinessType", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public bool UpdateBusinessType(clsBusinessType ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ls.businessTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateBusinessType", ls.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsBusinessType> SelectAllBusinessType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllBusinessType");

                List<clsBusinessType> businessTypeList = new List<clsBusinessType>();
                TExecuteReaderCmd<clsBusinessType>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsBusinessType>, ref businessTypeList);
                if (businessTypeList != null)
                {
                    return businessTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsBusinessType>();
        }
        public List<clsBusinessType> SelectBusinessTypeById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBusinessTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsBusinessType> businessTypeList = new List<clsBusinessType>();
                TExecuteReaderCmd<clsBusinessType>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsBusinessType>, ref businessTypeList);
                if (businessTypeList != null)
                {
                    return businessTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsBusinessType>();
        }
        public List<clsBusinessType> SelectBusinessTypeByName(string businessTypeName, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBusinessTypeByName");
                comand.Parameters.AddWithValue("@businessTypeName", businessTypeName);
                List<clsBusinessType> businessTypeList = new List<clsBusinessType>();
                TExecuteReaderCmd<clsBusinessType>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsBusinessType>, ref businessTypeList);
                if (businessTypeList != null)
                {
                    return businessTypeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsBusinessType>();
        }
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsBusinessType> activeLegalStatus)
        {
            try
            {
                while (returnData.Read())
                {
                    clsBusinessType obj = new clsBusinessType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.businessTypeName = returnData["businessTypeName"] is DBNull ? (string)string.Empty : (string)returnData["businessTypeName"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeLegalStatus.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsBusinessTypeExist(string businessTypeName,string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@businessTypeName", businessTypeName);
                return IsRecordExistCheck(cmd, "spIsBusinessTypeExist", dbName);
            }
        }

    }
}
