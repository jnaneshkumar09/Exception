using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFile
{
    public static class ErrorLog
    {
        static string constr = ConfigurationManager.ConnectionStrings["constr1"].ConnectionString;
        public static void SendExceptionToDB(Exception exdb)
        {
            //string exepurl = System.Web.HttpContext.Current.Request.Url.ToString(); 123           
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("ExceptionLoggingToDataBase", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
            com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
            com.Parameters.AddWithValue("@ExceptionURL", "http://localhost:59449/WebForm1.aspx");
            com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
            com.ExecuteNonQuery();
        }       

    }       

    
}
