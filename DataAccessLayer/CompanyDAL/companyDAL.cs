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
  public  class companyDAL : SQLDataAccess
    {
        public int InsertCompany(clsCompany obj,string dbName)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@code", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.code ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyName", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.companyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyAddress", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.companyAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@postalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.postalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.companyWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.companyPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyCellNo", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.companyCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadCompanyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dBName", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.dbName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@folderPath", SqlDbType.VarChar, 50, ParameterDirection.Input, (object)obj.folderPath ?? DBNull.Value);
           
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
              Id = ExecuteInsertCommandReturnId(comm, "spInsertCompany", dbName);
            }
            catch (Exception)
            {
               // throw ex;
            }
            return Id;
        }
        public void UpdateCompany(clsCompany obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@code", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.code ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyName", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.companyName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyAddress", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.companyAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@postalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.postalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.companyWebsite ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.companyPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyCellNo", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.companyCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadCompanyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@dBName", SqlDbType.VarChar, 250, ParameterDirection.Input, (object)obj.dbName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@folderPath", SqlDbType.VarChar, 50, ParameterDirection.Input, (object)obj.folderPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCompany", obj.dbName);
            }
            catch (Exception)
            {
               // throw ex;
            }
        }
        public string GetMaxCode(string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
               return ExecuteReaderStringCode(cmd, "spGetCompanyMaxCode", dbName);
            }
          //  return SqlDBHelper.ExecuteGetSingleStringCommand("spGetCompanyMaxCode", CommandType.StoredProcedure);
        }
        public List<clsCompany> SelectAllCompany(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCompany");

                List<clsCompany> activeList = new List<clsCompany>();
                TExecuteReaderCmd<clsCompany>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCompany>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsCompany> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCompany obj = new clsCompany();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.code = returnData["code"] is DBNull ? (string)string.Empty : (string)returnData["code"];
                    obj.companyName = returnData["companyName"] is DBNull ? (string)string.Empty : (string)returnData["companyName"];
                    obj.companyAddress = returnData["companyAddress"] is DBNull ? (string)string.Empty : (string)returnData["companyAddress"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.stateProviceId = returnData["stateProviceId"] is DBNull ? (int)0 : (int)returnData["stateProviceId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.postalCode = returnData["postalCode"] is DBNull ? (string) string.Empty : (string)returnData["postalCode"];
                    obj.companyWebsite = returnData["companyWebsite"] is DBNull ? (string) string.Empty : (string)returnData["companyWebsite"];
                    obj.companyCellNo = returnData["companyCellNo"] is DBNull ? (string) string.Empty : (string)returnData["companyCellNo"];
                    obj.companyPhone = returnData["companyPhone"] is DBNull ? (string) string.Empty : (string)returnData["companyPhone"];
                    obj.dbName = returnData["dBName"] is DBNull ? (string) string.Empty : (string)returnData["dBName"];
                    obj.folderPath = returnData["folderPath"] is DBNull ? (string) string.Empty : (string)returnData["folderPath"];
                    obj.leadCompanyId = returnData["leadCompanyId"] is DBNull ? (int) 0 : (int)returnData["leadCompanyId"];
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
        public void CreateDatabaseForClient(string cmdstring)
        {
            const string CONNECTION_STRING = @"Data Source=.;Initial Catalog=master;Integrated Security=True";
            

            try
            {
                SqlConnection sqlcon = new SqlConnection();

                sqlcon.ConnectionString = (CONNECTION_STRING);
                sqlcon.Open();

                SqlCommand sqlcmd = new SqlCommand(cmdstring, sqlcon);


                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool IsCompanyNameAlreadyExist(string companyName, string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Parameters.AddWithValue("@companyName", companyName);
                return IsRecordExistCheck(cmd, "spIsCompanyNameAlreadyExist", dbName);
            }
        }
        public string GetCompanyFolderPathById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                string folderPath = "";
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@id", id);
                SetCommandType(comand, CommandType.StoredProcedure, "spGetCompanyFolderPathById");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {

                        if (returnData.Read())
                        {

                            folderPath = returnData["folderPath"] is DBNull ? (string)string.Empty : (string)returnData["folderPath"];
                        }
                        else
                        {
                            folderPath = null;
                        }
              
                        
                    }

                    con.Close();

                    return folderPath;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
        
    }
}
