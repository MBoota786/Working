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
  public  class contactPersonsUsersDAL : SQLDataAccess
    {
        public int InsertContactPersonsUsers(clsContactPersonsUsers ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@salutationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.salutationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@firstName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.firstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@middleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.middleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@lastName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.lastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCellNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.designationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAccessAllowed", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isAccessAllowed ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userContactPersonId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.userContactPersonId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.userPassword ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.approvalStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.approvalBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cellNoIsoCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.cellNoIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)ct.contactPersonPhoneExt ?? DBNull.Value);

                Id = ExecuteInsertCommandReturnId(comm, "spInsertContactPersonsUsers", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateContactPersonsUsers(clsContactPersonsUsers ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@salutationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.salutationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@firstName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.firstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@middleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.middleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@lastName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.lastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonCellNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactPersonCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@designationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.designationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isAccessAllowed", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isAccessAllowed ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userContactPersonId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.userContactPersonId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.userPassword ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.approvalStatus ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.approvalBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@approvalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.approvalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cellNoIsoCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.cellNoIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)ct.contactPersonPhoneExt ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateContactPersonsUsers", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsContactPersonsUsers> SelectAllContactPersonsUsers(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllContactPersonsUsers");

                List<clsContactPersonsUsers> contactList = new List<clsContactPersonsUsers>();
                TExecuteReaderCmd<clsContactPersonsUsers>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsContactPersonsUsers>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsContactPersonsUsers>();
        }
        public List<clsContactPersonsUsers> SelectContactPersonsAndUsersById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectContactPersonsUsersById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsContactPersonsUsers> contactList = new List<clsContactPersonsUsers>();
                TExecuteReaderCmd<clsContactPersonsUsers>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsContactPersonsUsers>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsContactPersonsUsers>();
        }
        public List<clsContactPersonsUsers> SelectContactPersonsAndUsersByOfficeId(int officeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllContactPersonsUsersByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsContactPersonsUsers> contactList = new List<clsContactPersonsUsers>();
                TExecuteReaderCmd<clsContactPersonsUsers>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsContactPersonsUsers>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsContactPersonsUsers>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsContactPersonsUsers> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsContactPersonsUsers obj = new clsContactPersonsUsers();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
                    obj.contactTypeId = returnData["contactTypeid"] is DBNull ? (int)0 : (int)returnData["contactTypeid"];
                    obj.salutationName = returnData["salutationName"] is DBNull ? (string)string.Empty : (string)returnData["salutationName"];
                    obj.firstName = returnData["firstName"] is DBNull ? (string)string.Empty : (string)returnData["firstName"];
                    obj.middleName = returnData["middleName"] is DBNull ? (string)string.Empty : (string)returnData["middleName"];
                    obj.lastName = returnData["lastName"] is DBNull ? (string)string.Empty : (string)returnData["lastName"];
                    obj.designationId = returnData["designationId"] is DBNull ? (int)0 : (int)returnData["designationId"];
                    obj.designationName = returnData["designationName"] is DBNull ? (string)string.Empty : (string)returnData["designationName"];
                    obj.isAccessAllowed = returnData["isAccessAllowed"] is DBNull ? (bool)true : (bool)returnData["isAccessAllowed"];
                    obj.userContactPersonId = returnData["userContactPersonId"] is DBNull ? (int) 0 : (int)returnData["userContactPersonId"];
                    obj.userPassword = returnData["userPassword"] is DBNull ? (string)string.Empty : (string)returnData["userPassword"];
                    obj.approvalStatus = returnData["approvalStatus"] is DBNull ? (string)string.Empty : (string)returnData["approvalStatus"];
                    obj.approvalBy = returnData["approvalBy"] is DBNull ? (int)0 : (int)returnData["approvalBy"];
                    obj.approvalDate = returnData["approvalDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["approvalDate"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    if (ColumnExists(returnData, "contactPersonEmail"))
                    {
                        obj.contactPersonEmail = returnData["contactPersonEmail"] is DBNull ? (string)string.Empty : (string)returnData["contactPersonEmail"];
                    }
                    if (ColumnExists(returnData, "contactPersonCellNo"))
                    {
                        obj.contactPersonCellNo = returnData["contactPersonCellNo"] is DBNull ? (string)string.Empty : (string)returnData["contactPersonCellNo"];
                    }
                    if (ColumnExists(returnData, "cellNoIsoCode"))
                    {
                        obj.cellNoIsoCode = returnData["cellNoIsoCode"] is DBNull ? (string)string.Empty : (string)returnData["cellNoIsoCode"];
                    }
                    if (ColumnExists(returnData, "contactPersonPhoneExt"))
                    {
                        obj.contactPersonPhoneExt = returnData["contactPersonPhoneExt"] is DBNull ? (string)string.Empty : (string)returnData["contactPersonPhoneExt"];
                    }
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
