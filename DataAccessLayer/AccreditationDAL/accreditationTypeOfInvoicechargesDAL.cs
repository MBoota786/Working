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
   public class accreditationTypeOfInvoicechargesDAL : SQLDataAccess
    {
        public int InsertAccreditationTypeOfInvoicecharges(clsAccreditationTypeOfInvoicecharges obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceChargeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.invoiceChargeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id=  ExecuteInsertCommandReturnId(comm, "spInsertAccreditationTypeOfInvoicecharges", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateAccreditationTypeOfInvoicecharges(clsAccreditationTypeOfInvoicecharges obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@invoiceChargeName", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.invoiceChargeName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateAccreditationTypeOfInvoicecharges", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsAccreditationTypeOfInvoicecharges> SelectAllAccreditationTypeOfInvoicecharges(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllAccreditationTypeOfInvoicecharges");

                List<clsAccreditationTypeOfInvoicecharges> activeList = new List<clsAccreditationTypeOfInvoicecharges>();
                TExecuteReaderCmd<clsAccreditationTypeOfInvoicecharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationTypeOfInvoicecharges>, ref activeList);
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
        public List<clsAccreditationTypeOfInvoicecharges> SelectAccreditationTypeOfInvoicechargesById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAccreditationTypeOfInvoicechargesById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsAccreditationTypeOfInvoicecharges> activeList = new List<clsAccreditationTypeOfInvoicecharges>();
                TExecuteReaderCmd<clsAccreditationTypeOfInvoicecharges>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAccreditationTypeOfInvoicecharges>, ref activeList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsAccreditationTypeOfInvoicecharges> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsAccreditationTypeOfInvoicecharges obj = new clsAccreditationTypeOfInvoicecharges();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.invoiceChargeName = returnData["invoiceChargeName"] is DBNull ? (string)string.Empty : (string)returnData["invoiceChargeName"];
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
