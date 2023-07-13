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
   public class accreditationOfficeEmailDAL : SQLDataAccess
    {
        public int InsertAccreditationOfficeEmail(clsAccreditationOfficeEmail ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeEmailAddress", SqlDbType.NVarChar,100, ParameterDirection.Input, (object)ct.officeEmailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationOfficeEmail", ct.dbName);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationOfficeEmail(clsAccreditationOfficeEmail ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeEmailAddress", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ct.officeEmailAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationOfficeEmail", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }   
        public bool DeleteAccreditationOfficeEmail(int accreditationId,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)accreditationId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAccreditationOfficeEmail", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationOfficeEmail> SelectAllAccreditationOfficeEmail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationOfficeEmail");
                List<clsAccreditationOfficeEmail> EmailList = new List<clsAccreditationOfficeEmail>();
                TExecuteReaderCmd<clsAccreditationOfficeEmail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationOfficeEmail>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationOfficeEmail>();
        }
        public List<clsAccreditationOfficeEmail> SelectAccreditationOfficeEmailById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationOfficeEmailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationOfficeEmail> EmailList = new List<clsAccreditationOfficeEmail>();
                TExecuteReaderCmd<clsAccreditationOfficeEmail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationOfficeEmail>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationOfficeEmail>();
        }
        public List<clsAccreditationOfficeEmail> SelectAccreditationOfficeEmailByAccreditationId(int accreditationId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationOfficeEmailByAccreditationId");
                comand.Parameters.AddWithValue("@accreditationId", accreditationId);
                List<clsAccreditationOfficeEmail> EmailList = new List<clsAccreditationOfficeEmail>();
                TExecuteReaderCmd<clsAccreditationOfficeEmail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationOfficeEmail>, ref EmailList);
                if (EmailList != null)
                {
                    return EmailList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationOfficeEmail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationOfficeEmail> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationOfficeEmail obj = new clsAccreditationOfficeEmail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationId = returnData["accreditationId"] is DBNull ? (int)0 : (int)returnData["accreditationId"];
                    obj.officeEmailAddress = returnData["officeEmailAddress"] is DBNull ? (string)string.Empty : (string)returnData["officeEmailAddress"];
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
