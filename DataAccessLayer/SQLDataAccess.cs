using Dapper;
using EntityLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading;



namespace DataAccessLayer
{
    public class SQLDataAccess
    {
        public static  string dbname = "EvolveMain";

        //   static string connectionString = @"Data Source=DESKTOP-SU56F14;Initial Catalog=" + dbname + ";Integrated Security=True";
        
        public SqlConnection sqlcon;
        string pconnectionString = string.Empty;
        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            //if (hostName == "DESKTOP-3RATTV7")
            //{
            //    dbname = "EvolveLocal";
            //}
            // Console.WriteLine(hostName);
            // Get the IP
            return Dns.GetHostEntry(hostName).AddressList[0].ToString(); //"DESKTOP-DVJUJAM";
        }
        public string ConnectionString
        {
            get
            {
                //_____________ uncommit by SAQIB   --> UserName sa123  was not working ________________ 6/23/2023
                pconnectionString = string.Format("Data Source=.;Initial Catalog={0};Integrated Security=True", dbname);

                //pconnectionString = string.Format("Data Source={0};Initial Catalog={1};User Id=sa123;Password=DB_AMS@321!@", GetIpAddress(), dbname);
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(pconnectionString);
                if (builder != null)
                {
                    Common.UserName = builder.UserID;
                    Common.Password = builder.Password;
                    Common.ServerName = builder.DataSource;
                }
                return pconnectionString;
            }
            set
            {
               // connectionString = value;
            }
        }

        string strServer = ".\\sqlexpress";

