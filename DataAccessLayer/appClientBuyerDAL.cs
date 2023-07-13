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
   public class appClientBuyerDAL : SQLDataAccess
    {
        public int InsertAppClientBuyer(clsAppClientBuyer obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientBuyer", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientBuyer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppClientBuyer", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppClientBuyer(clsAppClientBuyer obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientBuyer", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientBuyer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppClientBuyer", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppClientBuyer> SelectAllAppClientBuyer(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppClientBuyer");

                List<clsAppClientBuyer> adressList = new List<clsAppClientBuyer>();
                TExecuteReaderCmd<clsAppClientBuyer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBuyer>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBuyer>();
        }
        public List<clsAppClientBuyer> SelectAppClientBuyerById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientBuyerById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppClientBuyer> adressList = new List<clsAppClientBuyer>();
                TExecuteReaderCmd<clsAppClientBuyer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBuyer>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBuyer>();
        }
        public List<clsAppClientBuyer> SelectAppClientBuyerByAppId(int appId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientBuyerByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsAppClientBuyer> adressList = new List<clsAppClientBuyer>();
                TExecuteReaderCmd<clsAppClientBuyer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBuyer>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBuyer>();
        } 
        public List<clsAppClientBuyer> SelectAppClientBuyerByAppIdAndClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientBuyerByAppIdAndClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppClientBuyer> adressList = new List<clsAppClientBuyer>();
                TExecuteReaderCmd<clsAppClientBuyer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBuyer>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBuyer>();
        }
        public List<clsAppClientBuyer> SelectOldAppClientBuyerByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOldAppClientBuyerByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppClientBuyer> adressList = new List<clsAppClientBuyer>();
                TExecuteReaderCmd<clsAppClientBuyer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientBuyer>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientBuyer>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppClientBuyer> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppClientBuyer obj = new clsAppClientBuyer();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.appClientBuyer = returnData["appClientBuyer"] is DBNull ? (string)string.Empty : (string)returnData["appClientBuyer"];
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
        public bool DeleteAppClientBuyerByAppId(int appId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)appId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAppClientBuyerByAppId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }   
        public bool SetAppClientBuyerActiveFalseById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spSetAppClientBuyerActiveFalseById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
