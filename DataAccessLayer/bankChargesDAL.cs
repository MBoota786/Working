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
  public  class bankChargesDAL : SQLDataAccess
    {
        public int InsertBankCharges(clsBankCharges ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.chargeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargeShortCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.chargeShortCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculationInput", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.calculationInput ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@criteriaId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.criteriaId ?? DBNull.Value);
               
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertBankCharges", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateBankCharges(clsBankCharges ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeID", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeID ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.chargeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@chargeShortCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.chargeShortCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@currencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.currencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@calculationInput", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.calculationInput ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@criteriaId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.criteriaId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateBankCharges", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsBankCharges> SelectAllBankCharges()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllBankCharges");

                List<clsBankCharges> contactList = new List<clsBankCharges>();
                TExecuteReaderCmd<clsBankCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankCharges>, ref contactList);
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
        public List<clsBankCharges> SelectBankChargesById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectBankChargesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsBankCharges> contactList = new List<clsBankCharges>();
                TExecuteReaderCmd<clsBankCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsBankCharges>, ref contactList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsBankCharges> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsBankCharges obj = new clsBankCharges();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeID = returnData["officeID"] is DBNull ? (int)0 : (int)returnData["officeID"];
                    obj.officeName = returnData["officeName"] is DBNull ? (string)string.Empty : (string)returnData["officeName"];
                    obj.chargeName = returnData["chargeName"] is DBNull ? (string)string.Empty : (string)returnData["chargeName"];
                    obj.chargeShortCode = returnData["chargeShortCode"] is DBNull ? (string)string.Empty : (string)returnData["chargeShortCode"];
                    obj.currencyId = returnData["currencyId"] is DBNull ? (int)0 : (int)returnData["currencyId"];
                    obj.currencyName = returnData["currencyName"] is DBNull ? (string)string.Empty: (string)returnData["currencyName"];
                    obj.calculationInput = returnData["calculationInput"] is DBNull ? (int)0 : (int)returnData["calculationInput"];
                    obj.criteriaId = returnData["criteriaId"] is DBNull ? (int)0 : (int)returnData["criteriaId"];
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