        public SQLDataAccess()
        {
         
            //ServerDAL activeDAL = new ServerDAL();
            //Server activeServer = activeDAL.ServerSelect();
            //if (activeServer != null)
            //{
            //    sqlcon = new SqlConnection(@"Data Source=" + activeServer.Servername + ";Initial Catalog=" + path + ";user id=" + activeServer.Login + ";password=" + activeServer.Passwrord + ";Integrated Security=True;Connect Timeout=120;User Instance=True");
            //}
            //System.Configuration.Configuration config2 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //string pconnectionString = config2.ConnectionStrings.ConnectionStrings["CrossFitConnectionString"].ToString();

            sqlcon = new SqlConnection(ConnectionString);
            try
            {
                if (sqlcon.Database != string.Empty)
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Dispose();
                        SqlConnection.ClearAllPools();
                        sqlcon.ConnectionString = ConnectionString;
                        sqlcon.Open();
                    }
                }
                else
                {
                    //Application.Run(new FormActivation());
              //      Messages.InformationMessage("Could not connect to your database... Please check your SQL Configuration");
                }
            }
            catch (SqlException sEx)
            {

                int i = sEx.Number;
                if (i == 233)
                {
                    Reconnect();
                }
                else if (i == -1)
                {
               //     Messages.InformationMessage("SQL connection failure... Please check the instance name of your sqlexpress with " + Application.StartupPath + " \\sys.txt");
                }
                else if (i == 18493)
                {
                    ChangeConnectionForServer();
                }
                else
                {
               //     Messages.InformationMessage("Could not connect to your database... Please check your SQL Configuration");
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Catche any other exception
            }
            finally
            {

            }
            try
            {
                //PrintWorks.frmDBConnection.connectionString = sqlcon.ConnectionString;
            }
            catch
            {
                //sql Error
            }
        }

        /// <summary>
        /// SQL Express may take time to start up due to AutoClose Behaviour of SQLEXPRESS
        /// 
        /// </summary>
        private void Reconnect()
        {

            try
            {
                Thread.Sleep(30000);
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();

                }
            }
            catch (Exception)
            {

              //  Messages.InformationMessage("Your SQL Server is starting up... Please close and re-open the application");

            }
        }

        /// <summary>
        /// Cheanges the connection string to support SQLServer version instead of SQLExpress
        /// </summary>
        private void ChangeConnectionForServer()
        {
            sqlcon = new SqlConnection(@"Data Source=" + strServer + ";AttachDbFilename=" + "path" + ";Integrated Security=True;Connect Timeout=120;");
        }

        /* string connectionString = string.Empty;
         protected string ConnectionString
         {
             get
             {
                 if (ConfigurationManager.ConnectionStrings["CrossFitConnectionString"] == null)
                     throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain <connectionStrings> <add key=\"CrossFit\" value=\"Server=(local);Integrated Security=True;Database=CrossFit\" </connectionStrings>"));

                 string connectionString = ConfigurationManager.ConnectionStrings["CrossFitConnectionString"].ConnectionString;

                 if (String.IsNullOrEmpty(connectionString))
                     throw (new NullReferenceException("ConnectionString configuration is missing from you web.config. It should contain  <connectionStrings> <add key=\"CrossFit\" value=\"Server=(local);Integrated Security=True;Database=CrossFit\" </connectionStrings>"));
                 else
                     return (connectionString);
             }*/
        // }

        /*** DELEGATE ***/

        protected delegate void TGenerateListFromReader<T>(SqlDataReader returnData, ref List<T> tempList);

        /*****************************  BASE CLASS IMPLEMENTATION *****************************/

        /*****************************  SQL HELPER METHODS *****************************/
        protected void AddParamToSQLCmd(SqlCommand sqlCmd,
                                      string paramId,
                                      SqlDbType sqlType,
                                      int paramSize,
                                      ParameterDirection paramDirection,
                                      object paramvalue)
        {

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));
            if (paramId == string.Empty)
                throw (new ArgumentOutOfRangeException("paramId"));

            SqlParameter newSqlParam = new SqlParameter();
            newSqlParam.ParameterName = paramId;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Direction = paramDirection;

            if (paramSize > 0)
                newSqlParam.Size = paramSize;

            if (paramvalue != null)
                newSqlParam.Value = paramvalue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        protected void ExecuteScalarCmd(SqlCommand sqlCmd)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                sqlCmd.ExecuteScalar();
            }
        }

        protected void SetCommandType(SqlCommand sqlCmd, CommandType cmdType, string cmdText)
        {
            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandText = cmdText;
        }

        protected void TExecuteReaderCmd<T>(SqlCommand sqlCmd, TGenerateListFromReader<T> gcfr, ref List<T> List)
        {
            if (ConnectionString == string.Empty)
                throw (new ArgumentOutOfRangeException("ConnectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                gcfr(sqlCmd.ExecuteReader(), ref List);
            }
        }

        protected bool IsValidDate(DateTime InputDate)
        {
            if ((InputDate > DateTime.MinValue && InputDate < DateTime.MaxValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsValidForeignKey(int ForeignKey)
        {
            if (ForeignKey > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool IsValidForeignKey(string ForeignKey)
        {
            if (ForeignKey.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        public int ExecuteInsertCommandReturnId(SqlCommand comm,string ProcedureName,string DBName)
        {
            try
            {
                if (DBName != null && DBName != "")
                {
                    dbname = DBName;
                }

                int Id = 0;
                SetCommandType(comm, CommandType.StoredProcedure, ProcedureName);
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
                    Id = comm.Parameters["@id"].Value is DBNull ? (int) 0 :(int) comm.Parameters["@id"].Value;
                    con.Close();
                }
                return Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
           
        }
        public  void ExecuteNonQueryCommand(SqlCommand comm, string ProcedureName, string DBName)
        {
            if (DBName != null && DBName != "")
            {
                dbname = DBName;
            }

            SetCommandType(comm, CommandType.StoredProcedure, ProcedureName);
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
        public string ExecuteReaderStringCode(SqlCommand comm, string ProcedureName, string DBName)
        {
            try
            { 
                if (DBName != null && DBName != "")
                {
                    dbname = DBName;
                }
                string MaxCode = "";
                SetCommandType(comm, CommandType.StoredProcedure, ProcedureName);
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
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                     
                        if (reader.Read())
                        {
                       
                            MaxCode = reader["Code"] is DBNull ? (string)string.Empty : (string)reader["Code"]; 
                         
                        }
                       
                    }

                    con.Close();


                }
                return MaxCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }
        public bool IsRecordExistCheck(SqlCommand comm, string ProcedureName, string DBName)
        {
            bool IsExist = true;
            try { 
            if (DBName != null && DBName != "")
            {
                dbname = DBName;
            }
            SetCommandType(comm, CommandType.StoredProcedure, ProcedureName);
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
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adpt = new SqlDataAdapter(comm))
                    {
                        adpt.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            IsExist = true;
                        }
                        else
                        {
                            IsExist = false;
                        }
                    }

                }
                return IsExist;
        }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public void SetDBName(string DBName)
        {
            if (DBName != null && DBName != "")
            {
                dbname = DBName;
            }
            if (ConnectionString == string.Empty)
            {
                throw (new ArgumentOutOfRangeException("ConnectionString"));
            }
        }
        //Dapper
        public int DapperExecuteCmd(string ProcedureName, string DBName,DynamicParameters Data,bool isInsert)
        {
            if (DBName != null && DBName != "")
            {
                dbname = DBName;
            }
            int Id = 0;
            if (ConnectionString == string.Empty)
            {
                throw (new ArgumentOutOfRangeException("ConnectionString"));
            }
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                con.Execute(ProcedureName, Data, commandType: CommandType.StoredProcedure);
                Id = isInsert ? Data.Get<int>("@id") : 0;
                con.Close();
            }
            return Id;
        }
        public List<object> DapperGetCmd(string ProcedureName, string DBName)
        {
            if (DBName != null && DBName != "")
            {
                dbname = DBName;
            }
        //    IList<object> objList = new IList<object>();
            if (ConnectionString == string.Empty)
            {
                throw (new ArgumentOutOfRangeException("ConnectionString"));
            }
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                IList<object> objList = SqlMapper.Query<object>(
                              con, ProcedureName).AsList<object>();
                con.Close();
                return objList.ToList();

            }
            
        } 
        public List<object> DapperGetCmd(string ProcedureName, string DBName, DynamicParameters param)
        {
            if (DBName != null && DBName != "")
            {
                dbname = DBName;
            }
        //    IList<object> objList = new IList<object>();
            if (ConnectionString == string.Empty)
            {
                throw (new ArgumentOutOfRangeException("ConnectionString"));
            }
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                IList<object> objList = SqlMapper.Query<object>(
                              con,ProcedureName, param, commandType: CommandType.StoredProcedure).AsList<object>();
                con.Close();
                return objList.ToList();

            }
            
        }
        /*****************************  GENARATE List HELPER METHODS  *****************************/
    }
}
