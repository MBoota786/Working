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
   public class standardInterviewRequirementDAL : SQLDataAccess
    {
        public int InsertStandardInterviewRequirement(clsStandardInterviewRequirement obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@interviewTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.interviewTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeesFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeesFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeesTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeesTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredInterview", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.requiredInterview ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@estimatedTime", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.estimatedTime ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewRecord", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewRecord ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@groupOfEmployee", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.groupOfEmployee ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfGroup", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfGroup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertStandardInterviewRequirement", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardInterviewRequirement(clsStandardInterviewRequirement obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@interviewTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.interviewTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeesFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeesFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeesTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeesTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredInterview", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.requiredInterview ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@estimatedTime", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.estimatedTime ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reviewRecord", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reviewRecord ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@groupOfEmployee", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.groupOfEmployee ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfGroup", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfGroup ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteInsertCommandReturnId(comm, "spUpdateStandardInterviewRequirement", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsStandardInterviewRequirement> SelectAllStandardInterviewRequirement(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllStandardInterviewRequirement");

                List<clsStandardInterviewRequirement> activeList = new List<clsStandardInterviewRequirement>();
                TExecuteReaderCmd<clsStandardInterviewRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardInterviewRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardInterviewRequirement>();
        }
        public List<clsStandardInterviewRequirement> SelectStandardInterviewRequirementById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardInterviewRequirementById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsStandardInterviewRequirement> activeList = new List<clsStandardInterviewRequirement>();
                TExecuteReaderCmd<clsStandardInterviewRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardInterviewRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardInterviewRequirement>();
        }  
        public List<clsStandardInterviewRequirement> SelectStandardInterviewRequirementByQuotationId(int quotationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectStandardInterviewRequirementByQuotationId");
                comand.Parameters.AddWithValue("@quotationId", quotationId);
                List<clsStandardInterviewRequirement> activeList = new List<clsStandardInterviewRequirement>();
                TExecuteReaderCmd<clsStandardInterviewRequirement>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsStandardInterviewRequirement>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsStandardInterviewRequirement>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardInterviewRequirement> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsStandardInterviewRequirement obj = new clsStandardInterviewRequirement();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.auditTypeId =ColumnExists(returnData, "auditTypeId") ? returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"] : 0;
                    obj.interviewTypeId = returnData["interviewTypeId"] is DBNull ? (int)0 : (int)returnData["interviewTypeId"];
                    obj.employeesFrom = returnData["employeesFrom"] is DBNull ? (int)0 : (int)returnData["employeesFrom"];
                    obj.employeesTo = returnData["employeesTo"] is DBNull ? (int)0 : (int)returnData["employeesTo"];
                    obj.requiredInterview = returnData["requiredInterview"] is DBNull ? (int)0 : (int)returnData["requiredInterview"];
                    obj.estimatedTime = returnData["estimatedTime"] is DBNull ? (decimal)0 : (decimal)returnData["estimatedTime"];
                    obj.reviewRecord = returnData["reviewRecord"] is DBNull ? (int)0 : (int)returnData["reviewRecord"];
                    obj.groupOfEmployee = returnData["groupOfEmployee"] is DBNull ? (int)0 : (int)returnData["groupOfEmployee"];
                    obj.noOfGroup = returnData["noOfGroup"] is DBNull ? (int)0 : (int)returnData["noOfGroup"];
                    obj.standardName =ColumnExists(returnData, "standardName") ? returnData["standardName"] is DBNull ? (string) string.Empty : (string)returnData["standardName"] : string.Empty;
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
