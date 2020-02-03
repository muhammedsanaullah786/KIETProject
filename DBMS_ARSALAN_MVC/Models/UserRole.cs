using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DBMS_ARSALAN_MVC.Models
{
    public class UserRole
    {
        public int LgTypeID { get; set; }
        public string RoleDesc { get; set; }


        public void Insert(UserRole s)
        {
            string con = ConfigurationManager.ConnectionStrings["ALMS"].ConnectionString;
            SqlConnection conn = new SqlConnection(con);

            conn.Open();
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO[dbo].[UserRole]([LgTypeID],[RoleDesc]VALUES ('{0}','{1}'",s.LgTypeID,s.RoleDesc), conn);
        



            cmd.ExecuteNonQuery();
            conn.Close();



        }
        public List<UserRole> GetRole()
        {

            UserRole s1;
            List<UserRole> list = new List<UserRole>();

            Connectivity.GetConnect();
                    SqlCommand cmd = new SqlCommand("UsrROl", Connectivity.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    s1 = new UserRole();
                    s1.LgTypeID = Convert.ToInt32(reader[0]);
                        s1.RoleDesc = reader[1].ToString();
                       

                        list.Add(s1);

                        // list.DefaultIfEmpty();

                    }
            reader.Close();
                    return list;
                

           
        }
      
        public string DeleteUR(int sid)
        {


                    Connectivity.GetConnect();
                    SqlCommand cmd = new SqlCommand("deletST", Connectivity.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sid", sid);
                    string RowEffected = cmd.ExecuteScalar().ToString();
                   
                    return RowEffected;


                        



        }
        public void Update(UserRole s1)
        {


                    Connectivity.GetConnect();

                    string q = "update UserRole Set RoleDesc='"+RoleDesc+ "' where LgTypeID='"+LgTypeID+"'";
                  
                    SqlCommand cmd = new SqlCommand(q, Connectivity.conn);
                    
                    cmd.ExecuteNonQuery();



              



        }



    }
}