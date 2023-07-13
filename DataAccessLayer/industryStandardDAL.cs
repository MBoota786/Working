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
   public class industryStandardDAL : SQLDataAccess
    {
        public int InsertIndustryStandard(clsIndustryStandard obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@industryStandardName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.industryStandardName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertIndustryStandard", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateIndustryStandard(clsIndustryStandard obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@industryStandardName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.industryStandardName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateIndustryStandard", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsIndustryStandard> SelectAllIndustryStandard(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllIndustryStandard");

                List<clsIndustryStandard> activeList = new List<clsIndustryStandard>();
                TExecuteReaderCmd<clsIndustryStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsIndustryStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsIndustryStandard>();
        }
        public List<clsIndustryStandard> SelectIndustryStandardById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectIndustryStandardById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsIndustryStandard> activeList = new List<clsIndustryStandard>();
                TExecuteReaderCmd<clsIndustryStandard>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsIndustryStandard>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsIndustryStandard>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsIndustryStandard> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsIndustryStandard obj = new clsIndustryStandard();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.industryStandardName = returnData["industryStandardName"] is DBNull ? (string)string.Empty : (string)returnData["industryStandardName"];
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
