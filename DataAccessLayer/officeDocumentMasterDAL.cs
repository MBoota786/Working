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
  public  class officeDocumentMasterDAL : SQLDataAccess
    {
        public int InsertOfficeDocumentMaster(clsOfficeDocumentMaster ct)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeIdOrUserId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeIdOrUserId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocumentId", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ct.requiredDocumentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.documentTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeDocumentCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeDocumentCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeDocumentTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.officeDocumentTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);

                SetCommandType(comm, CommandType.StoredProcedure, "spInsertOfficeDocumentMaster");
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
        public bool UpdateOfficeDocumentMaster(clsOfficeDocumentMaster ct)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeIdOrUserId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeIdOrUserId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@requiredDocumentId", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ct.requiredDocumentId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@documentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.documentTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeDocumentCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.officeDocumentCategoryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeDocumentTitle", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ct.officeDocumentTitle ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ct.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ct.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ct.active ?? DBNull.Value);
                SetCommandType(comm, CommandType.StoredProcedure, "spUpdateOfficeDocumentMaster");
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
        public List<clsOfficeDocumentMaster> SelectAllOfficeDocumentMaster()
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOfficeDocumentMaster");

                List<clsOfficeDocumentMaster> docList = new List<clsOfficeDocumentMaster>();
                TExecuteReaderCmd<clsOfficeDocumentMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeDocumentMaster>, ref docList);
                if (docList != null)
                {
                    return docList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public List<clsOfficeDocumentMaster> SelectOfficeDocumentMasterById(int id)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeDocumentMasterById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOfficeDocumentMaster> docList = new List<clsOfficeDocumentMaster>();
                TExecuteReaderCmd<clsOfficeDocumentMaster>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsOfficeDocumentMaster>, ref docList);
                if (docList != null)
                {
                    return docList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsOfficeDocumentMaster> activeList)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOfficeDocumentMaster obj = new clsOfficeDocumentMaster();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeIdOrUserId = returnData["officeIdOrUserId"] is DBNull ? (int)0: (int)returnData["officeIdOrUserId"];
                    obj.requiredDocumentId = returnData["requiredDocumentId"] is DBNull ? (int)0: (int)returnData["requiredDocumentId"];
                    obj.officeDocumentCategoryId = returnData["officeDocumentCategoryId"] is DBNull ? (int)0: (int)returnData["officeDocumentCategoryId"];
                    obj.documentTypeId = returnData["documentTypeId"] is DBNull ? (int)0 : (int)returnData["documentTypeId"];
                    obj.officeDocumentTitle = returnData["officeDocumentTitle"] is DBNull ? (string)string.Empty : (string)returnData["officeDocumentTitle"];
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
