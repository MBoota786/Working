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
   public class tariffTypeDAL : SQLDataAccess
    {
        public int InsertTariffType(clsTariffType obj)
        {

            int Id = 0;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32,ParameterDirection.Output);
                parameters.Add("@tariffTypeName", obj.tariffTypeName, DbType.String);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                Id = DapperExecuteCmd("spInsertTariffType", obj.dbName, parameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateTariffType(clsTariffType obj)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@tariffTypeName", obj.tariffTypeName, DbType.String);
                parameters.Add("@modifiedOn", obj.modifiedOn, DbType.DateTime);
                parameters.Add("@modifiedBy", obj.modifiedBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                DapperExecuteCmd("spUpdateTariffType", obj.dbName, parameters, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsTariffType> SelectAllTariffType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsTariffType>("spSelectAllTariffType").ToList();
                    con.Close();
                    return list.ToList();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return new List<clsTariffType>();
        }
        public List<clsTariffType> SelectTariffTypeById(int id,string dbName)
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
                    var list = con.Query<clsTariffType>("spSelectTariffTypeById",parameters,commandType:CommandType.StoredProcedure).ToList();
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
        //public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsTariffType> activeList)
        //{
        //    try
        //    {
        //        while (returnData.Read())
        //        {
        //            clsTariffType obj = new clsTariffType();
        //            obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
        //            obj.tariffTypeName = returnData["dayName"] is DBNull ? (string)string.Empty : (string)returnData["dayName"];
        //            obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
        //            obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
        //            activeList.Add(obj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
