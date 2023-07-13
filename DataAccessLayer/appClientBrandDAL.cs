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
   public class appClientBrandDAL : SQLDataAccess
    {
        public int InsertAppClientBrand(clsAppClientBrand obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientBrand", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientBrand ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppClientBrand", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppClientBrand(clsAppClientBrand obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientBrand", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientBrand ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppClientBrand", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppClientBrand> SelectAllAppClientBrand(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppClientBrand");

                List<clsAppClientBrand> adressList = new List<clsAppClientBrand>();
                TExecuteReaderCmd<clsAppClientBrand>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBrand>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBrand>();
        }
        public List<clsAppClientBrand> SelectAppClientBrandById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientBrandById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppClientBrand> adressList = new List<clsAppClientBrand>();
                TExecuteReaderCmd<clsAppClientBrand>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBrand>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBrand>();
        }
        public List<clsAppClientBrand> SelectAppClientBrandByAppId(int appId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientBrandByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsAppClientBrand> adressList = new List<clsAppClientBrand>();
                TExecuteReaderCmd<clsAppClientBrand>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBrand>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBrand>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppClientBrand> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppClientBrand obj = new clsAppClientBrand();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.appClientBrand = returnData["appClientBrand"] is DBNull ? (string)string.Empty : (string)returnData["appClientBrand"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
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
