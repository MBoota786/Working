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
   public class applicationReviewDAL : SQLDataAccess
    {
        public int InsertApplicationReview(clsApplicationReview obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewStartDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.reviewStartDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewEndDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.reviewEndDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewRiskConsider", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.reviewRiskConsider ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalDecisionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.finalDecisionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@signImgPath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.signImgPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertApplicationReview", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateApplicationReview(clsApplicationReview obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewStartDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.reviewStartDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewEndDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.reviewEndDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewRiskConsider", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.reviewRiskConsider ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalDecisionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.finalDecisionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@signImgPath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.signImgPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateApplicationReview", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsApplicationReview> SelectAllApplicationReview(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllApplicationReview");

                List<clsApplicationReview> activeList = new List<clsApplicationReview>();
                TExecuteReaderCmd<clsApplicationReview>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationReview>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationReview>();
        }
        public List<clsApplicationReview> SelectApplicationReviewById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationReviewById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsApplicationReview> activeList = new List<clsApplicationReview>();
                TExecuteReaderCmd<clsApplicationReview>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationReview>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationReview>();
        }
        public List<clsApplicationReview> SelectApplicationReviewByAppId(int appId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationReviewByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsApplicationReview> activeList = new List<clsApplicationReview>();
                TExecuteReaderCmd<clsApplicationReview>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationReview>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationReview>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsApplicationReview> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsApplicationReview obj = new clsApplicationReview();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.reviewerId = returnData["reviewerId"] is DBNull ? (int)0 : (int)returnData["reviewerId"];
                    obj.reviewStartDate = returnData["reviewStartDate"] is DBNull ? (DateTime?)null: (DateTime)returnData["reviewStartDate"];
                    obj.reviewEndDate = returnData["reviewEndDate"] is DBNull ? (DateTime?)null: (DateTime)returnData["reviewEndDate"];
                    obj.reviewRiskConsider = returnData["reviewRiskConsider"] is DBNull ? (string) string.Empty: (string)returnData["reviewRiskConsider"];
                    obj.finalDecisionId = returnData["finalDecisionId"] is DBNull ? (int) 0 : (int)returnData["finalDecisionId"];
                    obj.appId = returnData["appId"] is DBNull ? (int) 0 : (int)returnData["appId"];
                    obj.signImgPath = returnData["signImgPath"] is DBNull ? (string) string.Empty : (string)returnData["signImgPath"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
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
