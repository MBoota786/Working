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
   public class appBusinessPartnerDAL : SQLDataAccess
    {
        public int InsertAppBusinessPartner(clsAppBusinessPartner obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appBusinessPartnerName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appBusinessPartnerName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBrand", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBrand?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyer?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isCustomer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCustomer?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppBusinessPartner", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppBusinessPartner(clsAppBusinessPartner obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appBusinessPartnerName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.appBusinessPartnerName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBrand", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBrand ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isBuyer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isBuyer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isCustomer", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isCustomer ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppBusinessPartner", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAppBusinessPartner> SelectAllAppBusinessPartner(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppBusinessPartner");

                List<clsAppBusinessPartner> activeList = new List<clsAppBusinessPartner>();
                TExecuteReaderCmd<clsAppBusinessPartner>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppBusinessPartner>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppBusinessPartner>();
        }
        public List<clsAppBusinessPartner> SelectAppBusinessPartnerById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppBusinessPartnerById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAppBusinessPartner> activeList = new List<clsAppBusinessPartner>();
                TExecuteReaderCmd<clsAppBusinessPartner>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppBusinessPartner>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppBusinessPartner>();
        }
        public List<clsAppBusinessPartner> SelectAppBusinessPartnerByAppId(int appId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppBusinessPartnerByAppId");
                comand.Parameters.AddWithValue("@appId", appId);
                List<clsAppBusinessPartner> activeList = new List<clsAppBusinessPartner>();
                TExecuteReaderCmd<clsAppBusinessPartner>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppBusinessPartner>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppBusinessPartner>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppBusinessPartner> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppBusinessPartner obj = new clsAppBusinessPartner();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.appBusinessPartnerName = returnData["appBusinessPartnerName"] is DBNull ? (string)string.Empty : (string)returnData["appBusinessPartnerName"];
                    obj.isBrand = returnData["isBrand"] is DBNull ? (bool)false : (bool)returnData["isBrand"];
                    obj.isBuyer = returnData["isBuyer"] is DBNull ? (bool)false : (bool)returnData["isBuyer"];
                    obj.isCustomer = returnData["isCustomer"] is DBNull ? (bool)false : (bool)returnData["isCustomer"];
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
