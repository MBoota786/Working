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
   public class accreditationContactPersonCategoryDAL : SQLDataAccess
    {
        public int InsertAccreditationContactPersonCategory(clsAccreditationContactPersonCategory obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.contactPersonCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationContactPersonCategory", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationContactPersonCategory(clsAccreditationContactPersonCategory obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.contactPersonCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationContactPersonCategory", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationContactPersonCategory> SelectAllAccreditationContactPersonCategory(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationContactPersonCategory");

                List<clsAccreditationContactPersonCategory> activeList = new List<clsAccreditationContactPersonCategory>();
                TExecuteReaderCmd<clsAccreditationContactPersonCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationContactPersonCategory>, ref activeList);
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
        public List<clsAccreditationContactPersonCategory> SelectAccreditationContactPersonCategoryById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationContactPersonCategoryById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationContactPersonCategory> activeList = new List<clsAccreditationContactPersonCategory>();
                TExecuteReaderCmd<clsAccreditationContactPersonCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationContactPersonCategory>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationContactPersonCategory> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationContactPersonCategory obj = new clsAccreditationContactPersonCategory();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.contactPersonCategory = returnData["contactPersonCategory"] is DBNull ? (string)string.Empty : (string)returnData["contactPersonCategory"];
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
        public bool IsAccreditationContactPersonCategoryExist(string contactPersonCategory, string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@contactPersonCategory", contactPersonCategory);
                return IsRecordExistCheck(cmd, "spIsAccreditationContactPersonCategory", dbName);
            }
        }
        public List<clsAccreditationContactPersonCategory> SelectAccreditationContactPersonCategoryByName(string contactPersonCategory, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationContactPersonCategoryByName");
                comand.Parameters.AddWithValue("@contactPersonCategory", contactPersonCategory);
                List<clsAccreditationContactPersonCategory> activeList = new List<clsAccreditationContactPersonCategory>();
                TExecuteReaderCmd<clsAccreditationContactPersonCategory>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationContactPersonCategory>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationContactPersonCategory>();
        }
    }
}
