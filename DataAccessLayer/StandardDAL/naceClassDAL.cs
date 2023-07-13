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
   public class naceClassDAL : SQLDataAccess
    {
        public int InsertNaceClass(clsNaceClass obj)
        {

            int Id = 0;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32,ParameterDirection.Output);
                parameters.Add("@naceGroupId", obj.naceGroupId, DbType.Int32);
                parameters.Add("@naceClass", obj.naceClass, DbType.String);
                parameters.Add("@classTitle", obj.classTitle, DbType.String);
                parameters.Add("@classDescription", obj.classDescription, DbType.String);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                Id = DapperExecuteCmd("spInsertNaceClass", obj.dbName, parameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateNaceClass(clsNaceClass obj)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@naceGroupId", obj.naceGroupId, DbType.Int32);
                parameters.Add("@naceClass", obj.naceClass, DbType.String);
                parameters.Add("@classTitle", obj.classTitle, DbType.String);
                parameters.Add("@classDescription", obj.classDescription, DbType.String);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                DapperExecuteCmd("spUpdateNaceClass", obj.dbName, parameters, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsNaceClass> SelectAllNaceClass(string dbName)
        {
            try
            {
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsNaceClass>("spSelectAllNaceClass").ToList();
                    con.Close();
                    return list.ToList();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return new List<clsNaceClass>();
        }
        public List<clsNaceClass> SelectNaceClassById(int id,string dbName)
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
                    var list = con.Query<clsNaceClass>("spSelectNaceClassById", parameters,commandType:CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public List<clsNaceClass> spSelectNaceClassByNaceGroupId(int naceGroupId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@naceGroupId", naceGroupId, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsNaceClass>("spSelectNaceClassByNaceGroupId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public List<clsNaceClass> SelectNaceClassByNaceClass(string naceClass, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@naceClass", naceClass, DbType.String, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsNaceClass>("spSelectNaceClassByNaceClass", parameters, commandType: CommandType.StoredProcedure).ToList();
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
