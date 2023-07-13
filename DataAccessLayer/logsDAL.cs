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
   public class logsDAL : SQLDataAccess 
    {
        public int InsertLogs(clsLogs obj)
        {

            int Id = 0;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32,ParameterDirection.Output);
                parameters.Add("@logDetail", obj.logDetail, DbType.String);
                parameters.Add("@formName", obj.formName, DbType.String);
                parameters.Add("@actionName", obj.actionName, DbType.String);
                parameters.Add("@recordId", obj.recordId, DbType.Int32);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.userId, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                Id = DapperExecuteCmd("spInsertLogs", obj.dbName, parameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateTariffType(clsLogs obj)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@logDetail", obj.logDetail, DbType.String);
                parameters.Add("@formName", obj.formName, DbType.String);
                parameters.Add("@actionName", obj.actionName, DbType.String);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                DapperExecuteCmd("spUpdateTariffType", obj.dbName, parameters, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsLogs> SelectAllTariffType(string dbName)
        {
            try
            {
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsLogs>("spSelectAllTariffType").ToList();
                    con.Close();
                    return list.ToList();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return new List<clsLogs>();
        }
        public List<clsLogs> SelectTariffTypeById(int id,string dbName)
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
                    var list = con.Query<clsLogs>("spSelectTariffTypeById",parameters,commandType:CommandType.StoredProcedure).ToList();
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
    }
}
