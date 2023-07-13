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
   public class officeTaxMasterDAL : SQLDataAccess
    {
        public int InsertOfficeTaxMaster(clsOfficeTaxMaster obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.officeTaxName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOfficePayable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOfficePayable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClientReceivable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClientReceivable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeTaxMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeTaxMaster(clsOfficeTaxMaster obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTaxName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.officeTaxName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.officeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@serviceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.serviceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isParentOfficePayable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isParentOfficePayable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isClientReceivable", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.isClientReceivable ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeTaxMaster", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeTaxMaster> SelectAllOfficeTaxMaster(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeTaxMaster");
                SetDBName(dbName);
                List<clsOfficeTaxMaster> activeList = new List<clsOfficeTaxMaster>();
                TExecuteReaderCmd<clsOfficeTaxMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxMaster>();
        }
        public List<clsOfficeTaxMaster> SelectOfficeTaxMasterById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeTaxMaster> activeList = new List<clsOfficeTaxMaster>();
                TExecuteReaderCmd<clsOfficeTaxMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxMaster>();
        } 
        public List<clsOfficeTaxMaster> SelectOfficeTaxMasterByOfficeId(int officeId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxMasterByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeTaxMaster> activeList = new List<clsOfficeTaxMaster>();
                TExecuteReaderCmd<clsOfficeTaxMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxMaster>();
        } 
        public List<clsOfficeTaxMaster> SelectOfficeTaxMasterForListByOfficeId(int officeId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxMasterForListByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeTaxMaster> activeList = new List<clsOfficeTaxMaster>();
                TExecuteReaderCmd<clsOfficeTaxMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxMaster>();
        }
        public List<clsOfficeTaxMaster> SelectOfficeTaxMasterByOfficeIdForQuotation(int officeId,int serviceFeeTypeId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeTaxMasterByOfficeIdForQuotation");
                comand.Parameters.AddWithValue("@officeId", officeId);
                comand.Parameters.AddWithValue("@serviceFeeTypeId", serviceFeeTypeId);
                List<clsOfficeTaxMaster> activeList = new List<clsOfficeTaxMaster>();
                TExecuteReaderCmd<clsOfficeTaxMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeTaxMaster>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeTaxMaster>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeTaxMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeTaxMaster obj = new clsOfficeTaxMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeTaxName = ColumnExists(returnData, "officeTaxName") ? returnData["officeTaxName"] is DBNull ? (string)string.Empty : (string)returnData["officeTaxName"] :string.Empty;
                    obj.serviceName = ColumnExists(returnData, "serviceName") ? returnData["serviceName"] is DBNull ? (string)string.Empty : (string)returnData["serviceName"]:string.Empty;
                    obj.taxName = ColumnExists(returnData, "taxName") ? returnData["taxName"] is DBNull ? (string)string.Empty : (string)returnData["taxName"] :string.Empty;
                    obj.officeName = ColumnExists(returnData, "officeName") ? returnData["officeName"] is DBNull ? (string)string.Empty : (string)returnData["officeName"] :string.Empty;
                    obj.officeId = ColumnExists(returnData, "officeId") ? returnData["officeId"] is DBNull ? (int) 0 : (int)returnData["officeId"]:0;
                    obj.serviceId = ColumnExists(returnData, "serviceId") ? returnData["serviceId"] is DBNull ? (int) 0 : (int)returnData["serviceId"]:0;
                    obj.isParentOfficePayable = ColumnExists(returnData, "isParentOfficePayable") ? returnData["isParentOfficePayable"] is DBNull ? (bool) false: (bool)returnData["isParentOfficePayable"] : false;
                    obj.isClientReceivable = ColumnExists(returnData, "isClientReceivable") ? returnData["isClientReceivable"] is DBNull ? (bool) false : (bool)returnData["isClientReceivable"] :false;
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
