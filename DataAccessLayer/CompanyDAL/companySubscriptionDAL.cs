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
   public class companySubscriptionDAL : SQLDataAccess
    {
        public int InsertCompanySubscription(clsCompanySubscription obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionPlanId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.subscriptionPlanId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.companyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionStartDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.subscriptionStartDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionEndDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.subscriptionEndDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modeOfPaymentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modeOfPaymentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@transactionReference", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.transactionReference ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
              Id=  ExecuteInsertCommandReturnId(comm, "spInsertCompanySubscription", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCompanySubscription(clsCompanySubscription obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionPlanId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.subscriptionPlanId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.companyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionStartDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.subscriptionStartDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionEndDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.subscriptionEndDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modeOfPaymentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modeOfPaymentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@transactionReference", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.transactionReference ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateCompanySubscription", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsCompanySubscription> SelectAllCompanySubscription(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCompanySubscription");

                List<clsCompanySubscription> activeList = new List<clsCompanySubscription>();
                TExecuteReaderCmd<clsCompanySubscription>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCompanySubscription>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsCompanySubscription>();
        }
        public List<clsCompanySubscription> SelectCompanySubscriptionByCompanyId(int id,string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCompanySubscriptionByCompanyId");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCompanySubscription> activeList = new List<clsCompanySubscription>();
                TExecuteReaderCmd<clsCompanySubscription>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsCompanySubscription>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsCompanySubscription>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsCompanySubscription> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCompanySubscription obj = new clsCompanySubscription();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.subscriptionPlanId = returnData["subscriptionPlanId"] is DBNull ? (int)0 : (int)returnData["subscriptionPlanId"];
                    obj.subscriptionStartDate = returnData["subscriptionStartDate"] is DBNull ? (DateTime?)null : (DateTime?)returnData["subscriptionStartDate"];
                    obj.subscriptionEndDate = returnData["subscriptionEndDate"] is DBNull ? (DateTime?)null : (DateTime?)returnData["subscriptionEndDate"];
                    obj.modeOfPaymentId = returnData["modeOfPaymentId"] is DBNull ? (int) 0 : (int)returnData["modeOfPaymentId"];
                    obj.transactionReference = returnData["transactionReference"] is DBNull ? (string)string.Empty : (string)returnData["transactionReference"];
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
        public clsCompanySubscription CheckUserLimitAndOfficeLimitByCompanyId(int companyId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                clsCompanySubscription obj = new clsCompanySubscription();
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@companyId", companyId);
                SetCommandType(comand, CommandType.StoredProcedure, "spCheckUserLimitAndOfficeLimitByCompanyId");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {
                        if (returnData.Read())
                        {
                            obj.userLimit = returnData["noOfUser"] is DBNull ? (int)0 : (int)returnData["noOfUser"];
                            obj.officeLimit = returnData["noOfOffice"] is DBNull ? (int)0 : (int)returnData["noOfOffice"];

                        }

                    }

                    con.Close();

                    return obj;
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
