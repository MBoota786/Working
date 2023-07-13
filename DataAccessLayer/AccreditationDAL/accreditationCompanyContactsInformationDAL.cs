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
  public  class accreditationCompanyContactsInformationDAL : SQLDataAccess
    {
        public int InsertAccreditationCompanyContactsInformation(clsAccreditationCompanyContactsInformation ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.countryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@extentionNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.extentionNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactNumberIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactNumberIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationCompanyContactsInformation", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationCompanyContactsInformation(clsAccreditationCompanyContactsInformation ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.countryCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@extentionNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.extentionNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactNumberIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactNumberIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationCompanyContactsInformation", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationCompanyContactsInformation> SelectAllAccreditationCompanyContactsInformation(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationCompanyContactsInformation");

                List<clsAccreditationCompanyContactsInformation> contactList = new List<clsAccreditationCompanyContactsInformation>();
                TExecuteReaderCmd<clsAccreditationCompanyContactsInformation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCompanyContactsInformation>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCompanyContactsInformation>();
        }
        public List<clsAccreditationCompanyContactsInformation> SelectAccreditationCompanyContactsInformationById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationCompanyContactsInformationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationCompanyContactsInformation> contactList = new List<clsAccreditationCompanyContactsInformation>();
                TExecuteReaderCmd<clsAccreditationCompanyContactsInformation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCompanyContactsInformation>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCompanyContactsInformation>();
        }  
        public List<clsAccreditationCompanyContactsInformation> SelectAccreditationCompanyContactsInformationByAccreditationId(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationCompanyContactsInformationByAccreditationId");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationCompanyContactsInformation> contactList = new List<clsAccreditationCompanyContactsInformation>();
                TExecuteReaderCmd<clsAccreditationCompanyContactsInformation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationCompanyContactsInformation>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationCompanyContactsInformation>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationCompanyContactsInformation> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationCompanyContactsInformation obj = new clsAccreditationCompanyContactsInformation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationId = returnData["accreditationId"] is DBNull ? (int)0 : (int)returnData["accreditationId"];
                    obj.countryCode = returnData["countryCode"] is DBNull ? (string)string.Empty : (string)returnData["countryCode"];
                    obj.contactNumber = returnData["contactNumber"] is DBNull ? (string)string.Empty : (string)returnData["contactNumber"];
                    obj.extentionNo = returnData["extentionNo"] is DBNull ? (string)string.Empty : (string)returnData["extentionNo"];
                    obj.contactNumberIsoCode = returnData["contactNumberIsoCode"] is DBNull ? (string)string.Empty : (string)returnData["contactNumberIsoCode"];
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
        public bool DeleteAccreditationCompanyContactsInformation(int accreditationId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)accreditationId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAccreditationCompanyContactsInformation", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
