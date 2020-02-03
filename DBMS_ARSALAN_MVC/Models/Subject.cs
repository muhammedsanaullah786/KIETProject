using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DBMS_ARSALAN_MVC.Models
{
    public class Subject
    {

        public int SubjID { get; set; }
        public string SubjName { get; set; }

        public List<Subject> SubjectsSHow()
        {
            Subject s1;

            List<Subject> list = new List<Subject>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("SpCrudSubj", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateMentType", 2);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1 = new Subject();
                s1.SubjID = Convert.ToInt32(reader[0]);
                s1.SubjName = reader[1].ToString();
              

                list.Add(s1);



            }
            reader.Close();
            return list;




        }
        public Subject DepByID(int id)
        {

            return SubjectsSHow().FirstOrDefault(x => x.SubjID == id);

        }










        public void Update(Subject D1)
        {
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpCrudSubj", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateMentType", 3);

           

            cmd.Parameters.AddWithValue("@SubjID", D1.SubjID);
            cmd.Parameters.AddWithValue("@SubjName", D1.SubjName);

            cmd.ExecuteNonQuery();

        }


        public void Insert(Subject D1)
        {
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpCrudSubj", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateMentType", 1);
            cmd.Parameters.AddWithValue("@SubjID", D1.SubjID);
            cmd.Parameters.AddWithValue("@SubjName", D1.SubjName);
            cmd.ExecuteNonQuery();

        }

        public void Delete(Subject D1)
        {
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpCrudSubj", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateMentType", 4);
            cmd.Parameters.AddWithValue("@SubjID", D1.SubjID);
        
            cmd.ExecuteNonQuery();

        }






    }
}