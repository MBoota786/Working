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
   public class accreditationAddressesDAL : SQLDataAccess
    {
        public int InsertAccreditationAddresses(clsAccreditationAddresses obj)
        {
            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@addressTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.adressTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryID", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateID", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityID", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrAddress", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrPostalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrPoBoxNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrPoBoxNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationAddresses", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccredatioAddresses(clsAccreditationAddresses obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@addressTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.adressTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryID", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateID", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityID", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrAddress", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrPostalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrPostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrPoBoxNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrPoBoxNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationAddresses", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationAddresses> SelectAllAccreditationAddresses(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationAddresses");

                List<clsAccreditationAddresses> activeList = new List<clsAccreditationAddresses>();
                TExecuteReaderCmd<clsAccreditationAddresses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationAddresses>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationAddresses>();
        }
        public List<clsAccreditationAddresses> SelectAccreditationAddressesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationAddressesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationAddresses> activeList = new List<clsAccreditationAddresses>();
                TExecuteReaderCmd<clsAccreditationAddresses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationAddresses>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationAddresses>();
        }
        public List<clsAccreditationAddresses> SelectAccreditationAddressesByAccreditationId(int accreditationId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationAddressesByAccreditationId");
                comand.Parameters.AddWithValue("@accreditationId", accreditationId);
                List<clsAccreditationAddresses> activeList = new List<clsAccreditationAddresses>();
                TExecuteReaderCmd<clsAccreditationAddresses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationAddresses>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationAddresses>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationAddresses> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationAddresses obj = new clsAccreditationAddresses();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationId = returnData["accreditationId"] is DBNull ? (int)0 : (int)returnData["accreditationId"];
                    obj.adressTypeId = returnData["adressTypeId"] is DBNull ? (int)0 : (int)returnData["adressTypeId"];
                    obj.countryID = returnData["countryID"] is DBNull ? (int)0 : (int)returnData["countryID"];
                    obj.stateID = returnData["stateID"] is DBNull ? (int)0 : (int)returnData["stateID"];
                    obj.cityID = returnData["cityID"] is DBNull ? (int)0 : (int)returnData["cityID"];
                    obj.accrAddress = returnData["accrAddress"] is DBNull ? (string)string.Empty : (string)returnData["accrAddress"];
                    obj.accrPostalCode = returnData["accrPostalCode"] is DBNull ? (string)string.Empty : (string)returnData["accrPostalCode"];
                    obj.accrPoBoxNo = returnData["accrPoBoxNo"] is DBNull ? (string)string.Empty : (string)returnData["accrPoBoxNo"];
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
        public bool DeleteAccreditationAddresses(int accreditationId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)accreditationId ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spDeleteAccreditationAddresses", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
