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
   public class standardServiceFeeBankMapDAL : SQLDataAccess
    {
        public int InsertStandardServiceFeeBankMap(clsStandardServiceFeeBankMap obj)
        {

            int Id = 0;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32,ParameterDirection.Output);
                parameters.Add("@standardServiceFeeId", obj.standardServiceFeeId, DbType.Int32);
                parameters.Add("@officeBankDetailId", obj.officeBankDetailId, DbType.Int32);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                Id = DapperExecuteCmd("spInsertStandardServiceFeeBankMap", obj.dbName, parameters,true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateStandardServiceFeeBankMap(clsStandardServiceFeeBankMap obj)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", obj.id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@standardServiceFeeId", obj.standardServiceFeeId, DbType.Int32);
                parameters.Add("@officeBankDetailId", obj.officeBankDetailId, DbType.Int32);
                parameters.Add("@createdOn", obj.createdOn, DbType.DateTime);
                parameters.Add("@createdBy", obj.createdBy, DbType.String);
                parameters.Add("@active", obj.active, DbType.Boolean);
                DapperExecuteCmd("spUpdateStandardServiceFeeBankMap", obj.dbName, parameters, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsStandardServiceFeeBankMap> SelectAllStandardServiceFeeBankMap(string dbName)
        {
            try
            {
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsStandardServiceFeeBankMap>("spSelectAllStandardServiceFeeBankMap", commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return list.ToList();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return new List<clsStandardServiceFeeBankMap>();
        }
        public List<clsStandardServiceFeeBankMap> SelectStandardServiceFeeBankMapById(int id,string dbName)
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
                    var list = con.Query<clsStandardServiceFeeBankMap>("spSelectStandardServiceFeeBankMapById", parameters, commandType: CommandType.StoredProcedure).ToList();
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
        public List<clsStandardServiceFeeBankMap> SelectStandardServiceFeeBankMapByStandardServiceFeeId(int standardServiceFeeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                var parameters = new DynamicParameters();
                parameters.Add("@standardServiceFeeId", standardServiceFeeId, DbType.Int32, ParameterDirection.Input);
                SetDBName(dbName);
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    var list = con.Query<clsStandardServiceFeeBankMap>("spSelectStandardServiceFeeBankMapByStandardServiceFeeId", parameters,commandType:CommandType.StoredProcedure).ToList();
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
        //public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsStandardServiceFeeBankMap> activeList)
        //{
        //    try
        //    {
        //        while (returnData.Read())
        //        {
        //            clsStandardServiceFeeBankMap obj = new clsStandardServiceFeeBankMap();
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
