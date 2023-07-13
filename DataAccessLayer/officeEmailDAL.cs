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
   public class officeEmailDAL  : SQLDataAccess
    {
        public int InsertOfficeEmail(clsOfficeEmail ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@emailTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.emailTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@emailAddress", SqlDbType.NVarChar,100, ParameterDirection.Input, (object)ct.emailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteInsertCommandReturnId(comm, "spInsertOfficeEmail", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeEmail(clsOfficeEmail ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@emailTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.emailTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@emailAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ct.emailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeEmail", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsOfficeEmail> SelectAllOfficeEmail(string dbName)
        {
            try
            {

                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "SpSelelctAllOfficeEmail");
                List<clsOfficeEmail> EmailList = new List<clsOfficeEmail>();
                TExecuteReaderCmd<clsOfficeEmail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeEmail>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeEmail>();
        }
        public List<clsOfficeEmail> SelectOfficeEmailById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "SpSelectOfficeEmailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeEmail> EmailList = new List<clsOfficeEmail>();
                TExecuteReaderCmd<clsOfficeEmail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeEmail>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeEmail>();
        }
        public List<clsOfficeEmail> SelelctOfficeEmailByOfficeId (int officeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "SpSelelctOfficeEmailByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeEmail> EmailList = new List<clsOfficeEmail>();
                TExecuteReaderCmd<clsOfficeEmail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeEmail>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeEmail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeEmail> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeEmail obj = new clsOfficeEmail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeID = returnData["officeID"] is DBNull ? (int)0 : (int)returnData["officeID"];
                    obj.officeName = returnData["officeName"] is DBNull ? (string)string.Empty : (string)returnData["officeName"];
                    obj.emailTypeId = returnData["emailTypeId"] is DBNull ? (int)0 : (int)returnData["emailTypeId"];
                    obj.emailAddress = returnData["emailAddress"] is DBNull ? (string)string.Empty : (string)returnData["emailAddress"];
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
