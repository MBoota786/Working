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
   public class clientSiteSeasonDAL : SQLDataAccess
    {
        public int InsertClientSiteSeason(clsClientSiteSeason obj)
        {

            int Id = 0;
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@seasonTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.seasonTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@fromSeasonMonthId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.fromSeasonMonthId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@toSeasonMonthId", SqlDbType.Int , 4, ParameterDirection.Input, (object)obj.toSeasonMonthId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
              Id=  ExecuteInsertCommandReturnId(comm, "spInsertClientSiteSeason", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;

        }
        public bool UpdateClientSiteSeason(clsClientSiteSeason obj)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@clientSiteId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.clientSiteId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@seasonTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.seasonTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@fromSeasonMonthId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.fromSeasonMonthId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@toSeasonMonthId", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.toSeasonMonthId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)obj.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)obj.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)obj.active ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateClientSiteSeason", obj.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsClientSiteSeason> SelectAllClientSiteSeason(string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllClientSiteSeason");
                SetDBName(dbName);
                List<clsClientSiteSeason> adressList = new List<clsClientSiteSeason>();
                TExecuteReaderCmd<clsClientSiteSeason>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteSeason>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteSeason>();
        }
        public List<clsClientSiteSeason> SelectClientSiteSeasonById(int id, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteSeasonById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsClientSiteSeason> adressList = new List<clsClientSiteSeason>();
                TExecuteReaderCmd<clsClientSiteSeason>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteSeason>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteSeason>();
        }   
        public List<clsClientSiteSeason> SelectClientSiteSeasonByClientSiteId(int clientSiteId, string dbName)
        {
            try
            {
                SqlCommand comand = new SqlCommand();
                SetDBName(dbName);
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectClientSiteSeasonByClientSiteId");
                comand.Parameters.AddWithValue("@clientSiteId", clientSiteId);
                List<clsClientSiteSeason> adressList = new List<clsClientSiteSeason>();
                TExecuteReaderCmd<clsClientSiteSeason>(comand, TGenerateSOFieldFromReaderactiveAdressList<clsClientSiteSeason>, ref adressList);
                if (adressList != null)
                {
                    return adressList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsClientSiteSeason>();
        }
        public void TGenerateSOFieldFromReaderactiveAdressList<T>(SqlDataReader returnData, ref List<clsClientSiteSeason> activeEmail)
        {
            try
            {
                while (returnData.Read())
                {
                    clsClientSiteSeason obj = new clsClientSiteSeason();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.clientSiteId = returnData["clientSiteId"] is DBNull ? (int)0 : (int)returnData["clientSiteId"];
                    obj.seasonTypeId = returnData["seasonTypeId"] is DBNull ? (int)0 : (int)returnData["seasonTypeId"];
                    obj.fromSeasonMonthId = returnData["fromSeasonMonthId"] is DBNull ? (int) 0: (int)returnData["fromSeasonMonthId"];
                    obj.toSeasonMonthId = returnData["toSeasonMonthId"] is DBNull ? (int) 0: (int)returnData["toSeasonMonthId"];
                    obj.fromMonthName = returnData["fromMonthName"] is DBNull ? (string)  string.Empty : (string)returnData["fromMonthName"];
                    obj.toMonthName = returnData["toMonthName"] is DBNull ? (string)  string.Empty : (string)returnData["toMonthName"];
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
