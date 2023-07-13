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
  public  class clientContactPersonDAL : SQLDataAccess
    {
        public int InsertClientContactPersons(clsClientContactPersons ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonGroupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactPersonGroupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@salutationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.salutationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnFirstName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnFirstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnMiddleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnMiddleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnLastName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnLastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnCellNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForAuditReport", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForAuditReport ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForInvoice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForInvoice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForCAP", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForCAP ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForClientPortalAccess", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForClientPortalAccess ?? DBNull.Value);
             
                AddParamToSQLCmd(comm, "@isAccessAllowed", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isAccessAllowed ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.userId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.userPassword ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnCellNoIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.cntPrsnCellNoIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhoneIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.cntPrsnPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteBillingInfoId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.siteBillingInfoId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)ct.cntPrsnPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnAltEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnAltEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientDesignationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.clientDesignationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertClientContactPersons", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientContactPersons(clsClientContactPersons ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonGroupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactPersonGroupId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@salutationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.salutationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnFirstName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnFirstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnMiddleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnMiddleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnLastName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnLastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnCellNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnCellNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForAuditReport", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForAuditReport ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForInvoice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForInvoice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForCAP", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForCAP ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cmcForClientPortalAccess", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForClientPortalAccess ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@isAccessAllowed", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isAccessAllowed ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.userId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.userPassword ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnCellNoIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.cntPrsnCellNoIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhoneIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.cntPrsnPhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@siteBillingInfoId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.siteBillingInfoId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)ct.cntPrsnPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnAltEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnAltEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientDesignationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.clientDesignationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientContactPersons", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        } 
        public bool UpdateClientContactPersonsForReview(clsClientContactPersons ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clientId ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.clientSiteId ?? DBNull.Value);
             //   AddParamToSQLCmd(comm, "@contactPersonGroupId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactPersonGroupId ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@salutationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.salutationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnFirstName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnFirstName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnMiddleName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnMiddleName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnLastName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnLastName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhone", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnPhone ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnCellNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnCellNo ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@cmcForAuditReport", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForAuditReport ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@cmcForInvoice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForInvoice ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@cmcForCAP", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForCAP ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@cmcForClientPortalAccess", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.cmcForClientPortalAccess ?? DBNull.Value);

           //     AddParamToSQLCmd(comm, "@isAccessAllowed", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.isAccessAllowed ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@userId", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.userId ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@userPassword", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.userPassword ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@cntPrsnCellNoIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.cntPrsnCellNoIsoCode ?? DBNull.Value);
            //    AddParamToSQLCmd(comm, "@cntPrsnPhoneIsoCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.cntPrsnPhoneIsoCode ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@siteBillingInfoId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.siteBillingInfoId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnPhoneExt", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)ct.cntPrsnPhoneExt ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cntPrsnAltEmail", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.cntPrsnAltEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientDesignationName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.clientDesignationName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
           //     AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientContactPersonsForReview", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }  
        public bool UpdateActiveFalseById(int id,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateActiveFalseById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientContactPersons> SelectAllClientContactPersons(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientContactPersons");

                List<clsClientContactPersons> contactList = new List<clsClientContactPersons>();
                TExecuteReaderCmd<clsClientContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientContactPersons>();
        }
        public List<clsClientContactPersons> SelectClientContactPersonsById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientContactPersonsById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientContactPersons> contactList = new List<clsClientContactPersons>();
                TExecuteReaderCmd<clsClientContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientContactPersons>();
        } 
        public List<clsClientContactPersons> SelectClientContactPersonsByClient(int clientId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientContactPersonsByClient");
                comand.Parameters.AddWithValue("@clientId", clientId);
                List<clsClientContactPersons> contactList = new List<clsClientContactPersons>();
                TExecuteReaderCmd<clsClientContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientContactPersons>();
        } 
        public List<clsClientContactPersons> SelectClientContactPersonsByClientSite(int clientId,int clientSiteId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientContactPersonsByClientSite");
                comand.Parameters.AddWithValue("@clientId", clientId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsClientContactPersons> contactList = new List<clsClientContactPersons>();
                TExecuteReaderCmd<clsClientContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientContactPersons>();
        }      
        public List<clsClientContactPersons> SelectClientContactPersonsClientFinanceForSite(int clientId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientContactPersonsClientFinanceForSite");
                comand.Parameters.AddWithValue("@clientId", clientId);
                List<clsClientContactPersons> contactList = new List<clsClientContactPersons>();
                TExecuteReaderCmd<clsClientContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientContactPersons>();
        }
        public List<clsClientContactPersons> SelectClientContactPersonsBySiteBillingInfoId(int siteBillingInfoId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientContactPersonsBySiteBillingInfoId");
                comand.Parameters.AddWithValue("@siteBillingInfoId", siteBillingInfoId);
                List<clsClientContactPersons> contactList = new List<clsClientContactPersons>();
                TExecuteReaderCmd<clsClientContactPersons>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientContactPersons>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientContactPersons>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientContactPersons> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientContactPersons obj = new clsClientContactPersons();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.contactPersonGroupId = returnData["contactPersonGroupId"] is DBNull ? (int)0 : (int)returnData["contactPersonGroupId"];
                    obj.salutationName = returnData["salutationName"] is DBNull ? (string)string.Empty : (string)returnData["salutationName"];
                    obj.cntPrsnFirstName = returnData["cntPrsnFirstName"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnFirstName"];
                    obj.cntPrsnMiddleName = returnData["cntPrsnMiddleName"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnMiddleName"];
                    obj.cntPrsnLastName = returnData["cntPrsnLastName"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnLastName"];
                    obj.cntPrsnEmail= returnData["cntPrsnEmail"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnEmail"];
                    obj.cntPrsnPhone= returnData["cntPrsnPhone"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnPhone"];
                    obj.cntPrsnCellNo= returnData["cntPrsnCellNo"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnCellNo"];
                    obj.cmcForAuditReport= returnData["cmcForAuditReport"] is DBNull ? (bool)false : (bool)returnData["cmcForAuditReport"];
                    obj.cmcForInvoice= returnData["cmcForInvoice"] is DBNull ? (bool)false : (bool)returnData["cmcForInvoice"];
                    obj.cmcForCAP= returnData["cmcForCAP"] is DBNull ? (bool)false : (bool)returnData["cmcForCAP"];
                    obj.cmcForClientPortalAccess= returnData["cmcForClientPortalAccess"] is DBNull ? (bool)false : (bool)returnData["cmcForClientPortalAccess"];
                    
                    obj.isAccessAllowed = returnData["isAccessAllowed"] is DBNull ? (bool)true : (bool)returnData["isAccessAllowed"];
                    obj.userId = returnData["userId"] is DBNull ? (string)string.Empty : (string)returnData["userId"];
                    obj.userPassword = returnData["userPassword"] is DBNull ? (string)string.Empty : (string)returnData["userPassword"];
                    obj.cntPrsnCellNoIsoCode = returnData["cntPrsnCellNoIsoCode"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnCellNoIsoCode"];
                    obj.cntPrsnPhoneIsoCode = returnData["cntPrsnPhoneIsoCode"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnPhoneIsoCode"];
                    obj.siteBillingInfoId = returnData["siteBillingInfoId"] is DBNull ? (int) 0 : (int)returnData["siteBillingInfoId"];
                    obj.cntPrsnPhoneExt = returnData["cntPrsnPhoneExt"] is DBNull ? (string) string.Empty : (string)returnData["cntPrsnPhoneExt"];
                    obj.clientDesignationName = returnData["clientDesignationName"] is DBNull ? (string) string.Empty : (string)returnData["clientDesignationName"];
                    obj.cntPrsnAltEmail = returnData["cntPrsnAltEmail"] is DBNull ? (string) string.Empty : (string)returnData["cntPrsnAltEmail"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    if (ColumnExists(returnData, "cntPrsnGroupName"))
                    {
                        obj.cntPrsnGroupName = returnData["cntPrsnGroupName"] is DBNull ? (string)string.Empty : (string)returnData["cntPrsnGroupName"];
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
