using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
namespace DataAccessLayer
{
  public  class LoginDAL :SQLDataAccess
    {
        //public DataTable Login(Login logins,string DBName,string procedureName)
        //{
        //    DataTable dt = new DataTable();
        //    SqlParameter[] parameters = new SqlParameter[]
        //  {

        //        new SqlParameter("@LoginCode", logins.LoginCode),
        //        new SqlParameter("@LoginPassword", logins.LoginPassword),

        //  };

        //    dt= SqlDBHelperClient.ExecuteParamerizedSelectCommand(procedureName, CommandType.StoredProcedure, parameters, DBName);
        //    return dt;

        //}
     
    }
}
