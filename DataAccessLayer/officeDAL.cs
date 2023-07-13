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
   public class officeDAL :SQLDataAccess
    {
        public int InsertOffice(clsOffice ofc)
        {
            #region old
            //SqlParameter[] parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@officeTypeId", ofc.officeTypeId), 
            //    new SqlParameter("@officeName", ofc.officeName),
            //    new SqlParameter("@legalStatusId", ofc.legalStatusId),
            //    new SqlParameter("@registrationNumber", ofc.registerationNumber),
            //    new SqlParameter("@businessLicenseNumber", ofc.@businessLicenseNumber),
            //    new SqlParameter("@registrationNumber", ofc.registerationNumber),
            //      new SqlParameter("@businessTypeId", ofc.businessTypeId),
            //      new SqlParameter("@reportingOfficeId", ofc.reportingOfficeId),
            //    new SqlParameter("@active", ofc.active),
            //    new SqlParameter("@createdBy", ofc.createdBy),
            //    new SqlParameter("@createdOn", ofc.createdOn)
            //};

            //return SqlDBHelper.ExecuteNonQuery("spInsertOffice", CommandType.StoredProcedure, parameters);
            #endregion
            int Id = 0;
                try
                {
                    SqlCommand comm = new SqlCommand();
                    AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Output, (object)ofc.id ?? DBNull.Value);
                    AddParamToSQLCmd(comm, "@officeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.officeTypeId ?? DBNull.Value);
                   AddParamToSQLCmd(comm, "@officeName", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ofc.officeName ?? DBNull.Value);
               // AddParamToSQLCmd(comm, "@legalStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.legalStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)ofc.taxNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessLicenseNumber", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)ofc.businessLicenseNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.businessTypeId ?? DBNull.Value); 
               AddParamToSQLCmd(comm, "@reportingOfficeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.reportingOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.companyTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeActiveStsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.officeActiveStsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeActivateBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.officeActivateBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@baseCurrencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.baseCurrencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@activeDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ofc.activeDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeFolderPath", SqlDbType.NVarChar, 50, ParameterDirection.Input, (object)ofc.officeFolderPath ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ofc.createdOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@createdBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.createdBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ofc.active ?? DBNull.Value);

                //New Addition 03082022
                AddParamToSQLCmd(comm, "@officeCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ofc.officeCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ofc.isEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExclusive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ofc.isExclusive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@categoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.categoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeWebsite ?? DBNull.Value);
                //Merge Tables
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine1", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine2", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine3", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePostalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePoBox", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePoBox ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCountryAreaCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeCountryAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCellNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeCellNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@extention", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.extention ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePhoneIsoCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePhoneNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePhoneNumber ?? DBNull.Value);
                Id =  ExecuteInsertCommandReturnId(comm, "spInsertOffice", ofc.dbName);
                }
                catch (Exception ex)
                {
                throw ex;
                }
                return Id;
            
        }
        public bool UpdateOffice(clsOffice ofc)
        {
            try
            {
                SqlCommand comm = new SqlCommand();
                AddParamToSQLCmd(comm, "@id", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.id ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.officeTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeName", SqlDbType.NVarChar, 100, ParameterDirection.Input, (object)ofc.officeName ?? DBNull.Value);
               // AddParamToSQLCmd(comm, "@legalStatusId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.legalStatusId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@taxNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)ofc.taxNo ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessLicenseNumber", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)ofc.businessLicenseNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@businessTypeId", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)ofc.businessTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@reportingOfficeId", SqlDbType.NVarChar, 200, ParameterDirection.Input, (object)ofc.reportingOfficeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@companyTypeId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.companyTypeId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeActiveStsId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.officeActiveStsId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeActivateBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.officeActivateBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@baseCurrencyId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.baseCurrencyId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@activeDate", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ofc.activeDate ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedOn", SqlDbType.DateTime, 20, ParameterDirection.Input, (object)ofc.modifiedOn ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@modifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.modifiedBy ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@active", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ofc.active ?? DBNull.Value);
                
                //New Addition 03082022
                AddParamToSQLCmd(comm, "@officeCode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, (object)ofc.officeCode ?? DBNull.Value);
               // AddParamToSQLCmd(comm, "@isEmailSent", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ofc.isEmailSent ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@isExclusive", SqlDbType.Bit, 1, ParameterDirection.Input, (object)ofc.isExclusive ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@categoryRelationId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.categoryRelationId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeWebsite", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeWebsite ?? DBNull.Value);
                //Merge Tables
                AddParamToSQLCmd(comm, "@countryId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.countryId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@stateProvinceId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.stateProvinceId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@cityId", SqlDbType.Int, 4, ParameterDirection.Input, (object)ofc.cityId ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine1", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeAddressLine1 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine2", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeAddressLine2 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeAddressLine3", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeAddressLine3 ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePostalCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePostalCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePoBox", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePoBox ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCountryAreaCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeCountryAreaCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officeCellNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officeCellNumber ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@extention", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.extention ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePhoneIsoCode", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePhoneIsoCode ?? DBNull.Value);
                AddParamToSQLCmd(comm, "@officePhoneNumber", SqlDbType.NVarChar, 250, ParameterDirection.Input, (object)ofc.officePhoneNumber ?? DBNull.Value);
                ExecuteNonQueryCommand(comm, "spUpdateOffice", ofc.dbName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<clsOffice> SelectAllOffice(string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectAllOffice");
                
                List<clsOffice> officeList = new List<clsOffice>();
                TExecuteReaderCmd<clsOffice>(comand, TGenerateSOFieldFromReaderactiveOfficeList<clsOffice>, ref officeList);
                if (officeList != null)
                {
                    return officeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOffice>();
        }
        public List<clsOffice> SelectAllOfficeById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeById");
                comand.Parameters.AddWithValue("@id", id);
                List<clsOffice> officeList = new List<clsOffice>();
                TExecuteReaderCmd<clsOffice>(comand, TGenerateSOFieldFromReaderactiveOfficeList<clsOffice>, ref officeList);
                if (officeList != null)
                {
                    return officeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOffice>();
        } 
        public List<clsOffice> SelectOfficeByOfficeTypeId(int officeTypeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeByOfficeTypeId");
                comand.Parameters.AddWithValue("@officeTypeId", officeTypeId);
                List<clsOffice> officeList = new List<clsOffice>();
                TExecuteReaderCmd<clsOffice>(comand, TGenerateSOFieldFromReaderactiveOfficeList<clsOffice>, ref officeList);
                if (officeList != null)
                {
                    return officeList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new List<clsOffice>();
        }
        public void TGenerateSOFieldFromReaderactiveOfficeList<T>(SqlDataReader returnData, ref List<clsOffice> activeOffice)
        {
            try
            {
                while (returnData.Read())
                {
                    clsOffice obj = new clsOffice();
                    obj.id = returnData["id"] is DBNull ? (int)0 : (int)returnData["id"];
                    obj.officeName = returnData["officeName"] is DBNull ? (string)string.Empty : (string)returnData["officeName"];
                    obj.officeTypeId = returnData["officeTypeId"] is DBNull ? (int)0 : (int)returnData["officeTypeId"];
                    obj.taxNo = returnData["taxNo"] is DBNull ? (string)string.Empty : (string)returnData["taxNo"];
                    obj.businessLicenseNumber = returnData["businessLicenseNumber"] is DBNull ? (string)string.Empty : (string)returnData["businessLicenseNumber"];
                    obj.businessTypeId = returnData["businessTypeId"] is DBNull ? (int)0 : (int)returnData["businessTypeId"]; 
                    obj.businessTypeName = returnData["businessTypeName"] is DBNull ? (string)string.Empty : (string)returnData["businessTypeName"];
                    obj.reportingOfficeId = returnData["reportingOfficeId"] is DBNull ? (int)0 : (int)returnData["reportingOfficeId"];
                    obj.reportingOfficeName = returnData["reportingOfficeName"] is DBNull ? (string)string.Empty : (string)returnData["reportingOfficeName"];

                    obj.companyTypeId = returnData["companyTypeId"] is DBNull ? (int)0 : (int)returnData["companyTypeId"];
                    obj.companyTypeName = returnData["companyTypeName"] is DBNull ? (string)string.Empty : (string)returnData["companyTypeName"];

                    obj.baseCurrencyId = returnData["baseCurrencyId"] is DBNull ? (int)0 : (int)returnData["baseCurrencyId"];
                    obj.currencyName = returnData["currencyName"] is DBNull ? (string)string.Empty : (string)returnData["currencyName"];
                    obj.officeActivateBy = returnData["officeActivateBy"] is DBNull ? (int)0 : (int)returnData["officeActivateBy"];
                    obj.officeActiveStsId = returnData["officeActiveStsId"] is DBNull ? (int)0: (int)returnData["officeActiveStsId"];
                    obj.activeDate = returnData["activeDate"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["activeDate"];

                    obj.active = returnData["active"] is DBNull ? (bool)true : (bool)returnData["active"];
                    obj.createdOn = returnData["createdOn"] is DBNull ? (DateTime)DateTime.Now : (DateTime)returnData["createdOn"];

                    obj.officeCode = returnData["officeCode"] is DBNull ? (string)string.Empty : (string)returnData["officeCode"];
                    obj.officeFolderPath = returnData["officeFolderPath"] is DBNull ? (string)string.Empty : (string)returnData["officeFolderPath"];
                    obj.isEmailSent = returnData["isEmailSent"] is DBNull ? (bool)true : (bool)returnData["isEmailSent"];
                    if (ColumnExists(returnData,"isExclusive"))
                    {
                        obj.isExclusive = returnData["isExclusive"] is DBNull ? (bool)true : (bool)returnData["isExclusive"];
                    }
                    obj.categoryRelationId = returnData["categoryRelationId"] is DBNull ? (int)0 : (int)returnData["categoryRelationId"];
                    if (ColumnExists(returnData, "categoryRelation"))
                    {
                        obj.categoryRelation = returnData["categoryRelation"] is DBNull ? (string) string.Empty : (string)returnData["categoryRelation"];
                    }
                    if (ColumnExists(returnData, "officeWebsite"))
                    {
                        obj.officeWebsite = returnData["officeWebsite"] is DBNull ? (string)string.Empty : (string)returnData["officeWebsite"];
                    }
                    //Table Merge
                    obj.countryId = returnData["countryId"] is DBNull ? (int) 0: (int)returnData["countryId"];
                    obj.stateProvinceId = returnData["stateProvinceId"] is DBNull ? (int) 0: (int)returnData["stateProvinceId"];
                    obj.cityId = returnData["cityId"] is DBNull ? (int) 0: (int)returnData["cityId"];
                    obj.officeAddressLine1 = returnData["officeAddressLine1"] is DBNull ? (string) string.Empty: (string)returnData["officeAddressLine1"];
                    obj.officeAddressLine2 = returnData["officeAddressLine2"] is DBNull ? (string) string.Empty: (string)returnData["officeAddressLine2"];
                    obj.officeAddressLine3 = returnData["officeAddressLine3"] is DBNull ? (string) string.Empty: (string)returnData["officeAddressLine3"];
                    obj.officePostalCode = returnData["officePostalCode"] is DBNull ? (string) string.Empty: (string)returnData["officePostalCode"];
                    obj.officePoBox = returnData["officePoBox"] is DBNull ? (string) string.Empty: (string)returnData["officePoBox"];
                    obj.officeCountryAreaCode = returnData["officeCountryAreaCode"] is DBNull ? (string) string.Empty: (string)returnData["officeCountryAreaCode"];
                    obj.officeCellNumber = returnData["officeCellNumber"] is DBNull ? (string) string.Empty: (string)returnData["officeCellNumber"];
                    obj.extention = returnData["extention"] is DBNull ? (string) string.Empty: (string)returnData["extention"];
                    obj.officePhoneIsoCode = returnData["officePhoneIsoCode"] is DBNull ? (string) string.Empty: (string)returnData["officePhoneIsoCode"];
                    obj.officePhoneNumber = returnData["officePhoneNumber"] is DBNull ? (string) string.Empty: (string)returnData["officePhoneNumber"];
                    if (ColumnExists(returnData, "officeTypeName"))
                    {
                        obj.officeTypeName = returnData["officeTypeName"] is DBNull ? (string)string.Empty : (string)returnData["officeTypeName"];
                    }
                    if (ColumnExists(returnData, "countryName"))
                    {
                        obj.countryName = returnData["countryName"] is DBNull ? (string)string.Empty : (string)returnData["countryName"];
                    }
                    if (ColumnExists(returnData, "stateProvinceName"))
                    {
                        obj.stateProvinceName = returnData["stateProvinceName"] is DBNull ? (string)string.Empty : (string)returnData["stateProvinceName"];
                    }  
                    if (ColumnExists(returnData, "cityName"))
                    {
                        obj.cityName = returnData["cityName"] is DBNull ? (string)string.Empty : (string)returnData["cityName"];
                    }
                    activeOffice.Add(obj);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public string GetOfficeFolderPathById(int id,string dbName)
        {
            try
            {
                SetDBName(dbName);
                string officeFolderPath = "";
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@id", id);
                SetCommandType(comand, CommandType.StoredProcedure, "spGetOfficeFolderPathById");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {

                        if (returnData.Read())
                        {

                            officeFolderPath = returnData["officeFolderPath"] is DBNull ? (string)string.Empty : (string)returnData["officeFolderPath"];
                        }
                        else
                        {
                            officeFolderPath = null;
                        }

                    }

                    con.Close();

                    return officeFolderPath;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
        public string GetMaxCode(string dbName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                return ExecuteReaderStringCode(cmd, "spGetOfficeMaxCode", dbName);
            }
        }
        public List<clsOffice> SelectOfficeForListByReportingOfficeId(int reportingOfficeId, string dbName)
        {
            try
            {
                SetDBName(dbName);
                SqlCommand comand = new SqlCommand();
                SetCommandType(comand, CommandType.StoredProcedure, "spSelectOfficeForListByReportingOfficeId");
                comand.Parameters.AddWithValue("@reportingOfficeId", reportingOfficeId);
                List<clsOffice> activeList = new List<clsOffice>();
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            clsOffice obj = new clsOffice();
                            obj.id = reader["id"] is DBNull ? (int)0 : (int)reader["id"];
                            obj.officeCode = reader["officeCode"] is DBNull ? (string)string.Empty : (string)reader["officeCode"];
                            obj.officeName = reader["officeName"] is DBNull ? (string)string.Empty : (string)reader["officeName"];
                            obj.officeTypeName = reader["officeTypeName"] is DBNull ? (string)string.Empty : (string)reader["officeTypeName"];
                            obj.countryName = reader["countryName"] is DBNull ? (string)string.Empty : (string)reader["countryName"];
                            obj.cityName = reader["cityName"] is DBNull ? (string)string.Empty : (string)reader["cityName"];
                            obj.perStatus = reader["perStatus"] is DBNull ? (string)string.Empty : (string)reader["perStatus"];
                            obj.isExclusive = reader["isExclusive"] is DBNull ? (bool) false : (bool)reader["isExclusive"];
                            activeList.Add(obj);
                        }

                    }

                    con.Close();


                }
                return activeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckOfficeExclusive(int countryId , int cityId,string dbName)
        {
            try
            {
                if (dbName != null && dbName != "")
                {
                    dbname = dbName;
                }
                bool isExclusive = false;
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@countryId", countryId);
                comand.Parameters.AddWithValue("@cityId", cityId);
                SetCommandType(comand, CommandType.StoredProcedure, "spCheckOfficeExclusive");

                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    comand.Connection = con;
                    con.Open();
                    using (SqlDataReader returnData = comand.ExecuteReader())
                    {

                        if (returnData.Read())
                        {

                            isExclusive = returnData["isExclusive"] is DBNull ? (bool)false : (bool)returnData["isExclusive"];
                        }
                        else
                        {
                            isExclusive = false;
                        }

                    }

                    con.Close();

                    return isExclusive;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
    }
}
