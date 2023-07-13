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
   public class naceGroupDAL : SQLDataAccess
    {
        public int InsertNaceGroup(clsNaceGroup obj)
        {

            int Id = 0;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32,ParameterDirection.Output);
                parameters.Add("@naceDivisionId", obj.naceDivisionId, DbType.Int32);
                parameters.Add("@groupTitle", obj.groupTitle, DbType.String);
                parameters.Add("@naceGroup", obj.naceGroup, DbType.String);
                parameters.Add("@groupDescription", obj.groupDescription, DbType.String);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                Id = DapperExecuteCmd("spInsertNaceGroup", obj.dbName, parameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateNaceGroup(clsNaceGroup obj)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@naceDivisionId", obj.naceDivisionId, DbType.Int32);
                parameters.Add("@groupTitle", obj.groupTitle, DbType.String);
                parameters.Add("@naceGroup", obj.naceGroup, DbType.String);
                parameters.Add("@groupDescription", obj.groupDescription, DbType.String);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                DapperExecuteCmd("spUpdateNaceGroup", obj.dbName, parameters, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsNaceGroup> SelectAllNaceGroup(string dbName)
        {
            try
            {
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsNaceGroup>("spSelectAllNaceGroup").ToList();
                    con.Close();
                    return list.ToList();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return new List<clsNaceGroup>();
        }
        public List<clsNaceGroup> SelectNaceGroupById(int id,string dbName)
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
                    var list = con.Query<clsNaceGroup>("spSelectNaceGroupById", parameters,commandType:CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public List<clsNaceGroup> SelectNaceGroupByNaceDivisionId(int naceDivisionId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@naceDivisionId", naceDivisionId, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsNaceGroup>("spSelectNaceGroupByNaceDivisionId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public List<clsNaceGroup> SelectNaceGroupByNaceGroup(string naceGroup, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@naceGroup", naceGroup, DbType.String, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsNaceGroup>("spSelectNaceGroupByNaceGroup", parameters, commandType: CommandType.StoredProcedure).ToList();
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
