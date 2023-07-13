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
   public class auditRequiredDocDetailDAL : SQLDataAccess
    {
        public int InsertAuditRequiredDocDetail(clsAuditRequiredDocDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditRequiredDocId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditRequiredDocId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocVersionNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.requiredDocVersionNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.requiredDocSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.requiredDocPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditRequiredDocDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditRequiredDocDetail(clsAuditRequiredDocDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditRequiredDocId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditRequiredDocId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocVersionNo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.requiredDocVersionNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.requiredDocSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.requiredDocPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditRequiredDocDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditRequiredDocDetail> SelectAllAuditRequiredDocDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditRequiredDocDetail");

                List<clsAuditRequiredDocDetail> adressList = new List<clsAuditRequiredDocDetail>();
                TExecuteReaderCmd<clsAuditRequiredDocDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditRequiredDocDetail>, ref adressList);
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
        public List<clsAuditRequiredDocDetail> SelectAuditRequiredDocDetailById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditRequiredDocDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditRequiredDocDetail> adressList = new List<clsAuditRequiredDocDetail>();
                TExecuteReaderCmd<clsAuditRequiredDocDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditRequiredDocDetail>, ref adressList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditRequiredDocDetail> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditRequiredDocDetail obj = new clsAuditRequiredDocDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.auditRequiredDocId = returnData["auditRequiredDocId"] is DBNull ? (int)0 : (int)returnData["auditRequiredDocId"];
                    obj.requiredDocVersionNo = returnData["requiredDocVersionNo"] is DBNull ? (int)0 : (int)returnData["requiredDocVersionNo"];
                    obj.requiredDocSrNo = returnData["requiredDocSrNo"] is DBNull ? (string)string.Empty : (string)returnData["requiredDocSrNo"];
                    obj.requiredDocPath = returnData["requiredDocPath"] is DBNull ? (string)string.Empty : (string)returnData["requiredDocPath"];
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
