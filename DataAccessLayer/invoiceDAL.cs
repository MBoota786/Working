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
   public class invoiceDAL : SQLDataAccess
    {
        public int InsertInvoice(clsInvoice obj)
        {

            int Id = 0;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Output);
                parameters.Add("@code", obj.code, DbType.String);
                parameters.Add("@applicationQuotationId", obj.applicationQuotationId, DbType.Int32);
                parameters.Add("@officeId", obj.officeId, DbType.Int32);
                parameters.Add("@payToOfficeId", obj.payToOfficeId, DbType.Int32);
                parameters.Add("@siteBillingInfoId", obj.siteBillingInfoId, DbType.Int32);
                parameters.Add("@invDate", obj.invDate, DbType.DateTime);
                parameters.Add("@invDueDate", obj.invDueDate, DbType.DateTime);
                parameters.Add("@invoiceTypeId", obj.invoiceTypeId, DbType.Int32);
                parameters.Add("@invoiceStatusId", obj.invoiceStatusId, DbType.Int32);
                parameters.Add("@invCheckBy", obj.invCheckBy, DbType.Int32);
                parameters.Add("@invApprovedBy", obj.invApprovedBy, DbType.Int32);
                parameters.Add("@invBankName", obj.invBankName, DbType.String);
                parameters.Add("@invBankAccount", obj.invBankAccount, DbType.String);
                parameters.Add("@invBankTitle", obj.invBankTitle, DbType.String);
                parameters.Add("@invBankIban", obj.invBankIban, DbType.String);
                parameters.Add("@invBankSwiftCode", obj.invBankSwiftCode, DbType.String);
                parameters.Add("@invBankSoftCode", obj.invBankSoftCode, DbType.String);
                parameters.Add("@invBankTransitNo", obj.invBankTransitNo, DbType.String);
                parameters.Add("@invBankAddress", obj.invBankAddress, DbType.String);
                parameters.Add("@invSentBy", obj.invSentBy, DbType.Int32);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                Id = DapperExecuteCmd("spInsertInvoice", obj.dbName, parameters, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateInvoice(clsInvoice obj)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@code", obj.code, DbType.String);
                parameters.Add("@applicationQuotationId", obj.applicationQuotationId, DbType.Int32);
                parameters.Add("@payToOfficeId", obj.payToOfficeId, DbType.Int32);
                parameters.Add("@siteBillingInfoId", obj.siteBillingInfoId, DbType.Int32);
                parameters.Add("@invDate", obj.invDate, DbType.DateTime);
                parameters.Add("@invDueDate", obj.invDueDate, DbType.DateTime);
                parameters.Add("@invoiceTypeId", obj.invoiceTypeId, DbType.Int32);
                parameters.Add("@invoiceStatusId", obj.invoiceStatusId, DbType.Int32);
                parameters.Add("@invCheckBy", obj.invCheckBy, DbType.Int32);
                parameters.Add("@invApprovedBy", obj.invApprovedBy, DbType.Int32);
                parameters.Add("@invBankName", obj.invBankName, DbType.String);
                parameters.Add("@invBankAccount", obj.invBankAccount, DbType.String);
                parameters.Add("@invBankTitle", obj.invBankTitle, DbType.String);
                parameters.Add("@invBankIban", obj.invBankIban, DbType.String);
                parameters.Add("@invBankSwiftCode", obj.invBankSwiftCode, DbType.String);
                parameters.Add("@invBankSoftCode", obj.invBankSoftCode, DbType.String);
                parameters.Add("@invBankTransitNo", obj.invBankTransitNo, DbType.String);
                parameters.Add("@invBankAddress", obj.invBankAddress, DbType.String);
                parameters.Add("@invSentBy", obj.invSentBy, DbType.Int32);
                parameters.Add("@modifiedBy", obj.modifiedBy, DbType.DateTime);
                parameters.Add("@modifiedOn", obj.modifiedOn, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                DapperExecuteCmd("spUpdateInvoice", obj.dbName, parameters, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsInvoice> SelectInvoiceByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@officeId", officeId, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsInvoice>("spSelectInvoiceByOfficeId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
        public List<clsInvoice> SelectInvoiceById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsInvoice>("spSelectInvoiceById", parameters, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

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
                return ExecuteReaderStringCode(cmd, "spGetInvoiceMaxCode", dbName);
            }
        }
    }
}
