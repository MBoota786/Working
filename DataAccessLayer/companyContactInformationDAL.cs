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
  public  class companyContactInformationDAL : SQLDataAccess
    {
        public int InsertCompanyContactInformation(clsCompanyContactInformation ct)
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
                AddParamToSQLCmd(comm, "@extention", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.extention ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spInsertCompanyContactInformation");
                if (ConnectionString == string.Empty)
                {
                    throw (new ArgumentOutOfRangeException("ConnectionString"));
                }
                if (comm == null)
                {
                    throw (new ArgumentNullException("SqlCmd"));
                }
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comm.Connection = con;
                    con.Open();
                    comm.ExecuteNonQuery();
                    Id = (int)comm.Parameters["@id"].Value;
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateCompanyContactInformation(clsCompanyContactInformation ct)
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
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateCompanyContactInformation");
                if (ConnectionString == string.Empty)
                {
                    throw (new ArgumentOutOfRangeException("ConnectionString"));

                }
                if (comm == null)
                {
                    throw (new ArgumentNullException("SqlCmd"));
                }
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comm.Connection = con;
                    con.Open();
                    comm.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsCompanyContactInformation> SelectAllCompanyContactInformation()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllCompanyContactInformation");

                List<clsCompanyContactInformation> contactList = new List<clsCompanyContactInformation>();
                TExecuteReaderCmd<clsCompanyContactInformation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref contactList);
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
        public List<clsCompanyContactInformation> SelectCompanyContactInformationById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectCompanyContactInformationById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsCompanyContactInformation> contactList = new List<clsCompanyContactInformation>();
                TExecuteReaderCmd<clsCompanyContactInformation>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsAdressType>, ref contactList);
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
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsCompanyContactInformation> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsCompanyContactInformation obj = new clsCompanyContactInformation();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeAddressId = returnData["officeAddressId"] is DBNull ? (int)0 : (int)returnData["officeAddressId"];
                    obj.contactTypeid = returnData["contactTypeid"] is DBNull ? (int)0 : (int)returnData["contactTypeid"];
                    obj.contactTypeName = returnData["contactTypeName"] is DBNull ? (string)string.Empty : (string)returnData["contactTypeName"];
                    obj.countryAreaCode = returnData["countryAreaCode"] is DBNull ? (string)string.Empty : (string)returnData["countryAreaCode"];
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
