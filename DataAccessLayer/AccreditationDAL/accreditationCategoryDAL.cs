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
   public class accreditationCategoryDAL : SQLDataAccess
    {
        public int InsertAccreditationCategory(clsAccreditationCategory obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationCategoryName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationCategoryName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationCategory", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationCategory(clsAccreditationCategory obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationCategoryName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationCategoryName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationCategory", null);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationCategory> SelectAllAccreditationCategory()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationCategory");

                List<clsAccreditationCategory> activeList = new List<clsAccreditationCategory>();
                TExecuteReaderCmd<clsAccreditationCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCategory>, ref activeList);
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
        public List<clsAccreditationCategory> SelectAccreditationCategoryById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationCategoryById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationCategory> activeList = new List<clsAccreditationCategory>();
                TExecuteReaderCmd<clsAccreditationCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCategory>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationCategory> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationCategory obj = new clsAccreditationCategory();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationCategoryName= returnData["accreditationCategoryName"] is DBNull ? (string)string.Empty : (string)returnData["accreditationCategoryName"];
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
        public bool IsAccreditationOtherCategoryExist(string accreditationCategoryName, string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@accreditationCategoryName", accreditationCategoryName);
                return IsRecordExistCheck(cmd, "spIsAccreditationOtherCategory", dbName);
            }
        }
        public List<clsAccreditationCategory> SelectAccreditationOtherCategoryByName(string accreditationCategoryName, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationOtherCategoryByName");
                comand.Parameters.AddWithValue("@accreditationCategoryName", accreditationCategoryName);
                List<clsAccreditationCategory> activeList = new List<clsAccreditationCategory>();
                TExecuteReaderCmd<clsAccreditationCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBody>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCategory>();
        }
    }
}
