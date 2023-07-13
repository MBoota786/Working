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
   public class termsConditionDAL : SQLDataAccess
    {
        public int InsertTermsCondition(clsTermsCondition obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@termsConditionCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.termsConditionCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@termsCondition", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.termsCondition ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertTermsCondition", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateTermsCondition(clsTermsCondition obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@termsConditionCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.termsConditionCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@termsCondition", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.termsCondition ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateTermsCondition", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsTermsCondition> SelectAllTermsCondition(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllTermsCondition");

                List<clsTermsCondition> activeList = new List<clsTermsCondition>();
                TExecuteReaderCmd<clsTermsCondition>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTermsCondition>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsTermsCondition>();
        }
        public List<clsTermsCondition> SelectTermsConditionByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectTermsConditionByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsTermsCondition> activeList = new List<clsTermsCondition>();
                TExecuteReaderCmd<clsTermsCondition>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTermsCondition>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsTermsCondition>();
        }
        public List<clsTermsCondition> SelectTermsConditionByAccreditationStandardId(int accreditationStandardId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectTermsConditionByAccreditationStandardId");
                comand.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                List<clsTermsCondition> activeList = new List<clsTermsCondition>();
                TExecuteReaderCmd<clsTermsCondition>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTermsCondition>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsTermsCondition>();
        }
        public List<clsTermsCondition> SelectTermsConditionById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectTermsConditionById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsTermsCondition> activeList = new List<clsTermsCondition>();
                TExecuteReaderCmd<clsTermsCondition>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTermsCondition>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsTermsCondition>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsTermsCondition> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsTermsCondition obj = new clsTermsCondition();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.termsConditionCategoryId = returnData["termsConditionCategoryId"] is DBNull ? (int)0 : (int)returnData["termsConditionCategoryId"];
                    obj.termsCondition = returnData["termsCondition"] is DBNull ? (string)string.Empty : (string)returnData["termsCondition"];
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
