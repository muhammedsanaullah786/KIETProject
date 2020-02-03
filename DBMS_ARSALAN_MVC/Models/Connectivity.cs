using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models
{
    public class Connectivity
    {

        public static SqlConnection conn;

        public static SqlConnection GetConnect()
        {
            if (conn == null)
            {
                  conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ALMSDB"].ConnectionString);
                //conn = new SqlConnection("Data Source=DESKTOP-EE6C0CQ;Initial Catalog=ALMS;Integrated Security=True");

                conn.Open();
            }


            return conn;

        }
    }
}