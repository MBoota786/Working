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
   public class applicationEditReasonDAL : SQLDataAccess
    {
        public int InsertApplicationEditReason(clsApplicationEditReason obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@applicationDetailId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.applicationDetailId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@fieldName", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)obj.fieldName ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@newValue", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.newValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@oldValue", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)obj.oldValue ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@editReason", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)obj.editReason ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@editDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.editDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                Id = ExecuteInsertCommandReturnId(comm, "spInsertApplicationEditReason", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
    }
}
