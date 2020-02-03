using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DBMS_ARSALAN_MVC.Models.SM
{
    public class Enroll
    {

        [Display(Name = "Student ID")]
        public int sid { get; set; }



        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [Display(Name = "Subject ID")]
        public int Subjid { get; set; }
        [Display(Name = "Subject Name")]
        public string SubjName { get; set; }
        [Display(Name = "Exam ID")]
        public int ExmID { get; set; }
       private int SOld = 0;
        public List<Enroll> EnrollSt()
        {
            Enroll s1;

            List<Enroll> list = new List<Enroll>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("SpCrudEnroll", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 2);
            // cmd.CommandTimeout = 10;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1 = new Enroll();
                s1.sid = Convert.ToInt32(reader[0]);
                s1.Fname = reader[1].ToString();
                s1.Subjid = Convert.ToInt32(reader[2]);
                s1.SubjName = reader[3].ToString();
                s1.ExmID = Convert.ToInt32(reader[4]);


                list.Add(s1);



            }
            reader.Close();
            return list;




        }
        public void Insert(Enroll en)
        {

            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpCrudEnroll", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 1);
            cmd.Parameters.AddWithValue("@Sid", en.sid);
          
            cmd.Parameters.AddWithValue("@SubjID", en.Subjid);
           
            //cmd.Parameters.AddWithValue("@examID", en.ExmID);
            cmd.Parameters.AddWithValue("@examID", 1);



            cmd.ExecuteNonQuery();




        }
        public Enroll Single(int id)
        {

            return EnrollSt().FirstOrDefault(x => x.Subjid == id);

        }

        public Enroll Gt(int id,int Sbid)
        {

            return EnrollSt().FirstOrDefault(x => x.sid == id&& x.Subjid == Sbid);

        }


        public void DropCourse(int CourseID)
        {
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpCrudEnroll", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 4);
            cmd.Parameters.AddWithValue("@SubjID", CourseID);
            cmd.ExecuteNonQuery();

           


        }




        public void Update(Enroll en)
        {
            
            SOld =Convert.ToInt32( Gt(Convert.ToInt32(en.sid), Convert.ToInt32(en.Subjid)).Subjid);
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpCrudEnroll", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 3);
            cmd.Parameters.AddWithValue("@Sid", en.sid);

            cmd.Parameters.AddWithValue("@Subj", SOld);
            cmd.Parameters.AddWithValue("@SubjID", en.Subjid);

            cmd.Parameters.AddWithValue("@examID", en.ExmID);

            //string q = "UPDATE [dbo].[Enroll]SET [SubjID] ='"+en.Subjid+"'"+",[examID]='"+en.ExmID+"'"+" WHERE [SubjID] = 6405 and [Sid]='"+en.sid+"'";
            //SqlCommand cmd = new SqlCommand(q, Connectivity.conn);

            cmd.ExecuteNonQuery();

        }

    }
}