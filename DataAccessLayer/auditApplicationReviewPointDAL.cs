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
   public class auditApplicationReviewPointDAL : SQLDataAccess
    {
        public int InsertAuditApplicationReviewPoint(clsAuditApplicationReviewPoint obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPoint", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.reviewPoint ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAuditApplicationReviewPoint", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAuditApplicationReviewPoint(clsAuditApplicationReviewPoint obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewPoint", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.reviewPoint ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAuditApplicationReviewPoint", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAuditApplicationReviewPoint> SelectAllAuditApplicationReviewPoint(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAuditApplicationReviewPoint");

                List<clsAuditApplicationReviewPoint> adressList = new List<clsAuditApplicationReviewPoint>();
                TExecuteReaderCmd<clsAuditApplicationReviewPoint>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditApplicationReviewPoint>, ref adressList);
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
        public List<clsAuditApplicationReviewPoint> spSelectAuditApplicationReviewPointById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditApplicationReviewPointById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAuditApplicationReviewPoint> adressList = new List<clsAuditApplicationReviewPoint>();
                TExecuteReaderCmd<clsAuditApplicationReviewPoint>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditApplicationReviewPoint>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAuditApplicationReviewPoint>();
        }
        public List<clsAuditApplicationReviewPoint> SelectAuditApplicationReviewPointByAccreditationStandardIdAndAuditTypeId(int accreditationStandardId,int auditTypeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditApplicationReviewPointByAccreditationStandardIdAndAuditTypeId");
                comand.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                comand.Parameters.AddWithValue("@auditTypeId", auditTypeId);
                List<clsAuditApplicationReviewPoint> adressList = new List<clsAuditApplicationReviewPoint>();
                TExecuteReaderCmd<clsAuditApplicationReviewPoint>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditApplicationReviewPoint>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAuditApplicationReviewPoint>();
        }
        public List<clsAuditApplicationReviewPoint> spSelectAuditApplicationReviewPointByAppId(int appId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAuditApplicationReviewPointByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsAuditApplicationReviewPoint> adressList = new List<clsAuditApplicationReviewPoint>();
                TExecuteReaderCmd<clsAuditApplicationReviewPoint>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAuditApplicationReviewPoint>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAuditApplicationReviewPoint>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAuditApplicationReviewPoint> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAuditApplicationReviewPoint obj = new clsAuditApplicationReviewPoint();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.reviewPoint = returnData["reviewPoint"] is DBNull ? (string)string.Empty : (string)returnData["reviewPoint"];
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
