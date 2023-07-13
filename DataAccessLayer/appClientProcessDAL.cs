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
   public class appClientProcessDAL : SQLDataAccess
    {
        public int InsertAppClientProcess(clsAppClientProcess obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientProcess", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientProcess ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppClientProcess", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppClientProcess(clsAppClientProcess obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientProcess", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientProcess ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appClientProcess ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppClientProcess", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppClientProcess> SelectAllAppClientProcess(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppClientProcess");

                List<clsAppClientProcess> adressList = new List<clsAppClientProcess>();
                TExecuteReaderCmd<clsAppClientProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientProcess>();
        }
        public List<clsAppClientProcess> SelectAppClientProcessById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientProcessById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppClientProcess> adressList = new List<clsAppClientProcess>();
                TExecuteReaderCmd<clsAppClientProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientProcess>();
        }
        public List<clsAppClientProcess> SelectAppClientProcessByAppId(int appId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientProcessByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsAppClientProcess> adressList = new List<clsAppClientProcess>();
                TExecuteReaderCmd<clsAppClientProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientProcess>();
        }
        public List<clsAppClientProcess> SelectAppClientProcessByAppIdClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientProcessByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppClientProcess> adressList = new List<clsAppClientProcess>();
                TExecuteReaderCmd<clsAppClientProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientProcess>();
        }  
        public List<clsAppClientProcess> SelectOldAppClientProcessByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOldAppClientProcessByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppClientProcess> adressList = new List<clsAppClientProcess>();
                TExecuteReaderCmd<clsAppClientProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientProcess>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppClientProcess> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppClientProcess obj = new clsAppClientProcess();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.appClientProcess = returnData["appClientProcess"] is DBNull ? (string)string.Empty : (string)returnData["appClientProcess"];
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
        public bool DeleteAppClientProcessByAppId(int appId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)appId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAppClientProcessByAppId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool SetAppClientProcessActiveFalseById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spSetAppClientProcessActiveFalseById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
