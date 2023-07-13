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
   public class clientAppAuditCAPDAL : SQLDataAccess
    {
        public int InsertClientAppAuditCAP(clsClientAppAuditCAP at)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAppAuditNcsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.clientAppAuditNcsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@capCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.capCategory ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAppAuditCAP", at.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAppAuditCAP(clsClientAppAuditCAP at)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientAppAuditNcsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.clientAppAuditNcsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@capCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.capCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAppAuditCAP", at.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAppAuditCAP> SelectAllClientAppAuditCAP(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAppAuditCAP");

                List<clsClientAppAuditCAP> activeList = new List<clsClientAppAuditCAP>();
                TExecuteReaderCmd<clsClientAppAuditCAP>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditCAP>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsClientAppAuditCAP> SelectClientAppAuditCAPById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAppAuditCAPById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAppAuditCAP> activeList = new List<clsClientAppAuditCAP>();
                TExecuteReaderCmd<clsClientAppAuditCAP>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditCAP>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAppAuditCAP> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAppAuditCAP obj = new clsClientAppAuditCAP();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientAppAuditNcsId = returnData["clientAppAuditNcsId"] is DBNull ? (int)0 : (int)returnData["clientAppAuditNcsId"];
                    obj.capCategory = returnData["capCategory"] is DBNull ? (string)string.Empty : (string)returnData["capCategory"];
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
