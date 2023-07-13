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
   public class appReviewerCommentsDAL : SQLDataAccess
    {
        public int InsertAppReviewerComments(clsAppReviewerComments obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationReviewId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationReviewId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditApplicationReviewPointId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditApplicationReviewPointId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPointComment", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.reviewPointComment ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPointStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewPointStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppReviewerComments", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppReviewerComments(clsAppReviewerComments obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationReviewId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationReviewId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditApplicationReviewPointId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditApplicationReviewPointId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPointComment", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.reviewPointComment ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPointStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewPointStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppReviewerComments", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAppReviewerComments> SelectAllAppReviewerComments(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppReviewerComments");

                List<clsAppReviewerComments> adressList = new List<clsAppReviewerComments>();
                TExecuteReaderCmd<clsAppReviewerComments>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppReviewerComments>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppReviewerComments>();
        }
        public List<clsAppReviewerComments> SelectAppReviewerCommentsById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppReviewerCommentsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppReviewerComments> adressList = new List<clsAppReviewerComments>();
                TExecuteReaderCmd<clsAppReviewerComments>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppReviewerComments>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppReviewerComments>();
        }  
        public List<clsAppReviewerComments> SelectAppReviewerCommentsByApplicationReviewId(int applicationReviewId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppReviewerCommentsByApplicationReviewId");
                comand.Parameters.AddWithValue("@applicationReviewId", applicationReviewId);
                List<clsAppReviewerComments> adressList = new List<clsAppReviewerComments>();
                TExecuteReaderCmd<clsAppReviewerComments>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppReviewerComments>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppReviewerComments>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppReviewerComments> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppReviewerComments obj = new clsAppReviewerComments();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.applicationReviewId = returnData["applicationReviewId"] is DBNull ? (int)0 : (int)returnData["applicationReviewId"];
                    obj.auditApplicationReviewPointId = returnData["auditApplicationReviewPointId"] is DBNull ? (int)0 : (int)returnData["auditApplicationReviewPointId"];
                    obj.reviewPointComment = returnData["reviewPointComment"] is DBNull ? (string)string.Empty : (string)returnData["reviewPointComment"];
                    obj.reviewPointStatusId = returnData["reviewPointStatusId"] is DBNull ? (int)0 : (int)returnData["reviewPointStatusId"];
                    obj.reviewPoint =ColumnExists(returnData, "reviewPoint") ? returnData["reviewPoint"] is DBNull ? (string)string.Empty : (string)returnData["reviewPoint"] : string.Empty;
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
