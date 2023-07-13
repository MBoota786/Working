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
   public class accreditationBodyDAL : SQLDataAccess
    {
        public int InsertAccreditationBody(clsAccreditationBody obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationOtherCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationOtherCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationVatNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationBody", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationBody(clsAccreditationBody obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationOtherCategory", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationOtherCategory ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationVatNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationVatNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accreditationWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationBody", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationBody> SelectAllAccreditationBody(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationBody");

                List<clsAccreditationBody> activeList = new List<clsAccreditationBody>();
                TExecuteReaderCmd<clsAccreditationBody>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBody>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBody>();
        }
        public List<clsAccreditationBody> SelectAccreditationNameForList(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationNameForList");

                List<clsAccreditationBody> activeList = new List<clsAccreditationBody>();
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            clsAccreditationBody obj = new clsAccreditationBody();
                            obj.id = reader["id"] is DBNull ? (int) 0 : (int)reader["id"];
                            obj.accreditationName = reader["accreditationName"] is DBNull ? (string)string.Empty : (string)reader["accreditationName"];
                            activeList.Add(obj);
                        }

                    }

                    con.Close();
                }
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBody>();
        }
        public List<clsAccreditationBody> SelectAllAccreditationForView(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationForView");

                List<clsAccreditationBody> activeList = new List<clsAccreditationBody>();
                TExecuteReaderCmd<clsAccreditationBody>(comand, TGenerateSOFieldFromReaderactiveListForView<clsAccreditationBody>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBody>();
        }
        public List<clsAccreditationBody> SelectAccreditationBodyById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationBodyById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationBody> activeList = new List<clsAccreditationBody>();
                TExecuteReaderCmd<clsAccreditationBody>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBody>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBody>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationBody> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationBody obj = new clsAccreditationBody();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationName = returnData["accreditationName"] is DBNull ? (string)string.Empty : (string)returnData["accreditationName"];
                    obj.accreditationOtherCategory = returnData["accreditationOtherCategory"] is DBNull ? (string)string.Empty : (string)returnData["accreditationOtherCategory"];
                    obj.accreditationVatNo = returnData["accreditationVatNo"] is DBNull ? (string)string.Empty : (string)returnData["accreditationVatNo"];
                    obj.accreditationWebsite = returnData["accreditationWebsite"] is DBNull ? (string)string.Empty : (string)returnData["accreditationWebsite"];
                    obj.accreditationCategoryId = returnData["accreditationCategoryId"] is DBNull ? (int)0 : (int)returnData["accreditationCategoryId"];
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
        public void TGenerateSOFieldFromReaderactiveListForView<T>(SqlDataReader returnData, ref List<clsAccreditationBody> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationBody obj = new clsAccreditationBody();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationName = returnData["accreditationName"] is DBNull ? (string)string.Empty : (string)returnData["accreditationName"];
                    obj.accreditationCategory = returnData["accreditationCategory"] is DBNull ? (string)string.Empty : (string)returnData["accreditationCategory"];
                    obj.standardName = returnData["standardName"] is DBNull ? (string)string.Empty : (string)returnData["standardName"];
                    obj.PerShow = returnData["PerShow"] is DBNull ? (string)string.Empty : (string)returnData["PerShow"];
                    obj.accreditationVatNo = returnData["accreditationVatNo"] is DBNull ? (string)string.Empty : (string)returnData["accreditationVatNo"];
                    obj.accreditationCategoryId = returnData["accreditationCategoryId"] is DBNull ? (int)0 : (int)returnData["accreditationCategoryId"];
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
