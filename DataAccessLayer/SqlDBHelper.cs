using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace DataAccessLayer
{
   public class SqlDBHelper
    {
        const string dbname = "EvolveMain";
     
        const string CONNECTION_STRING = @"Data Source=DESKTOP-SU56F14;Initial Catalog=" + dbname + ";Integrated Security=True";
       

        // This function will be used to execute R(CRUD) operation of parameterless commands
        internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {

                        throw;
                    }
                }
            }

            return table;
        }

        // This function will be used to execute R(CRUD) operation of parameterized commands
        internal static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return table;
        }

        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        internal static bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        result = cmd.ExecuteNonQuery();
                    }
                    catch(Exception)
                    {
                        return false;  //throw ;
                    }
                }
            }

            return (result > 0);
        }

        internal static void ExecuteCommand(string CommandName, CommandType cmdType)
        {

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        cmd.ExecuteNonQuery();


                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        internal static string ExecuteGetSingleStringCommand(string CommandName, CommandType cmdType)
        {
         string MaxCode = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = cmdType;
                        cmd.CommandText = CommandName;

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            MaxCode = (string)reader["Code"];
                        }
                        conn.Close();

                    }
                }
                return MaxCode;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
