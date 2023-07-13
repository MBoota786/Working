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
   public class standardQuestionForAppDAL : SQLDataAccess
    {
        public int InsertStandardQuestionForApp(clsStandardQuestionForApp obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionAnswerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionAnswerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionAnswer", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.questionAnswer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardQuestionForApp", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardQuestionForApp(clsStandardQuestionForApp obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionAnswerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionAnswerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionAnswer", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.questionAnswer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateStandardQuestionForApp", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardQuestionForApp> SelectAllStandardQuestionForApp(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardQuestionForApp");

                List<clsStandardQuestionForApp> activeList = new List<clsStandardQuestionForApp>();
                TExecuteReaderCmd<clsStandardQuestionForApp>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardQuestionForApp>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardQuestionForApp>();
        }
        public List<clsStandardQuestionForApp> SelectStandardQuestionForAppById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardQuestionForAppById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardQuestionForApp> activeList = new List<clsStandardQuestionForApp>();
                TExecuteReaderCmd<clsStandardQuestionForApp>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardQuestionForApp>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardQuestionForApp>();
        }  
        public List<clsStandardQuestionForApp> SelectStandardQuestionForAppByAppId(int appId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardQuestionForAppByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsStandardQuestionForApp> activeList = new List<clsStandardQuestionForApp>();
                TExecuteReaderCmd<clsStandardQuestionForApp>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardQuestionForApp>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardQuestionForApp>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardQuestionForApp> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardQuestionForApp obj = new clsStandardQuestionForApp();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.questionBankId = returnData["questionBankId"] is DBNull ? (int)0 : (int)returnData["questionBankId"];
                    obj.questionAnswerId = returnData["questionAnswerId"] is DBNull ? (int)0 : (int)returnData["questionAnswerId"];
                    obj.questionAnswer = returnData["questionAnswer"] is DBNull ? (string)string.Empty : (string)returnData["questionAnswer"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
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
