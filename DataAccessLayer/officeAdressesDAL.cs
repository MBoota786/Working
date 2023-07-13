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
  public   class officeAdressesDAL : SQLDataAccess
    {
        public int InsertOfficeAdresses(clsOfficeAddresses ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adressType", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.adressTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.cityId ?? DBNull.Value);
       
                AddParamToSQLCmd(comm, "@officeAddressLine1", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.officeAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine2", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.officeAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine3", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.officeAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@postalCode", SqlDbType.NVarChar,10, ParameterDirection.Input, (object)ct.postalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@pOBox", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.pOBox ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
               Id =  ExecuteInsertCommandReturnId(comm, "spInsertOfficeAddresses", ct.dbName);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeAdresses(clsOfficeAddresses ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@adressType", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.adressTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine1", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.officeAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine2", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.officeAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine3", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ct.officeAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@postalCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, (object)ct.postalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@pOBox", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ct.pOBox ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeAddresses", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOfficeAddresses> SelectAllOfficeAdresses(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeAddresses");
                List<clsOfficeAddresses> addressesList = new List<clsOfficeAddresses>();
                TExecuteReaderCmd<clsOfficeAddresses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref addressesList);
                if (addressesList != null)
                {
                    return addressesList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeAddresses>();
        }
        public List<clsOfficeAddresses> SelectOfficeAdressesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeAddressesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeAddresses> addressesList = new List<clsOfficeAddresses>();
                TExecuteReaderCmd<clsOfficeAddresses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref addressesList);
                if (addressesList != null)
                {
                    return addressesList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeAddresses>();
        }
        public List<clsOfficeAddresses> SelectOfficeAdressesByOfficeId(int officeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeAdressesByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeAddresses> addressesList = new List<clsOfficeAddresses>();
                TExecuteReaderCmd<clsOfficeAddresses>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref addressesList);
                if (addressesList != null)
                {
                    return addressesList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeAddresses> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeAddresses obj = new clsOfficeAddresses();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeID = returnData["officeID"] is DBNull ? (int)0 : (int)returnData["officeID"];
                    obj.officeName = returnData["officeName"] is DBNull ? (string)string.Empty : (string)returnData["officeName"];
                    obj.adressTypeId = returnData["adressTypeId"] is DBNull ? (int)0 : (int)returnData["adressTypeId"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0 : (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.officeAddressLine1 = returnData["officeAddressLine1"] is DBNull ? (string)string.Empty : (string)returnData["officeAddressLine1"];
                    obj.officeAddressLine2 = returnData["officeAddressLine2"] is DBNull ? (string)string.Empty : (string)returnData["officeAddressLine2"];
                    obj.officeAddressLine3 = returnData["officeAddressLine3"] is DBNull ? (string)string.Empty : (string)returnData["officeAddressLine3"];
                    obj.postalCode = returnData["postalCode"] is DBNull ? (string)string.Empty : (string)returnData["postalCode"];
                    obj.pOBox = returnData["pOBox"] is DBNull ? (string)string.Empty : (string)returnData["pOBox"];
                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];
                    activeEmail.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
