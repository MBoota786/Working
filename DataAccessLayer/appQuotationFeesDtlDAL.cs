using Dapper;
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
   public class appQuotationFeesDtlDAL : SQLDataAccess
    {
        public int InsertAppQuotationFeesDtl(clsAppQuotationFeesDtl obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appQuotationFeesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appQuotationFeesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.finalRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculateFeeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.calculateFeeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalFeeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.finalFeeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppQuotationFeesDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppQuotationFeesDtl(clsAppQuotationFeesDtl obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appQuotationFeesId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appQuotationFeesId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardServiceFeeDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardServiceFeeDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalRate", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.finalRate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculateFeeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.calculateFeeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@finalFeeValue", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.finalFeeValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppQuotationFeesDtl", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppQuotationFeesDtl> SelectAllAppQuotationFeesDtl(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppQuotationFeesDtl");

                List<clsAppQuotationFeesDtl> adressList = new List<clsAppQuotationFeesDtl>();
                TExecuteReaderCmd<clsAppQuotationFeesDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFeesDtl>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFeesDtl>();
        }
        public List<clsAppQuotationFeesDtl> SelectAppQuotationFeesDtlById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationFeesDtlById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppQuotationFeesDtl> adressList = new List<clsAppQuotationFeesDtl>();
                TExecuteReaderCmd<clsAppQuotationFeesDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFeesDtl>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFeesDtl>();
        } 
        public List<clsAppQuotationFeesDtl> SelectAppQuotationFeesDtlByAppQuotationFeesId(int appQuotationFeesId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppQuotationFeesDtlByAppQuotationFeesId");
                comand.Parameters.AddWithValue("@appQuotationFeesId", appQuotationFeesId);
                List<clsAppQuotationFeesDtl> adressList = new List<clsAppQuotationFeesDtl>();
                TExecuteReaderCmd<clsAppQuotationFeesDtl>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppQuotationFeesDtl>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppQuotationFeesDtl>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppQuotationFeesDtl> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppQuotationFeesDtl obj = new clsAppQuotationFeesDtl();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appQuotationFeesId = returnData["appQuotationFeesId"] is DBNull ? (int)0 : (int)returnData["appQuotationFeesId"];
                    obj.standardServiceFeeDetailId = returnData["standardServiceFeeDetailId"] is DBNull ? (int)0 : (int)returnData["standardServiceFeeDetailId"];
                    obj.finalRate = returnData["finalRate"] is DBNull ? (decimal)0 : (decimal)returnData["finalRate"];
                    obj.calculateFeeValue = returnData["calculateFeeValue"] is DBNull ? (decimal)0 : (decimal)returnData["calculateFeeValue"];
                    obj.finalFeeValue = returnData["finalFeeValue"] is DBNull ? (decimal)0 : (decimal)returnData["finalFeeValue"];
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
        public List<clsAppQuotationFeesForPrint> SelectQuotationFeesForPrintByClientSiteIdAndQuotationId(int clientSiteId,int quotationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@clientSiteId", clientSiteId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@quotationId", quotationId, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsAppQuotationFeesForPrint>("spSelectQuotationFeesForPrintByClientSiteIdAndQuotationId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
        public List<clsAppQuotationFeesForPrint> SelectQuotationFeesTaxForPrintByClientSiteIdAndQuotationId(int clientSiteId,int quotationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@clientSiteId", clientSiteId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@quotationId", quotationId, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsAppQuotationFeesForPrint>("spSelectQuotationFeesTaxForPrintByClientSiteIdAndQuotationId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
