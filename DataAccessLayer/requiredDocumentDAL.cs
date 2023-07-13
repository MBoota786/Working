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
  public  class requiredDocumentDAL : SQLDataAccess
    {
        public int InsertRequiredDocuments(clsRequiredDocuments ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reqDocumentName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.reqDocumentName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.documentTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@categoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.categoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isForOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForUser", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isForUser ?? DBNull.Value);
              
              Id =  ExecuteInsertCommandReturnId(comm, "spInsertRequiredDocuments", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateRequiredDocuments(clsRequiredDocuments ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reqDocumentName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.reqDocumentName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.documentTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@categoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.categoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isRequired", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isRequired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isForOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForUser", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isForUser ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateRequiredDocuments", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsRequiredDocuments> SelectAllRequiredDocuments(string  dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllRequiredDocuments");

                List<clsRequiredDocuments> docList = new List<clsRequiredDocuments>();
                TExecuteReaderCmd<clsRequiredDocuments>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRequiredDocuments>, ref docList);
                if (docList != null)
                {
                    return docList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRequiredDocuments>();
        }
        public List<clsRequiredDocuments> SelectRequiredDocumentsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectRequiredDocumentsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsRequiredDocuments> docList = new List<clsRequiredDocuments>();
                TExecuteReaderCmd<clsRequiredDocuments>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsRequiredDocuments>, ref docList);
                if (docList != null)
                {
                    return docList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsRequiredDocuments>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsRequiredDocuments> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsRequiredDocuments obj = new clsRequiredDocuments();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.documentTypeId = returnData["documentTypeId"] is DBNull ? (int)0 : (int)returnData["documentTypeId"];
                    obj.categoryRelationId = returnData["categoryRelationId"] is DBNull ? (int)0 : (int)returnData["categoryRelationId"];
                    obj.reqDocumentName = returnData["reqDocumentName"] is DBNull ? (string)string.Empty : (string)returnData["reqDocumentName"];
                    obj.isRequired = returnData["isRequired"] is DBNull ? (bool)true : (bool)returnData["isRequired"];
                    obj.isForOffice = returnData["isForOffice"] is DBNull ? (bool)true : (bool)returnData["isForOffice"];
                    obj.isForUser = returnData["isForUser"] is DBNull ? (bool)true : (bool)returnData["isForUser"];
                 
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
