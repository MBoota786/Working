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
   public class adressTypeDAL : SQLDataAccess
    {
        public int InsertAdressType(clsAdressType at)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@addressTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.addressTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAdressType", at.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAdressType(clsAdressType at)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@addressTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.addressTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAdressType", at.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAdressType> SelectAllAdressType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAdressType");

                List<clsAdressType> adressList = new List<clsAdressType>();
                TExecuteReaderCmd<clsAdressType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsAdressType> SelectAdressTypeById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAdressTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAdressType> adressList = new List<clsAdressType>();
                TExecuteReaderCmd<clsAdressType>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAdressType> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAdressType obj = new clsAdressType();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.addressTypeName = returnData["addressTypeName"] is DBNull ? (string)string.Empty : (string)returnData["addressTypeName"];
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
    }
}
