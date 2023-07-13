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
   public class companyStandardsDAL : SQLDataAccess
    {
        public int InsertCompanyStandards(clsCompanyStandards ls)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.companyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);

                Id = ExecuteInsertCommandReturnId(comm, "spInsertCompanyStandards", ls.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCompanyStandards(clsCompanyStandards ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.companyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ls.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCompanyStandards", ls.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public bool SetActiveFalseCompanyStandardsByCompanyId(clsCompanyStandards ls)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@companyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.companyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ls.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ls.modifiedBy ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spSetActiveFalseCompanyStandardsByCompanyId", ls.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsCompanyStandards> SelectAllCompanyStandards(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCompanyStandards");

                List<clsCompanyStandards> activeList = new List<clsCompanyStandards>();
                TExecuteReaderCmd<clsCompanyStandards>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCompanyStandards>, ref activeList);
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
        public List<clsCompanyStandards> SelectCompanyStandardsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCompanyStandardsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCompanyStandards> activeList = new List<clsCompanyStandards>();
                TExecuteReaderCmd<clsCompanyStandards>(comand, TGenerateSOFieldFromReaderactiveStatusList<clsCompanyStandards>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveStatusList<T>(SqlDataReader returnData, ref List<clsCompanyStandards> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCompanyStandards obj = new clsCompanyStandards();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.companyId = returnData["companyId"] is DBNull ? (int)0 : (int)returnData["companyId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    if (ColumnExists(returnData,"standardName"))
                    {
                        obj.standardName = returnData["standardName"] is DBNull ? (string) string.Empty : (string)returnData["standardName"];
                    }
                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                    
                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsExistCompanyStandards(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@id", id);
                return IsRecordExistCheck(cmd, "spIsExistCompanyStandards", null);
            }
        }
        public bool IsExistCompanyStandardsByCompanyId(int id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@companyId", id);
                return IsRecordExistCheck(cmd, "spIsExistCompanyStandardsByCompanyId", null);
            }
        }
    }
}
