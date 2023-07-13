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
   public class accrSpecialChargesDAL : SQLDataAccess
    {
        public int InsertAccrSpecialCharges(clsAccrSpecialCharges obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@typeOfInvoiceChargeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.typeOfInvoiceChargeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@specialChargesName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.specialChargesName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modeOfPaymentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modeOfPaymentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@specialChargesAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.specialChargesAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertAccrSpecialCharges", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccrSpecialCharges(clsAccrSpecialCharges obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accrId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accrId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@accreditationStandardId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.accreditationStandardId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@typeOfInvoiceChargeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.typeOfInvoiceChargeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@specialChargesName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.specialChargesName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modeOfPaymentId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modeOfPaymentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@specialChargesAmount", SqlDbType.Decimal, 18, ParameterDirection.Input, (object)obj.specialChargesAmount ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccrSpecialCharges", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccrSpecialCharges> SelectAllAccrSpecialCharges(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccrSpecialCharges");

                List<clsAccrSpecialCharges> activeList = new List<clsAccrSpecialCharges>();
                TExecuteReaderCmd<clsAccrSpecialCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrSpecialCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrSpecialCharges>();
        }
        public List<clsAccrSpecialCharges> SelectAccrSpecialChargesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrSpecialChargesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccrSpecialCharges> activeList = new List<clsAccrSpecialCharges>();
                TExecuteReaderCmd<clsAccrSpecialCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrSpecialCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrSpecialCharges>();
        }
        public List<clsAccrSpecialCharges> SelectAccrSpecialChargesByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId(int accrId,int accreditationStandardId,int typeOfInvoiceChargeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccrSpecialChargesByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId");
                comand.Parameters.AddWithValue("@accrId", accrId);
                comand.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                comand.Parameters.AddWithValue("@typeOfInvoiceChargeId", typeOfInvoiceChargeId);
                List<clsAccrSpecialCharges> activeList = new List<clsAccrSpecialCharges>();
                TExecuteReaderCmd<clsAccrSpecialCharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccrSpecialCharges>, ref activeList);
                if (activeList != null)
                {
                    return activeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsAccrSpecialCharges>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccrSpecialCharges> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccrSpecialCharges obj = new clsAccrSpecialCharges();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.accrId = returnData["accrId"] is DBNull ? (int)0 : (int)returnData["accrId"];
                    obj.accreditationStandardId = returnData["accreditationStandardId"] is DBNull ? (int)0 : (int)returnData["accreditationStandardId"];
                    obj.typeOfInvoiceChargeId = returnData["typeOfInvoiceChargeId"] is DBNull ? (int)0 : (int)returnData["typeOfInvoiceChargeId"];
                    obj.specialChargesName = returnData["specialChargesName"] is DBNull ? (string) string.Empty : (string)returnData["specialChargesName"];
                    obj.modeOfPaymentId = returnData["modeOfPaymentId"] is DBNull ? (int)0 : (int)returnData["modeOfPaymentId"];
                   obj.specialChargesAmount = returnData["specialChargesAmount"] is DBNull ? (decimal) 0 : (decimal)returnData["specialChargesAmount"];
                   obj.modeOfPaymentName = returnData["modeOfPaymentName"] is DBNull ? (string) string.Empty : (string)returnData["modeOfPaymentName"];
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
        public bool DeleteAccrSpecialChargesByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId(int accrId, int accreditationStandardId, int typeOfInvoiceChargeId, string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                comm.Parameters.AddWithValue("@accrId", accrId);
                comm.Parameters.AddWithValue("@accreditationStandardId", accreditationStandardId);
                comm.Parameters.AddWithValue("@typeOfInvoiceChargeId", typeOfInvoiceChargeId);
                ExecuteNonQueryCommand(comm, "spDeleteAccrSpecialChargesByAccrIdAndAccreditationStandardIdAndTypeOfInvoiceChargeId", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool ActiveFalseForDeleteAccrSpecialChargesById(int id,string dbName)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object) id ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spActiveFalseForDeleteAccrSpecialChargesById", dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
