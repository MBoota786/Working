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
  public  class emailTypeDAL : SQLDataAccess
    {
        public int InsertEmailType(clsEmailTypes et)
        {
        
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)et.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@emailTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)et.emailTypeName ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)et.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)et.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)et.active ?? DBNull.Value);
               Id = ExecuteInsertCommandReturnId(comm, "spInsertEmailType", et.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateEmailType(clsEmailTypes et)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)et.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@emailTypeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)et.emailTypeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)et.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)et.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)et.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateEmailType", et.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsEmailTypes> SelectAllEmailType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllEmailType");

                List<clsEmailTypes> EmailList = new List<clsEmailTypes>();
                TExecuteReaderCmd<clsEmailTypes>(comand, TGenerateSOFieldFromReaderactiveEmailList<clsEmailTypes>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsEmailTypes> SelectEmailTypeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectEmailTypeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsEmailTypes> EmailList = new List<clsEmailTypes>();
                TExecuteReaderCmd<clsEmailTypes>(comand, TGenerateSOFieldFromReaderactiveEmailList<clsEmailTypes>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveEmailList<T>(SqlDataReader returnData, ref List<clsEmailTypes> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsEmailTypes obj = new clsEmailTypes();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.emailTypeName = returnData["emailTypeName"] is DBNull ? (string)string.Empty : (string)returnData["emailTypeName"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
