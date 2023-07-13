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
   public class manDaysFormulaDAL : SQLDataAccess
    {
        public int InsertManDaysFormula(clsManDaysFormula obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employyesFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employyesFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeesTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeesTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertManDaysFormula", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateManDaysFormula(clsManDaysFormula obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationBodyStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationBodyStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employyesFrom", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employyesFrom ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@employeesTo", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.employeesTo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@auditDays", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.auditDays ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateManDaysFormula", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsManDaysFormula> SelectAllManDaysFormula(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllManDaysFormula");

                List<clsManDaysFormula> activeList = new List<clsManDaysFormula>();
                TExecuteReaderCmd<clsManDaysFormula>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsManDaysFormula>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsManDaysFormula>();
        }
        public List<clsManDaysFormula> SelectManDaysFormulaById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectManDaysFormulaById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsManDaysFormula> activeList = new List<clsManDaysFormula>();
                TExecuteReaderCmd<clsManDaysFormula>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsManDaysFormula>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsManDaysFormula>();
        }
        public List<clsManDaysFormula> SelectMandaysFormulaByQuotationId(int quotationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectMandaysFormulaByQuotationId");
                comand.Parameters.AddWithValue("@quotationId", quotationId);
                List<clsManDaysFormula> activeList = new List<clsManDaysFormula>();
                TExecuteReaderCmd<clsManDaysFormula>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsManDaysFormula>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsManDaysFormula>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsManDaysFormula> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsManDaysFormula obj = new clsManDaysFormula();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationBodyStandardId = returnData["accreditationBodyStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationBodyStandardId"];
                    obj.auditTypeId = returnData["auditTypeId"] is DBNull ? (int)0 : (int)returnData["auditTypeId"];
                    obj.employyesFrom = returnData["employyesFrom"] is DBNull ? (int)0 : (int)returnData["employyesFrom"];
                    obj.employeesTo = returnData["employeesTo"] is DBNull ? (int)0 : (int)returnData["employeesTo"];
                    obj.standardName = ColumnExists(returnData, "standardName") ? returnData["standardName"] is DBNull ? (string) string.Empty : (string)returnData["standardName"] : string.Empty;
                    obj.auditTypeName = ColumnExists(returnData, "auditTypeName") ? returnData["auditTypeName"] is DBNull ? (string) string.Empty : (string)returnData["auditTypeName"] : string.Empty;
                    obj.auditDays = returnData["auditDays"] is DBNull ? (decimal)0 : (decimal)returnData["auditDays"];
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
