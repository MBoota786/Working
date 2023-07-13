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
  public  class accreditationBankDetailDAL : SQLDataAccess
    {
        public int InsertAccreditationBankDetail(clsAccreditationBankDetail obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrBankName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrBankName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrAccountNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrAccountNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrAccountTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrAccountTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeid", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contactTypeid ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@accrBankAddress", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrBankAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrSwiftCode", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrSwiftCode ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@accrIban", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrIban ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrLocalWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrLocalWireTransferDetail ?? DBNull.Value);

               
                AddParamToSQLCmd(comm, "@accrInternationalWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrInternationalWireTransferDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccreditationBankDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationBankDetail(clsAccreditationBankDetail obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrBankName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrBankName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrAccountNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrAccountNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrAccountTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrAccountTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@contactTypeid", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.contactTypeid ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.cityId ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@accrBankAddress", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrBankAddress ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrSwiftCode", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrSwiftCode ?? DBNull.Value);

                AddParamToSQLCmd(comm, "@accrIban", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.accrIban ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrLocalWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrLocalWireTransferDetail ?? DBNull.Value);


                AddParamToSQLCmd(comm, "@accrInternationalWireTransferDetail", SqlDbType.NVarChar, 500, ParameterDirection.Input, (object)obj.accrInternationalWireTransferDetail ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationBankDetail", obj.dbName);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationBankDetail> SelectAllAccreditationBankDetail(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationBankDetail");

                List<clsAccreditationBankDetail> contactList = new List<clsAccreditationBankDetail>();
                TExecuteReaderCmd<clsAccreditationBankDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBankDetail>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBankDetail>();
        }
        public List<clsAccreditationBankDetail> SelectAccreditationBankDetailByAccreditationId(int accreditationId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationBankDetailByAccreditationId");
                comand.Parameters.AddWithValue("@accreditationId", accreditationId);
                List<clsAccreditationBankDetail> contactList = new List<clsAccreditationBankDetail>();
                TExecuteReaderCmd<clsAccreditationBankDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBankDetail>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBankDetail>();
        }
        public List<clsAccreditationBankDetail> SelectAccreditationBankDetailById(int id, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationBankDetailById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationBankDetail> contactList = new List<clsAccreditationBankDetail>();
                TExecuteReaderCmd<clsAccreditationBankDetail>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationBankDetail>, ref contactList);
                if (contactList != null)
                {
                    return contactList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccreditationBankDetail>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationBankDetail> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationBankDetail obj = new clsAccreditationBankDetail();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accreditationId = returnData["accreditationId"] is DBNull ? (int)0 : (int)returnData["accreditationId"];
                    obj.accrBankName = returnData["accrBankName"] is DBNull ? (string)string.Empty : (string)returnData["accrBankName"];
                    obj.accrAccountNumber = returnData["accrAccountNumber"] is DBNull ? (string)string.Empty : (string)returnData["accrAccountNumber"];
                    obj.accrAccountTitle = returnData["accrAccountTitle"] is DBNull ? (string)string.Empty : (string)returnData["accrAccountTitle"];
                    obj.contactTypeid = returnData["contactTypeid"] is DBNull ? (int)0 : (int)returnData["contactTypeid"];
                    obj.countryId = returnData["countryId"] is DBNull ? (int)0: (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int)0 : (int)returnData["stateProvinceId"];
                   obj.cityId = returnData["cityId"] is DBNull ? (int)0 : (int)returnData["cityId"];
                    obj.accrBankAddress = returnData["accrBankAddress"] is DBNull ? (string)string.Empty : (string)returnData["accrBankAddress"];
                    obj.accrSwiftCode = returnData["accrSwiftCode"] is DBNull ? (string)string.Empty : (string)returnData["accrSwiftCode"];
                    obj.accrIban = returnData["accrIban"] is DBNull ? (string)string.Empty : (string)returnData["accrIban"];
                    obj.accrLocalWireTransferDetail = returnData["accrLocalWireTransferDetail"] is DBNull ? (string)string.Empty : (string)returnData["accrLocalWireTransferDetail"];
                    obj.accrInternationalWireTransferDetail = returnData["accrInternationalWireTransferDetail"] is DBNull ? (string)string.Empty : (string)returnData["accrInternationalWireTransferDetail"];
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
        public bool ActiveFalseForDeleteAccreditationBankDetailById(int id, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spActiveFalseForDeleteAccreditationBankDetailById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
