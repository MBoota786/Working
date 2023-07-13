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
   public class auditDeliverableDocumentDAL : SQLDataAccess
    {
        public int InsertAuditDeliverableDocument(clsAuditDeliverableDocument obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@deliverableDocName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.deliverableDocName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDocUploadRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDocUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@deliverableTemplatePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.deliverableTemplatePath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isCertificate", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCertificate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
              Id=  ExecuteInsertCommandReturnId(comm, "spInsertAuditDeliverableDocument", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditDeliverableDocument(clsAuditDeliverableDocument obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@deliverableDocName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.deliverableDocName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isDocUploadRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isDocUploadRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@deliverableTemplatePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.deliverableTemplatePath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isCertificate", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCertificate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditDeliverableDocument", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditDeliverableDocument> SelectAllAuditDeliverableDocument(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditDeliverableDocument");
               
                List<clsAuditDeliverableDocument> adressList = new List<clsAuditDeliverableDocument>();
                TExecuteReaderCmd<clsAuditDeliverableDocument>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditDeliverableDocument>, ref adressList);
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
        public List<clsAuditDeliverableDocument> SelectAuditDeliverableDocumentById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditDeliverableDocumentById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditDeliverableDocument> adressList = new List<clsAuditDeliverableDocument>();
                TExecuteReaderCmd<clsAuditDeliverableDocument>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditDeliverableDocument>, ref adressList);
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
        public List<clsAuditDeliverableDocument> SelectAuditDeliverableDocumentByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditDeliverableDocumentByAccreditationStandardId");
                comand.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                List<clsAuditDeliverableDocument> adressList = new List<clsAuditDeliverableDocument>();
                TExecuteReaderCmd<clsAuditDeliverableDocument>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditDeliverableDocument>, ref adressList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditDeliverableDocument> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditDeliverableDocument obj = new clsAuditDeliverableDocument();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.deliverableDocName = returnData["deliverableDocName"] is DBNull ? (string)string.Empty : (string)returnData["deliverableDocName"];
                    obj.isDocUploadRequired = returnData["isDocUploadRequired"] is DBNull ? (bool)true : (bool)returnData["isDocUploadRequired"];
                    obj.deliverableTemplatePath = returnData["deliverableTemplatePath"] is DBNull ? (string) string.Empty : (string)returnData["deliverableTemplatePath"];
                    obj.isCertificate = returnData["isCertificate"] is DBNull ? (bool)true : (bool)returnData["isCertificate"];
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
