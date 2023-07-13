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
   public class clientBusinessTypeDAL : SQLDataAccess
    {
        public int InsertClientBusinessType(clsClientBusinessType obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientBusinessTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientBusinessTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientBusinessType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientBusinessType(clsClientBusinessType obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientBusinessTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.clientBusinessTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientBusinessType", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientBusinessType> SelectAllClientBusinessType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientBusinessType");

                List<clsClientBusinessType> adressList = new List<clsClientBusinessType>();
                TExecuteReaderCmd<clsClientBusinessType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientBusinessType>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientBusinessType>();
        }
        public List<clsClientBusinessType> SelectClientBusinessTypeById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientBusinessTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientBusinessType> adressList = new List<clsClientBusinessType>();
                TExecuteReaderCmd<clsClientBusinessType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientBusinessType>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientBusinessType>();
        }  
        public List<clsClientBusinessType> SelectClientBusinessTypeByName(string clientBusinessTypeName, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientBusinessTypeByName");
                comand.Parameters.AddWithValue("@clientBusinessTypeName", clientBusinessTypeName);
                List<clsClientBusinessType> adressList = new List<clsClientBusinessType>();
                TExecuteReaderCmd<clsClientBusinessType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientBusinessType>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientBusinessType>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientBusinessType> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientBusinessType obj = new clsClientBusinessType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientBusinessTypeName = returnData["clientBusinessTypeName"] is DBNull ? (string)string.Empty : (string)returnData["clientBusinessTypeName"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsExistClientBusinessType(string clientBusinessTypeName, string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@clientBusinessTypeName", clientBusinessTypeName);
                return IsRecordExistCheck(cmd, "spIsExistClientBusinessType", dbName);
            }
        }
    }
}
