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
   public class appStandardQuestionDAL : SQLDataAccess
    {
        public int InsertAppStandardQuestion(clsAppStandardQuestion obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardQuestion", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.standardQuestion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppStandardQuestion", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppStandardQuestion(clsAppStandardQuestion obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.questionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardQuestion", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.standardQuestion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppStandardQuestion", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppStandardQuestion> SelectAllAppStandardQuestion(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppStandardQuestion");

                List<clsAppStandardQuestion> activeList = new List<clsAppStandardQuestion>();
                TExecuteReaderCmd<clsAppStandardQuestion>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppStandardQuestion>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppStandardQuestion>();
        }
        public List<clsAppStandardQuestion> SelectAppStandardQuestionById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppStandardQuestionById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppStandardQuestion> activeList = new List<clsAppStandardQuestion>();
                TExecuteReaderCmd<clsAppStandardQuestion>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppStandardQuestion>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppStandardQuestion> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppStandardQuestion obj = new clsAppStandardQuestion();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.questionId = returnData["questionId"] is DBNull ? (int)0 : (int)returnData["questionId"];
                    obj.questionTypeId = returnData["questionTypeId"] is DBNull ? (int)0 : (int)returnData["questionTypeId"];
                    obj.standardQuestion = returnData["standardQuestion"] is DBNull ? (string)string.Empty : (string)returnData["standardQuestion"];
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
