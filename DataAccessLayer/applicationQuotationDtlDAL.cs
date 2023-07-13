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
   public class applicationQuotationDtlDAL : SQLDataAccess
    {
        public int InsertApplicationQuotationDtl(clsApplicationQuotationDtl obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationQuotationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationQuotationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertApplicationQuotationDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateApplicationQuotationDtl(clsApplicationQuotationDtl obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationQuotationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationQuotationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateApplicationQuotationDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsApplicationQuotationDtl> SelectAllApplicationQuotationDtl(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllApplicationQuotationDtl");

                List<clsApplicationQuotationDtl> adressList = new List<clsApplicationQuotationDtl>();
                TExecuteReaderCmd<clsApplicationQuotationDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationQuotationDtl>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationQuotationDtl>();
        }
        public List<clsApplicationQuotationDtl> SelectApplicationQuotationDtlById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationQuotationDtlById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsApplicationQuotationDtl> adressList = new List<clsApplicationQuotationDtl>();
                TExecuteReaderCmd<clsApplicationQuotationDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationQuotationDtl>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationQuotationDtl>();
        }
        public List<clsApplicationQuotationDtl> SelectApplicationQuotationDtlByApplicationQuotationId(int applicationQuotationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationQuotationDtlByApplicationQuotationId");
                comand.Parameters.AddWithValue("@applicationQuotationId", applicationQuotationId);
                List<clsApplicationQuotationDtl> adressList = new List<clsApplicationQuotationDtl>();
                TExecuteReaderCmd<clsApplicationQuotationDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationQuotationDtl>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationQuotationDtl>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsApplicationQuotationDtl> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsApplicationQuotationDtl obj = new clsApplicationQuotationDtl();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.applicationQuotationId = returnData["applicationQuotationId"] is DBNull ? (int)0 : (int)returnData["applicationQuotationId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
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
