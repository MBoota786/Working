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
   public class questionBankDAL : SQLDataAccess
    {
        public int InsertQuestionsBank(clsQuestionBank at)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditquestion", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)at.auditquestion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.parentQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectManDays", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectManDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectAuditReporting", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectAuditReporting ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForInformationUsage", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForInformationUsage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionGroupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionGroupId ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertQuestionsBank", at.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateQuestionsBank(clsQuestionBank at)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditquestion", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)at.auditquestion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.parentQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectManDays", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectManDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectAuditReporting", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectAuditReporting ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForInformationUsage", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForInformationUsage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionGroupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionGroupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateQuestionsBank");
                ExecuteNonQueryCommand(comm, "spUpdateQuestionsBank", at.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsQuestionBank> SelectAllQuestionsBank(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllQuestionsBank");

                List<clsQuestionBank> activeList = new List<clsQuestionBank>();
                TExecuteReaderCmd<clsQuestionBank>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuestionBank>, ref activeList);
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
        public List<clsQuestionBank> SelectQuestionsBankById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuestionsBankById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsQuestionBank> activeList = new List<clsQuestionBank>();
                TExecuteReaderCmd<clsQuestionBank>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsQuestionBank>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsQuestionBank> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsQuestionBank obj = new clsQuestionBank();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.questionTypeId = returnData["questionTypeId"] is DBNull ? (int)0 : (int)returnData["questionTypeId"];
                    obj.auditquestion = returnData["auditquestion"] is DBNull ? (string)string.Empty : (string)returnData["auditquestion"];
                    obj.parentQuestionId = returnData["parentQuestionId"] is DBNull ? (int)0 : (int)returnData["parentQuestionId"];
                    obj.isEffectAuditPlanning = returnData["isEffectAuditPlanning"] is DBNull ? (bool)false : (bool)returnData["isEffectAuditPlanning"];
                    obj.isEffectAuditReporting = returnData["isEffectAuditReporting"] is DBNull ? (bool)false : (bool)returnData["isEffectAuditReporting"];
                    obj.isForInformationUsage = returnData["isForInformationUsage"] is DBNull ? (bool)false : (bool)returnData["isForInformationUsage"];
                    obj.questionGroupId = returnData["questionGroupId"] is DBNull ? (int)0 : (int)returnData["questionGroupId"];
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
