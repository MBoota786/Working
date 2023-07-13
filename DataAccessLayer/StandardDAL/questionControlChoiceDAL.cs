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
   public class questionControlChoiceDAL : SQLDataAccess
    {
        public int InsertQuestionControlChoice(clsQuestionControlChoice obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionAnswerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionAnswerId ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertQuestionControlChoice", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateQuestionControlChoice(clsQuestionControlChoice obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionBankId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionBankId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.parentQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionAnswerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionAnswerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateQuestionControlChoice", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsQuestionControlChoice> SelectAllQuestionControlChoice(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllQuestionControlChoice");

                List<clsQuestionControlChoice> activeList = new List<clsQuestionControlChoice>();
                TExecuteReaderCmd<clsQuestionControlChoice>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuestionControlChoice>, ref activeList);
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
        public List<clsQuestionControlChoice> SelectQuestionControlChoiceById(int id , string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuestionControlChoiceById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsQuestionControlChoice> activeList = new List<clsQuestionControlChoice>();
                TExecuteReaderCmd<clsQuestionControlChoice>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuestionControlChoice>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsQuestionControlChoice> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsQuestionControlChoice obj = new clsQuestionControlChoice();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.questionBankId = returnData["questionBankId"] is DBNull ? (int)0 : (int)returnData["questionBankId"];
                    obj.parentQuestionId = returnData["parentQuestionId"] is DBNull ? (int)0 : (int)returnData["parentQuestionId"];
                    obj.questionAnswerId = returnData["questionAnswerId"] is DBNull ? (int)0 : (int)returnData["questionAnswerId"];
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
