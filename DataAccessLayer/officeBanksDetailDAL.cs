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
  public  class officeBanksDetailDAL : SQLDataAccess
    {
        public int InsertofficeBanksDetail(clsOfficeBanksDetail ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@bankName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.bankName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accountNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.accountNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accountTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.accountTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeid", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactTypeid ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.cityId ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@bankAddress", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.bankAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@swiftCode", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.swiftCode ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@iban", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.iban ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@localWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.localWireTransferDetail ?? DBNull.Value);

               
                AddParamToSQLCmd(comm, "@internationalWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.internationalWireTransferDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sortCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.sortCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@transitNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.transitNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertOfficeBankDetail", ct.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateofficeBanksDetail(clsOfficeBanksDetail ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@bankName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.bankName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accountNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.accountNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accountTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.accountTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeid", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.contactTypeid ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.cityId ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@bankAddress", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.bankAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@swiftCode", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.swiftCode ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@iban", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.iban ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@localWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.localWireTransferDetail ?? DBNull.Value);


                AddParamToSQLCmd(comm, "@internationalWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)ct.internationalWireTransferDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@sortCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.sortCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@transitNo", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.transitNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOfficeBankDetail", ct.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsOfficeBanksDetail> SelectAllOfficeBanksDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeBankDetail");

                List<clsOfficeBanksDetail> contactList = new List<clsOfficeBanksDetail>();
                TExecuteReaderCmd<clsOfficeBanksDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeBanksDetail>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeBanksDetail>();
        }
        public List<clsOfficeBanksDetail> SelectOfficeBanksDetailById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeBankDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeBanksDetail> contactList = new List<clsOfficeBanksDetail>();
                TExecuteReaderCmd<clsOfficeBanksDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeBanksDetail>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeBanksDetail>();
        }
        public List<clsOfficeBanksDetail> SelectOfficeBankDetailByOfficeId(int officeId,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeBankDetailByOfficeId");
                comand.Parameters.AddWithValue("@officeId", officeId);
                List<clsOfficeBanksDetail> contactList = new List<clsOfficeBanksDetail>();
                TExecuteReaderCmd<clsOfficeBanksDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeBanksDetail>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOfficeBanksDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeBanksDetail> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeBanksDetail obj = new clsOfficeBanksDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeID = returnData["officeID"] is DBNull ? (int)0 : (int)returnData["officeID"];
                    obj.bankName = returnData["bankName"] is DBNull ? (string)string.Empty : (string)returnData["bankName"];
                    obj.accountNumber = returnData["accountNumber"] is DBNull ? (string)string.Empty : (string)returnData["accountNumber"];
                    obj.accountTitle = returnData["accountTitle"] is DBNull ? (string)string.Empty : (string)returnData["accountTitle"];
                    obj.contactTypeid = returnData["contactTypeid"] is DBNull ? (int)0 : (int)returnData["contactTypeid"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0: (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                    obj.stateProvinceName = returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.cityName = returnData["cityName"] is DBNull ? (string)string.Empty : (string)returnData["cityName"];
                    obj.bankAddress = returnData["bankAddress"] is DBNull ? (string)string.Empty : (string)returnData["bankAddress"];
                    obj.swiftCode = returnData["swiftCode"] is DBNull ? (string)string.Empty : (string)returnData["swiftCode"];
                    obj.iban = returnData["iban"] is DBNull ? (string)string.Empty : (string)returnData["iban"];
                    obj.localWireTransferDetail = returnData["localWireTransferDetail"] is DBNull ? (string)string.Empty : (string)returnData["localWireTransferDetail"];
                    obj.internationalWireTransferDetail = returnData["internationalWireTransferDetail"] is DBNull ? (string)string.Empty : (string)returnData["internationalWireTransferDetail"];
                    obj.sortCode = returnData["sortCode"] is DBNull ? (string)string.Empty : (string)returnData["sortCode"];
                    obj.transitNo = returnData["transitNo"] is DBNull ? (string)string.Empty : (string)returnData["transitNo"];
                    obj.currencyId = returnData["currencyId"] is DBNull ? (int)0 : (int)returnData["currencyId"];
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
