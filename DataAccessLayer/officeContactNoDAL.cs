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
  public  class officeContactNoDAL : SQLDataAccess
    {
        public int InsertOfficeContactNo(clsOfficeContactNo ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeid", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactTypeid ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeAddressId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryAreaCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.countryAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@phoneIsoCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.phoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@phoneNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.phoneNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@extention", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.extention ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
              Id =  ExecuteInsertCommandReturnId(comm, "spInsertOfficeContactNo", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateOfficeContactNo(clsOfficeContactNo ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeid", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactTypeid ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeAddressId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryAreaCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.countryAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.contactNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@extention", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.extention ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@phoneIsoCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.phoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@phoneNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.phoneNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeContactNo", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsOfficeContactNo> SelectAllOfficeContactNo(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeContactNo");

                List<clsOfficeContactNo> contactList = new List<clsOfficeContactNo>();
                TExecuteReaderCmd<clsOfficeContactNo>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsOfficeContactNo> SelectOfficeContactNoByOfficeAddressId(int officeAddressId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeContactNoByOfficeId");
                comand.Parameters.AddWithValue("@officeAddressId", officeAddressId);
                List<clsOfficeContactNo> contactList = new List<clsOfficeContactNo>();
                TExecuteReaderCmd<clsOfficeContactNo>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeContactNo> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeContactNo obj = new clsOfficeContactNo();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeAddressId = returnData["officeAddressId"] is DBNull ? (int)0 : (int)returnData["officeAddressId"];
                    obj.contactTypeid = returnData["contactTypeid"] is DBNull ? (int)0 : (int)returnData["contactTypeid"];
                    obj.contactTypeName = returnData["contactTypeName"] is DBNull ? (string)string.Empty : (string)returnData["contactTypeName"];
                    obj.countryAreaCode = returnData["countryAreaCode"] is DBNull ? (string)string.Empty : (string)returnData["countryAreaCode"];
                    obj.phoneIsoCode = returnData["phoneIsoCode"] is DBNull ? (string)string.Empty : (string)returnData["phoneIsoCode"];
                    obj.phoneNumber = returnData["phoneNumber"] is DBNull ? (string)string.Empty : (string)returnData["phoneNumber"];
                    obj.contactNumber = returnData["contactNumber"] is DBNull ? (string)string.Empty : (string)returnData["contactNumber"];
                    obj.extention = returnData["extention"] is DBNull ? (string)string.Empty : (string)returnData["extention"];
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
