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
   public class subscriptionPlanDAL : SQLDataAccess
    {
        public int InsertSubscriptionPlan(clsSubscriptionPlan obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@packageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.packageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.subscriptionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.totalAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentTermId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentTermId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.subscriptionAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isFeatured", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isFeatured ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@featuredTitle", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.featuredTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertSubscriptionPlan", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateSubscriptionPlan(clsSubscriptionPlan obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@packageId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.packageId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.subscriptionTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@totalAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.totalAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentTermId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.paymentTermId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@subscriptionAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.subscriptionAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isFeatured", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isFeatured ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@featuredTitle", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.featuredTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateSubscriptionPlan", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsSubscriptionPlan> SelectAllSubscriptionPlan(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllSubscriptionPlan");
                SetDBName(dbName);
                List<clsSubscriptionPlan> activeList = new List<clsSubscriptionPlan>();
                TExecuteReaderCmd<clsSubscriptionPlan>(comand, TGenerateSOFieldFromReaderactiveSubscriptionPackage<clsSubscriptionPlan>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSubscriptionPlan>();
        }
        public List<clsSubscriptionPlan> SelectSubscriptionPlanById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectSubscriptionPlanById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsSubscriptionPlan> activeList = new List<clsSubscriptionPlan>();
                TExecuteReaderCmd<clsSubscriptionPlan>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsSubscriptionPlan>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsSubscriptionPlan>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsSubscriptionPlan> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSubscriptionPlan obj = new clsSubscriptionPlan();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.packageId = returnData["packageId"] is DBNull ? (int)0 : (int)returnData["packageId"];
                    obj.subscriptionTypeId = returnData["subscriptionTypeId"] is DBNull ? (int)0 : (int)returnData["subscriptionTypeId"];
                    obj.currencyId = returnData["currencyId"] is DBNull ? (int)0 : (int)returnData["currencyId"];
                    obj.totalAmount = returnData["totalAmount"] is DBNull ? (decimal)0 : (decimal)returnData["totalAmount"];
                    obj.paymentTermId = returnData["paymentTermId"] is DBNull ? (int)0 : (int)returnData["paymentTermId"];
                    obj.subscriptionAmount = returnData["subscriptionAmount"] is DBNull ? (decimal)0 : (decimal)returnData["subscriptionAmount"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    obj.featuredTitle = returnData["featuredTitle"] is DBNull ? (string)string.Empty : (string)returnData["featuredTitle"];
                    obj.isFeatured = returnData["isFeatured"] is DBNull ? (bool)true : (bool)returnData["isFeatured"];
                    //Subs For Front Show
                    if (ColumnExists(returnData,"packageName"))
                    {
                        obj.packageName = returnData["packageName"] is DBNull ? (string)string.Empty : (string)returnData["packageName"];
                    }
                    if (ColumnExists(returnData, "packageName"))
                    {
                        obj.timePeriodUnit = returnData["packageName"] is DBNull ? (string)string.Empty : (string)returnData["packageName"];
                    }
                    if (ColumnExists(returnData, "noOfUser"))
                    {
                        obj.noOfUser = returnData["noOfUser"] is DBNull ? (int)0 : (int)returnData["noOfUser"];
                    }
                    if (ColumnExists(returnData, "noOfOffice"))
                    {
                        obj.noOfOffice = returnData["noOfOffice"] is DBNull ? (int)0 : (int)returnData["noOfOffice"];
                    }
                    if (ColumnExists(returnData, "noOfStandard"))
                    {
                        obj.noOfStandard = returnData["noOfStandard"] is DBNull ? (int)0 : (int)returnData["noOfStandard"];
                    }
                    activeList.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void TGenerateSOFieldFromReaderactiveSubscriptionPackage<T>(SqlDataReader returnData, ref List<clsSubscriptionPlan> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsSubscriptionPlan obj = new clsSubscriptionPlan();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.packageId = returnData["packageId"] is DBNull ? (int)0 : (int)returnData["packageId"];
                    obj.currencyId = returnData["currencyId"] is DBNull ? (int)0 : (int)returnData["currencyId"];
                    obj.totalAmount = returnData["totalAmount"] is DBNull ? (decimal)0 : (decimal)returnData["totalAmount"];
                    obj.paymentTermId = returnData["paymentTermId"] is DBNull ? (int)0 : (int)returnData["paymentTermId"];
                    obj.subscriptionAmount = returnData["subscriptionAmount"] is DBNull ? (decimal)0 : (decimal)returnData["subscriptionAmount"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    obj.packageName = returnData["packageName"] is DBNull ? (string)string.Empty : (string)returnData["packageName"];
                    obj.timePeriodUnit = returnData["timePeriodUnit"] is DBNull ? (string)string.Empty : (string)returnData["timePeriodUnit"];
                    obj.noOfUser = returnData["noOfUser"] is DBNull ? (int)0 : (int)returnData["noOfUser"];
                    obj.noOfOffice = returnData["noOfOffice"] is DBNull ? (int)0 : (int)returnData["noOfOffice"];
                    obj.noOfStandard = returnData["noOfStandard"] is DBNull ? (int)0 : (int)returnData["noOfStandard"];
                    obj.subscriptionDuration = returnData["subscriptionDuration"] is DBNull ? (int)0 : (int)returnData["subscriptionDuration"];
                    obj.paymentTerm = returnData["paymentTerm"] is DBNull ? (string)string.Empty : (string)returnData["paymentTerm"];
                    obj.currencyName = returnData["currencyName"] is DBNull ? (string)string.Empty : (string)returnData["currencyName"];
                    obj.currencySymbol = returnData["symbol"] is DBNull ? (string)string.Empty : (string)returnData["symbol"];
                    obj.featuredTitle = returnData["featuredTitle"] is DBNull ? (string)string.Empty : (string)returnData["featuredTitle"];
                    obj.isFeatured = returnData["isFeatured"] is DBNull ? (bool)true : (bool)returnData["isFeatured"];

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
