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
   public class leadCompanyCreditCardDetailDAL : SQLDataAccess
    {
        public int InsertLeadCompanyCreditCardDetail(clsLeadCompanyCreditCardDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadCompanyId ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@nameOnCard", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.nameOnCard ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@creditCardNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.creditCardNumber ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@expMonth", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)obj.expMonth ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@expYear", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.expYear ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@cvv", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.cvv ?? DBNull.Value);
               AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
               Id = ExecuteInsertCommandReturnId(comm, "spInsertLeadCompanyCreditCardDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateLeadCompanyCreditCardDetail(clsLeadCompanyCreditCardDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@leadCompanyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.leadCompanyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@nameOnCard", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.nameOnCard ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@creditCardNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.creditCardNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@expMonth", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)obj.expMonth ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@expYear", SqlDbType.NVarChar, 5, ParameterDirection.Input, (object)obj.expYear ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateLeadCompanyCreditCardDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsLeadCompanyCreditCardDetail> SelectAllLeadCompanyCreditCardDetail(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllLeadCompanyCreditCardDetail");

                List<clsLeadCompanyCreditCardDetail> activeList = new List<clsLeadCompanyCreditCardDetail>();
                TExecuteReaderCmd<clsLeadCompanyCreditCardDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLeadCompanyCreditCardDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsLeadCompanyCreditCardDetail>();
        }
        public List<clsLeadCompanyCreditCardDetail> spSelectLeadCompanyCreditCardDetailByLeadCompanyId(int leadCompanyId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectLeadCompanyCreditCardDetailByLeadCompanyId");
                comand.Parameters.AddWithValue("@leadCompanyId", leadCompanyId);
                List<clsLeadCompanyCreditCardDetail> activeList = new List<clsLeadCompanyCreditCardDetail>();
                TExecuteReaderCmd<clsLeadCompanyCreditCardDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsLeadCompanyCreditCardDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsLeadCompanyCreditCardDetail>();
        }
     
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsLeadCompanyCreditCardDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsLeadCompanyCreditCardDetail obj = new clsLeadCompanyCreditCardDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.leadCompanyId = returnData["leadCompanyId"] is DBNull ? (int)0 : (int)returnData["leadCompanyId"];
                    obj.nameOnCard = returnData["nameOnCard"] is DBNull ? (string) string.Empty : (string)returnData["nameOnCard"];
                    obj.creditCardNumber = returnData["creditCardNumber"] is DBNull ? (string) string.Empty : (string)returnData["creditCardNumber"];
                    obj.expMonth = returnData["expMonth"] is DBNull ? (string) string.Empty : (string)returnData["expMonth"];
                    obj.expYear= returnData["expYear"] is DBNull ? (string) string.Empty : (string)returnData["expYear"];
                    obj.cvv = returnData["cvv"] is DBNull ? (string) string.Empty : (string)returnData["cvv"];
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
    }
}
