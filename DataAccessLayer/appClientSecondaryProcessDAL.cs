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
   public class appClientSecondaryProcessDAL : SQLDataAccess
    {
        public int InsertAppClientSecondaryProcess(clsAppClientSecondaryProcess obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientSecondaryProcess", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientSecondaryProcess ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppClientSecondaryProcess", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppClientSecondaryProcess(clsAppClientSecondaryProcess obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appClientSecondaryProcess", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appClientSecondaryProcess ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppClientSecondaryProcess", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppClientSecondaryProcess> SelectAllAppClientSecondaryProcess(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppClientSecondaryProcess");

                List<clsAppClientSecondaryProcess> adressList = new List<clsAppClientSecondaryProcess>();
                TExecuteReaderCmd<clsAppClientSecondaryProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientSecondaryProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientSecondaryProcess>();
        }
        public List<clsAppClientSecondaryProcess> SelectAppClientSecondaryProcessById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientSecondaryProcessById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppClientSecondaryProcess> adressList = new List<clsAppClientSecondaryProcess>();
                TExecuteReaderCmd<clsAppClientSecondaryProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientSecondaryProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientSecondaryProcess>();
        }
        public List<clsAppClientSecondaryProcess> SelectAppClientSecondaryProcessByAppId(int appId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientSecondaryProcessByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsAppClientSecondaryProcess> adressList = new List<clsAppClientSecondaryProcess>();
                TExecuteReaderCmd<clsAppClientSecondaryProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientSecondaryProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientSecondaryProcess>();
        }
        public List<clsAppClientSecondaryProcess> SelectAppClientSecondaryProcessByAppIdAndClientSiteId(int appId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppClientSecondaryProcessByAppIdAndClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppClientSecondaryProcess> adressList = new List<clsAppClientSecondaryProcess>();
                TExecuteReaderCmd<clsAppClientSecondaryProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientSecondaryProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientSecondaryProcess>();
        }
        public List<clsAppClientSecondaryProcess> SelectOldAppClientSecondaryProcessByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOldAppClientSecondaryProcessByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppClientSecondaryProcess> adressList = new List<clsAppClientSecondaryProcess>();
                TExecuteReaderCmd<clsAppClientSecondaryProcess>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppClientSecondaryProcess>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppClientSecondaryProcess>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppClientSecondaryProcess> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppClientSecondaryProcess obj = new clsAppClientSecondaryProcess();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.appClientSecondaryProcess = returnData["appClientSecondaryProcess"] is DBNull ? (string)string.Empty : (string)returnData["appClientSecondaryProcess"];
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
        public bool DeleteAppClientSecondaryProcessByAppId(int appId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)appId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAppClientSecondaryProcessByAppId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool SetAppClientSecondaryProcessById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spSetAppClientSecondaryProcessById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
