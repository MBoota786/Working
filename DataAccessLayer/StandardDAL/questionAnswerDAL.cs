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
   public class questionAnswerDAL : SQLDataAccess
    {
        public int InsertQuestionAnswer(clsQuestionAnswer obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceCode", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.choiceCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.choiceName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAnswer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAnswer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@manDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.manDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionEffectId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionEffectId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@planningDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.planningDays ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertQuestionAnswer", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateQuestionAnswer(clsQuestionAnswer obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceCode", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.choiceCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@choiceName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.choiceName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAnswer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isAnswer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@manDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.manDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionEffectId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionEffectId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@planningDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.planningDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateQuestionAnswer", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsQuestionAnswer> SelectAllQuestionAnswer(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllQuestionAnswer");

                List<clsQuestionAnswer> activeList = new List<clsQuestionAnswer>();
                TExecuteReaderCmd<clsQuestionAnswer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuestionAnswer>, ref activeList);
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
        public List<clsQuestionAnswer> SelectQuestionAnswerById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuestionAnswerById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsQuestionAnswer> activeList = new List<clsQuestionAnswer>();
                TExecuteReaderCmd<clsQuestionAnswer>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuestionAnswer>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsQuestionAnswer> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsQuestionAnswer obj = new clsQuestionAnswer();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.questionBankId = returnData["questionBankId"] is DBNull ? (int)0 : (int)returnData["questionBankId"];
                    obj.choiceCode = returnData["choiceCode"] is DBNull ? (string)string.Empty : (string)returnData["choiceCode"];
                    obj.choiceName = returnData["choiceName"] is DBNull ? (string)string.Empty : (string)returnData["choiceName"];
                    obj.isAnswer = returnData["isAnswer"] is DBNull ? (bool)false : (bool)returnData["isAnswer"];
                    obj.manDays = returnData["manDays"] is DBNull ? (int) 0 : (int)returnData["manDays"];
                    obj.questionEffectId = returnData["questionEffectId"] is DBNull ? (int)0 : (int)returnData["questionEffectId"];
                    obj.planningDays = returnData["planningDays"] is DBNull ? (int)0 : (int)returnData["planningDays"];
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
