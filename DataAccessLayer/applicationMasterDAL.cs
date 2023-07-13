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
   public class applicationMasterDAL : SQLDataAccess
    {
        public int InsertApplicationMaster(clsApplicationMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.appCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reportWrapId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reportWrapId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@certificationScope", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.certificationScope ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isCombineQuotation", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCombineQuotation ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@serviceAcquired", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceAcquired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nextAuditDue", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.nextAuditDue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appCertificationStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appCertificationStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForwardFromOtherOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isForwardFromOtherOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationFromOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationFromOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyerRequest", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyerRequest ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buyerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.buyerId ?? DBNull.Value);              
                AddParamToSQLCmd(comm, "@isSponsored", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSponsored ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonSponsoredId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contactPersonSponsoredId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@primarySecondaryProcess", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.primarySecondaryProcess ?? DBNull.Value);
               
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertApplicationMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateApplicationMaster(clsApplicationMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.appCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reportWrapId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.reportWrapId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@certificationScope", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.certificationScope ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isCombineQuotation", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCombineQuotation ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@serviceAcquired", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.serviceAcquired ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nextAuditDue", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.nextAuditDue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appCertificationStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appCertificationStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isForwardFromOtherOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isForwardFromOtherOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationFromOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationFromOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyerRequest", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyerRequest ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@buyerId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.buyerId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSponsored", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSponsored ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactPersonSponsoredId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contactPersonSponsoredId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@primarySecondaryProcess", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.primarySecondaryProcess ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateApplicationMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateApplicationMasterScopeAndProcess(clsApplicationMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@certificationScope", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.certificationScope ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@primarySecondaryProcess", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.primarySecondaryProcess ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isSiteEngagedWithConsultant", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isSiteEngagedWithConsultant ?? DBNull.Value);
               ExecuteNonQueryCommand(comm, "spUpdateApplicationMasterScopeAndProcess", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateApplicationMasterAppCertificationStatusById(int id,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                 ExecuteNonQueryCommand(comm, "spUpdateApplicationMasterAppCertificationStatusById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsApplicationMaster> SelectAllApplicationMaster(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllApplicationMaster");

                List<clsApplicationMaster> activeList = new List<clsApplicationMaster>();
                TExecuteReaderCmd<clsApplicationMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationMaster>();
        }
        public List<clsApplicationMaster> SelectApplicationMasterById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsApplicationMaster> activeList = new List<clsApplicationMaster>();
                TExecuteReaderCmd<clsApplicationMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationMaster>();
        } 
        public List<clsApplicationMaster> SelectApplicationMasterByOfficeIdAndClientId(int officeId,int clientId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationMasterByOfficeIdAndClientId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                comand.Parameters.AddWithValue("@clientId", clientId);
                List<clsApplicationMaster> activeList = new List<clsApplicationMaster>();
                TExecuteReaderCmd<clsApplicationMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationMaster>();
        }   
        public List<clsApplicationMaster> SelectApplicationForListView(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationForListView");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsApplicationMaster> activeList = new List<clsApplicationMaster>();
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            clsApplicationMaster obj = new clsApplicationMaster();
                            obj.id = reader["id"] is DBNull ? (int)0 : (int)reader["id"];
                            obj.rowNumber = reader["rowNumber"] is DBNull ? (int)0 : (int)reader["rowNumber"];
                            obj.appCode = reader["appCode"] is DBNull ? (string)string.Empty : (string)reader["appCode"];
                            obj.clientId = reader["clientId"] is DBNull ? (int)0 : (int)reader["clientId"];
                            obj.officeId = reader["officeId"] is DBNull ? (int)0 : (int)reader["officeId"];
                            obj.clientCompanyName = reader["clientCompanyName"] is DBNull ? (string)string.Empty : (string)reader["clientCompanyName"];
                            obj.siteName = reader["siteName"] is DBNull ? (string)string.Empty : (string)reader["siteName"];
                            obj.perShow = reader["perShow"] is DBNull ? (string)string.Empty : (string)reader["perShow"];
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
            return new List<clsApplicationMaster>();
        }
        public List<clsApplicationMaster> SelectApplicationForReViewList(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationForReViewList");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsApplicationMaster> activeList = new List<clsApplicationMaster>();
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            clsApplicationMaster obj = new clsApplicationMaster();
                            obj.id = reader["id"] is DBNull ? (int)0 : (int)reader["id"];
                            obj.rowNumber = reader["rowNumber"] is DBNull ? (int)0 : (int)reader["rowNumber"];
                            obj.appCode = reader["appCode"] is DBNull ? (string)string.Empty : (string)reader["appCode"];
                            obj.clientId = reader["clientId"] is DBNull ? (int)0 : (int)reader["clientId"];
                            obj.officeId = reader["officeId"] is DBNull ? (int)0 : (int)reader["officeId"];
                            obj.clientCompanyName = reader["clientCompanyName"] is DBNull ? (string)string.Empty : (string)reader["clientCompanyName"];
                            obj.siteName = reader["siteName"] is DBNull ? (string)string.Empty : (string)reader["siteName"];
                            obj.perShow = reader["perShow"] is DBNull ? (string)string.Empty : (string)reader["perShow"];
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
            return new List<clsApplicationMaster>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsApplicationMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsApplicationMaster obj = new clsApplicationMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appCode = returnData["appCode"] is DBNull ? (string) string.Empty: (string)returnData["appCode"];
                    obj.clientId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.isEmailSent = returnData["isEmailSent"] is DBNull ? (bool)false : (bool)returnData["isEmailSent"];
                    obj.reportWrapId = returnData["reportWrapId"] is DBNull ? (int)0 : (int)returnData["reportWrapId"];
                    obj.certificationScope = returnData["certificationScope"] is DBNull ? (string)string.Empty : (string)returnData["certificationScope"];
                    obj.isCombineQuotation = returnData["isCombineQuotation"] is DBNull ? (bool)false: (bool)returnData["isCombineQuotation"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int) 0 : (int)returnData["officeId"];

                    obj.serviceAcquired = returnData["serviceAcquired"] is DBNull ? (string) string.Empty : (string)returnData["serviceAcquired"];
                    obj.nextAuditDue = returnData["nextAuditDue"] is DBNull ? (DateTime?)null : (DateTime)returnData["nextAuditDue"];
                    obj.appCertificationStatusId = returnData["appCertificationStatusId"] is DBNull ? (int)0 : (int)returnData["appCertificationStatusId"];
                    obj.isForwardFromOtherOffice = returnData["isForwardFromOtherOffice"] is DBNull ? (bool)false : (bool)returnData["isForwardFromOtherOffice"];
                    obj.applicationFromOfficeId = returnData["applicationFromOfficeId"] is DBNull ? (int)0 : (int)returnData["applicationFromOfficeId"];
                    obj.isBuyerRequest = returnData["isBuyerRequest"] is DBNull ? (bool)false : (bool)returnData["isBuyerRequest"];
                    obj.buyerId = returnData["buyerId"] is DBNull ? (int)0 : (int)returnData["buyerId"];
                    obj.isSponsored = returnData["isSponsored"] is DBNull ? (bool)false : (bool)returnData["isSponsored"];
                    obj.contactPersonSponsoredId = returnData["contactPersonSponsoredId"] is DBNull ? (int)0 : (int)returnData["contactPersonSponsoredId"];
                    obj.primarySecondaryProcess = returnData["primarySecondaryProcess"] is DBNull ? (string) string.Empty : (string)returnData["primarySecondaryProcess"];
                    obj.isSiteEngagedWithConsultant = returnData["isSiteEngagedWithConsultant"] is DBNull ? (bool)false : (bool)returnData["isSiteEngagedWithConsultant"];

                    obj.active = returnData["active"] is DBNull ? (bool)false : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GetMaxCode(string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                return ExecuteReaderStringCode(cmd, "spGetApplicationMasterMaxCode", dbName);
            }
        }
    }
}
