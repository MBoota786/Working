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
   public class auditPreRequisitesDetailDAL : SQLDataAccess
    {
        public int InsertAuditPreRequisitesDetail(clsAuditPreRequisitesDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditPreRequisitesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesVersionNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.auditPreRequisitesVersionNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.auditPreRequisitesSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.auditPreRequisitesPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditPreRequisitesDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditPreRequisitesDetail(clsAuditPreRequisitesDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditPreRequisitesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesVersionNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.auditPreRequisitesVersionNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.auditPreRequisitesSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditPreRequisitesPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.auditPreRequisitesPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditPreRequisitesDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditPreRequisitesDetail> SelectAllAuditPreRequisitesDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditPreRequisitesDetail");

                List<clsAuditPreRequisitesDetail> adressList = new List<clsAuditPreRequisitesDetail>();
                TExecuteReaderCmd<clsAuditPreRequisitesDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditPreRequisitesDetail>, ref adressList);
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
        public List<clsAuditPreRequisitesDetail> SelectAuditPreRequisitesDetailById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditPreRequisitesDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditPreRequisitesDetail> adressList = new List<clsAuditPreRequisitesDetail>();
                TExecuteReaderCmd<clsAuditPreRequisitesDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditPreRequisitesDetail>, ref adressList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditPreRequisitesDetail> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditPreRequisitesDetail obj = new clsAuditPreRequisitesDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.auditPreRequisitesId = returnData["auditPreRequisitesId"] is DBNull ? (int)0 : (int)returnData["auditPreRequisitesId"];
                    obj.auditPreRequisitesVersionNo = returnData["auditPreRequisitesVersionNo"] is DBNull ? (string)string.Empty : (string)returnData["auditPreRequisitesVersionNo"];
                    obj.auditPreRequisitesSrNo = returnData["auditPreRequisitesSrNo"] is DBNull ? (string)string.Empty : (string)returnData["auditPreRequisitesSrNo"];
                    obj.auditPreRequisitesPath = returnData["auditPreRequisitesPath"] is DBNull ? (string)string.Empty : (string)returnData["auditPreRequisitesPath"];
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
