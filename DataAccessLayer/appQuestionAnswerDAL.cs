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
   public class appQuestionAnswerDAL : SQLDataAccess
    {
        public int InsertAppQuestionAnswer(clsAppQuestionAnswer obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stdAppQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stdAppQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.choiceCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.choiceName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAnswer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAnswer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppQuestionAnswer", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppQuestionAnswer(clsAppQuestionAnswer obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stdAppQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stdAppQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.choiceCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.choiceName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAnswer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAnswer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppQuestionAnswer", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppQuestionAnswer> SelectAllAppQuestionAnswer(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppQuestionAnswer");

                List<clsAppQuestionAnswer> activeList = new List<clsAppQuestionAnswer>();
                TExecuteReaderCmd<clsAppQuestionAnswer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuestionAnswer>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsAppQuestionAnswer> SelectAppQuestionAnswerByQuestionId(int questionId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuestionAnswerByQuestionId");
                comand.Parameters.AddWithValue("@stdAppQuestionId", questionId);
                List<clsAppQuestionAnswer> activeList = new List<clsAppQuestionAnswer>();
                TExecuteReaderCmd<clsAppQuestionAnswer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuestionAnswer>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsAppQuestionAnswer> SelectAppQuestionAnswerById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuestionAnswerById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppQuestionAnswer> activeList = new List<clsAppQuestionAnswer>();
                TExecuteReaderCmd<clsAppQuestionAnswer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuestionAnswer>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppQuestionAnswer> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppQuestionAnswer obj = new clsAppQuestionAnswer();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.stdAppQuestionId = returnData["stdAppQuestionId"] is DBNull ? (int)0 : (int)returnData["stdAppQuestionId"];
                    obj.choiceCode = returnData["choiceCode"] is DBNull ? (string)string.Empty : (string)returnData["choiceCode"];
                    obj.choiceName = returnData["choiceName"] is DBNull ? (string)string.Empty : (string)returnData["choiceName"];
                    obj.isAnswer = returnData["isAnswer"] is DBNull ? (bool)true : (bool)returnData["isAnswer"];
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
