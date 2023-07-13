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
   public class clientAppAuditNcsDAL : SQLDataAccess
    {
        public int InsertClientAppAuditNcs(clsClientAppAuditNcs at)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientApplicationAuditId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.clientApplicationAuditId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@ncCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.ncCategory ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientAppAuditNcs", at.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientAppAuditNcs(clsClientAppAuditNcs at)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientApplicationAuditId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.clientApplicationAuditId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@ncCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)at.ncCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientAppAuditNcs", at.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsClientAppAuditNcs> SelectAllClientAppAuditNcs(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientAppAuditNcs");

                List<clsClientAppAuditNcs> activeList = new List<clsClientAppAuditNcs>();
                TExecuteReaderCmd<clsClientAppAuditNcs>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditNcs>, ref activeList);
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
        public List<clsClientAppAuditNcs> SelectClientAppAuditNcsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientAppAuditNcsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientAppAuditNcs> activeList = new List<clsClientAppAuditNcs>();
                TExecuteReaderCmd<clsClientAppAuditNcs>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientAppAuditNcs>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientAppAuditNcs> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientAppAuditNcs obj = new clsClientAppAuditNcs();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientApplicationAuditId = returnData["clientApplicationAuditId"] is DBNull ? (int)0 : (int)returnData["clientApplicationAuditId"];
                    obj.ncCategory = returnData["ncCategory"] is DBNull ? (string)string.Empty : (string)returnData["ncCategory"];
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
