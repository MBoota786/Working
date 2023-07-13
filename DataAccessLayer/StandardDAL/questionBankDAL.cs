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
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditquestion", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)at.auditquestion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.parentQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectManDays", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectManDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectAuditReporting", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectAuditReporting ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForInformationUsage", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForInformationUsage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionGroupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionGroupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForStandard", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForStandard ?? DBNull.Value);
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
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditquestion", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)at.auditquestion ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@parentQuestionId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.parentQuestionId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectManDays", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectManDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEffectAuditReporting", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isEffectAuditReporting ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForInformationUsage", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForInformationUsage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@questionGroupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.questionGroupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForStandard", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.isForStandard ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)at.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)at.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)at.active ?? DBNull.Value);
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
            return new List<clsQuestionBank>();
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
            return new List<clsQuestionBank>();
        }
        public List<clsQuestionBank> SelectQuestionsBankByParentQuestionId(int parentQuestionId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuestionsBankByParentQuestionId");
                comand.Parameters.AddWithValue("@parentQuestionId", parentQuestionId);
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
            return new List<clsQuestionBank>();
        } 
        public List<clsQuestionBank> SelectQuestionsBankByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuestionsBankByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
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
            return new List<clsQuestionBank>();
        }  
        public List<clsQuestionBank> SelectQuestionsBankByOfficeIdAndCountryId(int officeId,int countryId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuestionsBankByOfficeIdAndCountryId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                comand.Parameters.AddWithValue("@countryId", countryId);
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
            return new List<clsQuestionBank>();
        }
        public List<clsQuestionBank> SelectQuestionsBankByOfficeIdAndCountryIdAndStateProvinceId(int officeId,int countryId,int stateProvinceId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuestionsBankByOfficeIdAndCountryIdAndStateProvinceId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                comand.Parameters.AddWithValue("@countryId", countryId);
                comand.Parameters.AddWithValue("@stateProvinceId", stateProvinceId);
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
            return new List<clsQuestionBank>();
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
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.questionTypeId = returnData["questionTypeId"] is DBNull ? (int)0 : (int)returnData["questionTypeId"];
                    obj.auditquestion = returnData["auditquestion"] is DBNull ? (string)string.Empty : (string)returnData["auditquestion"];
                    obj.parentQuestionId = returnData["parentQuestionId"] is DBNull ? (int)0 : (int)returnData["parentQuestionId"];
                    obj.isEffectAuditPlanning = returnData["isEffectAuditPlanning"] is DBNull ? (bool)false : (bool)returnData["isEffectAuditPlanning"];
                    obj.isEffectAuditReporting = returnData["isEffectAuditReporting"] is DBNull ? (bool)false : (bool)returnData["isEffectAuditReporting"];
                    obj.isForInformationUsage = returnData["isForInformationUsage"] is DBNull ? (bool)false : (bool)returnData["isForInformationUsage"];
                    obj.questionGroupId = returnData["questionGroupId"] is DBNull ? (int)0 : (int)returnData["questionGroupId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.isForOffice = returnData["isForOffice"] is DBNull ? (bool)false : (bool)returnData["isForOffice"];
                    obj.isForStandard = returnData["isForStandard"] is DBNull ? (bool)false : (bool)returnData["isForStandard"];
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    if (ColumnExists(returnData,""))
                    {
                        obj.questionType = returnData["questionType"] is DBNull ? (string)string.Empty : (string)returnData["questionType"];
                    }
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
