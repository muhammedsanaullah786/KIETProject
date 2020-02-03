using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using DBMS_ARSALAN_MVC.Areas.StudentArea.Controllers;

namespace DBMS_ARSALAN_MVC.Models
{
    public class BussinesProtectionLogi
    {
      public  int a;
        public int b;
        public void mth(string vl)
        {
            //    StModController sc = new StModController();
            //    sc.StudentLMS(vl);
            StModController.id = vl;



        }


        public User Getusers(User usr)
        {
          
            User user = new User();
            Connectivity.GetConnect();
            SqlCommand CMD = new SqlCommand("LoginProc", Connectivity.conn);

            CMD.CommandType = CommandType.StoredProcedure;
            
            
            CMD.Parameters.AddWithValue("@email", usr.email);

            CMD.Parameters.AddWithValue("@password", usr.password);
            // SqlCommand CMD = new SqlCommand("SELECT [id] ,[email],[password],[LgTypeID] FROM[ALMS].[dbo].[LoginUsers]", Connectivity.conn);


//          List<User> list = new List<User>();
            SqlDataReader reader = CMD.ExecuteReader();
           // User user; 
            while (reader.Read())
            {
                // user = new User();

                b = Convert.ToInt32(reader[0]);
                user.email = reader[1].ToString();
                user.password = reader[2].ToString();
                a = Convert.ToInt32(reader[3]);

                //list.Add(user);
            }
            reader.Close();
            return user;
        }

        //public User Login(User user)
        //{
        //    return Getusers(user).FirstOrDefault(x => x.email == user.email && x.password == user.password);

        //}

        public void Register(RegisterUser user)
        {
            Connectivity.GetConnect();
            SqlCommand CMD = new SqlCommand("SploginCrud", Connectivity.conn);

            CMD.CommandType = CommandType.StoredProcedure;

            CMD.Parameters.AddWithValue("@stype", 1);

            CMD.Parameters.AddWithValue("@email", user.email);

            CMD.Parameters.AddWithValue("@password", user.password);

            CMD.Parameters.AddWithValue("@LgTypeID", user.LgTypeID);
            CMD.ExecuteNonQuery();
           
               
            
            
        }
    }
}