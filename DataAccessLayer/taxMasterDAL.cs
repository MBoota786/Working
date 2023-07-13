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
   public class taxMasterDAL : SQLDataAccess
    {
        public int InsertTaxMaster(clsTaxMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.moneyReceivingOriginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taxName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxPercentage", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taxPercentage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertTaxMaster", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateTaxMaster(clsTaxMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@paymentStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.moneyReceivingOriginId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taxName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxPercentage", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.taxPercentage ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateTaxMaster", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsTaxMaster> SelectAllTaxMaster()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllTaxMaster");

                List<clsTaxMaster> activeList = new List<clsTaxMaster>();
                TExecuteReaderCmd<clsTaxMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTaxMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsTaxMaster> SelectTaxMasterById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectTaxMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsTaxMaster> activeList = new List<clsTaxMaster>();
                TExecuteReaderCmd<clsTaxMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsTaxMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsTaxMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsTaxMaster obj = new clsTaxMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.moneyReceivingOriginId = returnData["moneyReceivingOriginId"] is DBNull ? (int)0 : (int)returnData["moneyReceivingOriginId"];
                    obj.taxTypeId = returnData["taxTypeId"] is DBNull ? (int)0 : (int)returnData["taxTypeId"];
                    obj.taxName = returnData["taxName"] is DBNull ? (string)string.Empty : (string)returnData["taxName"];
                    obj.taxPercentage = returnData["taxPercentage"] is DBNull ? (string)string.Empty : (string)returnData["taxPercentage"];
                    obj.serviceId = returnData["serviceId"] is DBNull ? (int)0 : (int)returnData["serviceId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.officeId = returnData["officeId"] is DBNull ? (int)0 : (int)returnData["officeId"];
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
