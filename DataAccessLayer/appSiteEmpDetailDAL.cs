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
   public class appSiteEmpDetailDAL : SQLDataAccess
    {
        public int InsertAppSiteEmpDetail(clsAppSiteEmpDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteShiftId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteShiftId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardEmpTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardEmpTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAppSiteEmpDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAppSiteEmpDetail(clsAppSiteEmpDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@appId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.appId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteShiftId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteShiftId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@standardEmpTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.standardEmpTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@noOfEmp", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.noOfEmp ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAppSiteEmpDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAppSiteEmpDetail> SelectAllAppSiteEmpDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAppSiteEmpDetail");

                List<clsAppSiteEmpDetail> activeList = new List<clsAppSiteEmpDetail>();
                TExecuteReaderCmd<clsAppSiteEmpDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpDetail>();
        }
        public List<clsAppSiteEmpDetail> SelectAppSiteEmpDetailByAppIdClientSiteId(int appId , int clientSiteId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAppSiteEmpDetailByAppIdClientSiteId");
                comand.Parameters.AddWithValue("@appId", appId);
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsAppSiteEmpDetail> activeList = new List<clsAppSiteEmpDetail>();
                TExecuteReaderCmd<clsAppSiteEmpDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAppSiteEmpDetail>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAppSiteEmpDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAppSiteEmpDetail> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAppSiteEmpDetail obj = new clsAppSiteEmpDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.appId = returnData["appId"] is DBNull ? (int)0 : (int)returnData["appId"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.clientSiteShiftId = returnData["clientSiteShiftId"] is DBNull ? (int)0 : (int)returnData["clientSiteShiftId"];
                    obj.standardEmpTypeId = returnData["standardEmpTypeId"] is DBNull ? (int)0 : (int)returnData["standardEmpTypeId"];
                    obj.noOfEmp = returnData["noOfEmp"] is DBNull ? (int)0 : (int)returnData["noOfEmp"];
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
