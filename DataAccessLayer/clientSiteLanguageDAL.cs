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
   public class clientSiteLanguageDAL : SQLDataAccess
    {
        public int InsertClientSiteLanguage(clsClientSiteLanguage obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteLanguageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteLanguageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@percentSpoken", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.percentSpoken ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientSiteLanguage", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientSiteLanguage(clsClientSiteLanguage obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteLanguageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.siteLanguageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@percentSpoken", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.percentSpoken ?? DBNull.Value); 
                AddParamToSQLCmd(comm, "@employeeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeeTypeId ?? DBNull.Value); 
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientSiteLanguage", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientSiteLanguage> SelectAllClientSiteLanguage(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientSiteLanguage");

                List<clsClientSiteLanguage> activeList = new List<clsClientSiteLanguage>();
                TExecuteReaderCmd<clsClientSiteLanguage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteLanguage>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteLanguage>();
        }
        public List<clsClientSiteLanguage> SelectClientSiteLanguageById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteLanguageById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientSiteLanguage> activeList = new List<clsClientSiteLanguage>();
                TExecuteReaderCmd<clsClientSiteLanguage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteLanguage>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteLanguage>();
        }    
        public List<clsClientSiteLanguage> SelectClientSiteLanguageByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteLanguageByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsClientSiteLanguage> activeList = new List<clsClientSiteLanguage>();
                TExecuteReaderCmd<clsClientSiteLanguage>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteLanguage>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteLanguage>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientSiteLanguage> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientSiteLanguage obj = new clsClientSiteLanguage();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.siteLanguageId = returnData["siteLanguageId"] is DBNull ? (int)0 : (int)returnData["siteLanguageId"];
                    obj.percentSpoken = returnData["percentSpoken"] is DBNull ? (decimal) 0 : (decimal)returnData["percentSpoken"];
                    obj.employeeTypeId = returnData["employeeTypeId"] is DBNull ? (int) 0 : (int)returnData["employeeTypeId"];
                    if (ColumnExists(returnData, "siteLanguage"))
                    {
                        obj.siteLanguage = returnData["siteLanguage"] is DBNull ? (string) string.Empty : (string)returnData["siteLanguage"];
                    }
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
