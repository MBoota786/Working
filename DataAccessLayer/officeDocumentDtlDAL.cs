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
  public  class officeDocumentDtlDAL : SQLDataAccess
    {
        public int InsertOfficeDocumentDtl(clsOfficeDocumentDtl ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeDocumentMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeDocumentMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExpiry", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isExpiry ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@expiryDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.expiryDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.documentSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.documentPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.documentDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.documentFileName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id =  ExecuteInsertCommandReturnId(comm, "spInsertOfficeDocumentDtl", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeDocumentDtl(clsOfficeDocumentDtl ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeDocumentMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeDocumentMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExpiry", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isExpiry ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@expiryDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.expiryDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentSrNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.documentSrNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.documentPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.documentDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.documentFileName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeDocumentDtl", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateDocumentPathByDocumentDtlId(clsOfficeDocumentDtl ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeDocumentMasterId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeDocumentMasterId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.documentPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentFileName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.documentFileName ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateDocumentPathByDocumentDtlId", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeDocumentDtl> SelectAllOfficeDocumentDtl()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeDocumentDtl");

                List<clsOfficeDocumentDtl> docList = new List<clsOfficeDocumentDtl>();
                TExecuteReaderCmd<clsOfficeDocumentDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeDocumentDtl>, ref docList);
                if (docList != null)
                {
                    return docList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsOfficeDocumentDtl> SelectOfficeDocumentDtlById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeDocumentDtlById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeDocumentDtl> docList = new List<clsOfficeDocumentDtl>();
                TExecuteReaderCmd<clsOfficeDocumentDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeDocumentDtl>, ref docList);
                if (docList != null)
                {
                    return docList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeDocumentDtl> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeDocumentDtl obj = new clsOfficeDocumentDtl();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeDocumentMasterId = returnData["officeDocumentMasterId"] is DBNull ? (int)0 : (int)returnData["officeDocumentMasterId"];  
                    obj.isExpiry = returnData["isExpiry"] is DBNull ? (bool)true : (bool)returnData["isExpiry"];
                    obj.expiryDate = returnData["expiryDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["expiryDate"];
                    obj.documentSrNo = returnData["documentSrNo"] is DBNull ? (string)string.Empty : (string)returnData["documentSrNo"];
                    obj.documentPath = returnData["documentPath"] is DBNull ? (string)string.Empty : (string)returnData["documentPath"];
                    obj.documentFileName = returnData["documentFileName"] is DBNull ? (string)string.Empty : (string)returnData["documentFileName"];
                    obj.documentDate = returnData["documentDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["documentDate"];

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
