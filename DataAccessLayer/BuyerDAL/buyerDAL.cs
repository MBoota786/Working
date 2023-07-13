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
   public class buyerDAL : SQLDataAccess
    {
        public int InsertBuyer(clsBuyer obj)
        {

            int Id = 0;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32,ParameterDirection.Output);
                parameters.Add("@code", obj.code, DbType.String);
                parameters.Add("@buyerOfficeTypeId", obj.buyerOfficeTypeId, DbType.Int32);
                parameters.Add("@buyerCompanyName", obj.buyerCompanyName, DbType.String);
                parameters.Add("@buyerAddressLine1", obj.buyerAddressLine1, DbType.String);
                parameters.Add("@buyerAddressLine2", obj.buyerAddressLine2, DbType.String);
                parameters.Add("@buyerAddressLine3", obj.buyerAddressLine3, DbType.String);
                parameters.Add("@countryId", obj.countryId, DbType.Int32);
                parameters.Add("@stateProvinceId", obj.stateProvinceId, DbType.Int32);
                parameters.Add("@cityId", obj.cityId, DbType.Int32);
                parameters.Add("@buyerPostalCode", obj.buyerPostalCode, DbType.String);
                parameters.Add("@buyerPhone", obj.buyerPhone, DbType.String);
                parameters.Add("@phoneExt", obj.phoneExt, DbType.String);
                parameters.Add("@buyerCell", obj.buyerCell, DbType.String);
                parameters.Add("@buyerEmail", obj.buyerEmail, DbType.String);
                parameters.Add("@buyerWebsite", obj.buyerWebsite, DbType.String);
                parameters.Add("@buyerVatNo", obj.buyerVatNo, DbType.String);
                parameters.Add("@businessTypeId", obj.businessTypeId, DbType.Int32);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                Id = DapperExecuteCmd("spInsertBuyer", obj.dbName, parameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateBuyer(clsBuyer obj)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@code", obj.code, DbType.String);
                parameters.Add("@buyerOfficeTypeId", obj.buyerOfficeTypeId, DbType.Int32);
                parameters.Add("@buyerCompanyName", obj.buyerCompanyName, DbType.String);
                parameters.Add("@buyerAddressLine1", obj.buyerAddressLine1, DbType.String);
                parameters.Add("@buyerAddressLine2", obj.buyerAddressLine2, DbType.String);
                parameters.Add("@buyerAddressLine3", obj.buyerAddressLine3, DbType.String);
                parameters.Add("@countryId", obj.countryId, DbType.Int32);
                parameters.Add("@stateProvinceId", obj.stateProvinceId, DbType.Int32);
                parameters.Add("@cityId", obj.cityId, DbType.Int32);
                parameters.Add("@buyerPostalCode", obj.buyerPostalCode, DbType.String);
                parameters.Add("@buyerPhone", obj.buyerPhone, DbType.String);
                parameters.Add("@phoneExt", obj.phoneExt, DbType.String);
                parameters.Add("@buyerCell", obj.buyerCell, DbType.String);
                parameters.Add("@buyerEmail", obj.buyerEmail, DbType.String);
                parameters.Add("@buyerWebsite", obj.buyerWebsite, DbType.String);
                parameters.Add("@buyerVatNo", obj.buyerVatNo, DbType.String);
                parameters.Add("@businessTypeId", obj.businessTypeId, DbType.Int32);
                parameters.Add("@modifiedOn", obj.modifiedOn, DbType.DateTime);
                parameters.Add("@modifiedBy", obj.modifiedBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                DapperExecuteCmd("spUpdateBuyer", obj.dbName, parameters, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsBuyer> SelectAllBuyer(string dbName)
        {
            try
            {
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsBuyer>("spSelectAllBuyer").ToList();
                    con.Close();
                    return list.ToList();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return new List<clsBuyer>();
        }
        public List<clsBuyer> SelectBuyerById(int id,string dbName)
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
                    var list = con.Query<clsBuyer>("spSelectBuyerById", parameters,commandType:CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          //  return null;
        }
        public List<clsBuyer> SelectBuyerByBuyerOfficeTypeId(int buyerOfficeTypeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@buyerOfficeTypeId", buyerOfficeTypeId, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsBuyer>("spSelectBuyerByBuyerOfficeTypeId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //  return null;
        }
        public string GetMaxCode(string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                return ExecuteReaderStringCode(cmd, "spGetBuyerMaxCode", dbName);
            }
        }
    }
}
