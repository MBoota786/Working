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
  public  class accreditationOfficeContactPersonsDAL : SQLDataAccess
    {
        public int InsertAccreditationOfficeContactPersons(clsAccreditationOfficeContactPersons ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactPersonCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@salutationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.salutationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@firstName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.firstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@middleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.middleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@lastName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.lastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCellNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.designationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhoneIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactPersonPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCellNoIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactPersonCellNoIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhoneExt", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactPersonPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationOfficeContactPersons", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationOfficeContactPersons(clsAccreditationOfficeContactPersons ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactPersonCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@salutationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.salutationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@firstName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.firstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@middleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.middleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@lastName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.lastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCellNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.designationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhoneIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactPersonPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCellNoIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactPersonCellNoIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhoneExt", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.contactPersonPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationOfficeContactPersons", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationOfficeContactPersons> SelectAllAccreditationOfficeContactPersons(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationOfficeContactPersons");

                List<clsAccreditationOfficeContactPersons> contactList = new List<clsAccreditationOfficeContactPersons>();
                TExecuteReaderCmd<clsAccreditationOfficeContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationOfficeContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationOfficeContactPersons>();
        }
        public List<clsAccreditationOfficeContactPersons> SelectAccreditationOfficeContactPersonsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationOfficeContactPersonsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationOfficeContactPersons> contactList = new List<clsAccreditationOfficeContactPersons>();
                TExecuteReaderCmd<clsAccreditationOfficeContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationOfficeContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationOfficeContactPersons>();
        } 
        public List<clsAccreditationOfficeContactPersons> SelectAccreditationOfficeContactPersonsByAccreditationId(int accreditationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationOfficeContactPersonsByAccreditationId");
                comand.Parameters.AddWithValue("@accreditationId", accreditationId);
                List<clsAccreditationOfficeContactPersons> contactList = new List<clsAccreditationOfficeContactPersons>();
                TExecuteReaderCmd<clsAccreditationOfficeContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationOfficeContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationOfficeContactPersons>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationOfficeContactPersons> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationOfficeContactPersons obj = new clsAccreditationOfficeContactPersons();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationId = returnData["accreditationId"] is DBNull ? (int)0 : (int)returnData["accreditationId"];
                    obj.contactPersonCategoryId = returnData["contactPersonCategoryId"] is DBNull ? (int)0 : (int)returnData["contactPersonCategoryId"];
                    obj.salutationName = returnData["salutationName"] is DBNull ? (string)string.Empty : (string)returnData["salutationName"];
                    obj.firstName = returnData["firstName"] is DBNull ? (string)string.Empty : (string)returnData["firstName"];
                    obj.middleName = returnData["middleName"] is DBNull ? (string)string.Empty : (string)returnData["middleName"];
                    obj.lastName = returnData["lastName"] is DBNull ? (string)string.Empty : (string)returnData["lastName"];
                    obj.designationId = returnData["designationId"] is DBNull ? (int)0 : (int)returnData["designationId"];
                    obj.contactPersonEmail = returnData["contactPersonEmail"] is DBNull ? (string) string.Empty : (string)returnData["contactPersonEmail"];
                    obj.contactPersonPhone = returnData["contactPersonPhone"] is DBNull ? (string) string.Empty : (string)returnData["contactPersonPhone"];
                    obj.contactPersonCellNo = returnData["contactPersonCellNo"] is DBNull ? (string) string.Empty : (string)returnData["contactPersonCellNo"];
                    obj.contactPersonPhoneIsoCode = returnData["contactPersonPhoneIsoCode"] is DBNull ? (string) string.Empty : (string)returnData["contactPersonPhoneIsoCode"];
                    obj.contactPersonCellNoIsoCode = returnData["contactPersonCellNoIsoCode"] is DBNull ? (string) string.Empty : (string)returnData["contactPersonCellNoIsoCode"];
                    obj.contactPersonPhoneExt = returnData["contactPersonPhoneExt"] is DBNull ? (string) string.Empty : (string)returnData["contactPersonPhoneExt"];
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
        public bool ActiveFalseForDeletetblAccreditationOfficeContactPersonsById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spActiveFalseForDeletetblAccreditationOfficeContactPersonsById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
