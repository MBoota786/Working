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
   public class auditApplicationReviewPointStatusDAL : SQLDataAccess
    {
        public int spInsertAuditApplicationReviewPointStatus(clsAuditApplicationReviewPointStatus obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPointStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.reviewPointStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditApplicationReviewPointStatus", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditApplicationReviewPointStatus(clsAuditApplicationReviewPointStatus obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPointStatus", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.reviewPointStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditApplicationReviewPointStatus", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditApplicationReviewPointStatus> SelectAllAuditApplicationReviewPointStatus(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditApplicationReviewPointStatus");

                List<clsAuditApplicationReviewPointStatus> adressList = new List<clsAuditApplicationReviewPointStatus>();
                TExecuteReaderCmd<clsAuditApplicationReviewPointStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditApplicationReviewPointStatus>, ref adressList);
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
        public List<clsAuditApplicationReviewPointStatus> SelectAuditApplicationReviewPointStatusById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditApplicationReviewPointStatusById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditApplicationReviewPointStatus> adressList = new List<clsAuditApplicationReviewPointStatus>();
                TExecuteReaderCmd<clsAuditApplicationReviewPointStatus>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditApplicationReviewPointStatus>, ref adressList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditApplicationReviewPointStatus> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditApplicationReviewPointStatus obj = new clsAuditApplicationReviewPointStatus();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.reviewPointStatus = returnData["reviewPointStatus"] is DBNull ? (string)string.Empty : (string)returnData["reviewPointStatus"];
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
