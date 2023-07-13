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
   public class applicationQuotationDAL : SQLDataAccess
    {
        public int InsertApplicationQuotation(clsApplicationQuotation obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.quotationNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isQuotationApprovedLocalOffice", SqlDbType.Bit , 1, ParameterDirection.Input, (object)obj.isQuotationApprovedLocalOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationApprovalDate", SqlDbType.DateTime , 20, ParameterDirection.Input, (object)obj.quotationApprovalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationApprovalBy", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.quotationApprovalBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentToEmail", SqlDbType.Bit , 4, ParameterDirection.Input, (object)obj.quotationSentToEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentToPersonId", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.quotationSentToPersonId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationStatusId", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.quotationStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadQuotationPath", SqlDbType.NVarChar , 250, ParameterDirection.Input, (object)obj.uploadQuotationPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationPaymentStatusId", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.quotationPaymentStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationPaymentTermId", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.quotationPaymentTermId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationDate", SqlDbType.DateTime , 20, ParameterDirection.Input, (object)obj.quotationDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationValidityUpto", SqlDbType.DateTime , 20, ParameterDirection.Input, (object)obj.quotationValidityUpto ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentByUserId", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.quotationSentByUserId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertApplicationQuotation", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateApplicationQuotation(clsApplicationQuotation obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.quotationNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isQuotationApprovedLocalOffice", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isQuotationApprovedLocalOffice ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationApprovalDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.quotationApprovalDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationApprovalBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationApprovalBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentToEmail", SqlDbType.Bit, 4, ParameterDirection.Input, (object)obj.quotationSentToEmail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentToPersonId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationSentToPersonId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@uploadQuotationPath", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.uploadQuotationPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationPaymentStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationPaymentStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationPaymentTermId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationPaymentTermId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.quotationDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationValidityUpto", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.quotationValidityUpto ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@quotationSentByUserId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.quotationSentByUserId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateApplicationQuotation", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool spDeleteQuotationById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteQuotationById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsApplicationQuotation> SelectAllApplicationQuotation(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllApplicationQuotation");

                List<clsApplicationQuotation> activeList = new List<clsApplicationQuotation>();
                TExecuteReaderCmd<clsApplicationQuotation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationQuotation>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationQuotation>();
        }
        public List<clsApplicationQuotation> SelectApplicationQuotationById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationQuotationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsApplicationQuotation> activeList = new List<clsApplicationQuotation>();
                TExecuteReaderCmd<clsApplicationQuotation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationQuotation>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationQuotation>();
        }
        public List<clsApplicationQuotation> SelectApplicationQuotationByAppIdClientSiteId(int appId , int clientId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectApplicationQuotationByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientId", clientId);
                List<clsApplicationQuotation> activeList = new List<clsApplicationQuotation>();
                TExecuteReaderCmd<clsApplicationQuotation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsApplicationQuotation>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsApplicationQuotation>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsApplicationQuotation> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsApplicationQuotation obj = new clsApplicationQuotation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientId = returnData["clientId"] is DBNull ? (int)0 : (int)returnData["clientId"];
                    obj.quotationNo = returnData["quotationNo"] is DBNull ? (string)string.Empty : (string)returnData["quotationNo"];
                    obj.isQuotationApprovedLocalOffice = returnData["isQuotationApprovedLocalOffice"] is DBNull ? (bool) false: (bool)returnData["isQuotationApprovedLocalOffice"];
                    obj.quotationApprovalDate = returnData["quotationApprovalDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["quotationApprovalDate"];
                    obj.quotationApprovalBy = returnData["quotationApprovalBy"] is DBNull ? (int)0 : (int)returnData["quotationApprovalBy"];
                    obj.quotationSentToEmail = returnData["quotationSentToEmail"] is DBNull ? (bool)false : (bool)returnData["quotationSentToEmail"];
                    obj.quotationSentToPersonId = returnData["quotationSentToPersonId"] is DBNull ? (int) 0 : (int)returnData["quotationSentToPersonId"];
                    obj.quotationStatusId = returnData["quotationStatusId"] is DBNull ? (int)0 : (int)returnData["quotationStatusId"];
                    obj.uploadQuotationPath = returnData["uploadQuotationPath"] is DBNull ? (string)string.Empty : (string)returnData["uploadQuotationPath"];
                    obj.quotationPaymentStatusId = returnData["quotationPaymentStatusId"] is DBNull ? (int) 0 : (int)returnData["quotationPaymentStatusId"];
                    obj.quotationPaymentTermId = returnData["quotationPaymentTermId"] is DBNull ? (int) 0 : (int)returnData["quotationPaymentTermId"];
                    obj.quotationDate = returnData["quotationDate"] is DBNull ? (DateTime?)null : (DateTime)returnData["quotationDate"];
                    obj.quotationValidityUpto = returnData["quotationValidityUpto"] is DBNull ? (DateTime?)null : (DateTime)returnData["quotationValidityUpto"];
                    obj.quotationSentByUserId = returnData["quotationSentByUserId"] is DBNull ? (int)0 : (int)returnData["quotationSentByUserId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int) 0 : (int)returnData["officeId"];
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

        public List<clsApplicationQuotationList> SelectQuotationApplicationForListByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectQuotationApplicationForListByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsApplicationQuotationList> activeList = new List<clsApplicationQuotationList>();
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            clsApplicationQuotationList obj = new clsApplicationQuotationList();
                            obj.id = reader["id"] is DBNull ? (int)0 : (int)reader["id"];
                            obj.appId = reader["appId"] is DBNull ? (int)0 : (int)reader["appId"];
                            obj.appCode = reader["appCode"] is DBNull ? (string)string.Empty : (string)reader["appCode"];
                            obj.quotationNo = reader["quotationNo"] is DBNull ? (string)string.Empty : (string)reader["quotationNo"];
                            obj.clientId = reader["clientId"] is DBNull ? (int)0 : (int)reader["clientId"];
                            obj.officeId = reader["officeId"] is DBNull ? (int)0 : (int)reader["officeId"];
                            obj.clientCompanyName = reader["clientCompanyName"] is DBNull ? (string)string.Empty : (string)reader["clientCompanyName"];
                            obj.siteName = reader["siteName"] is DBNull ? (string)string.Empty : (string)reader["siteName"];
                            obj.appCertificationStatus = reader["appCertificationStatus"] is DBNull ? (string)string.Empty : (string)reader["appCertificationStatus"];
                            obj.quotationStatusName = reader["quotationStatusName"] is DBNull ? (string)string.Empty : (string)reader["quotationStatusName"];
                            obj.officeName = reader["officeName"] is DBNull ? (string)string.Empty : (string)reader["officeName"];
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
            return new List<clsApplicationQuotationList>();
        }
        public string GetMaxCode(string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                return ExecuteReaderStringCode(cmd, "spGetQuotationMaxCode", dbName);
            }
        }
    }
}
