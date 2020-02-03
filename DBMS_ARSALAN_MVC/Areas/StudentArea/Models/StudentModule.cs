using DBMS_ARSALAN_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Areas.StudentArea.Models
{
    public class StudentModule
    {
        //subject show
        //subj add/drop
        [Required]
        [Display(Name ="Subject ID")]
        public int SubjID { get; set; }
        [Display(Name = "Subject Name")]

        public string SubjName { get; set; }
        [Display(Name = "Student Name")]
        public string Fname { get; set; }

        [Display(Name = "Teacher Name")]
        public string Tname { get; set; }
        public List<StudentModule> SubjectsSHow(string Fname)
        {
            StudentModule s1;

            List<StudentModule> list = new List<StudentModule>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("StudenDet", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
          //  cmd.Parameters.AddWithValue("@Stype", 1);
            cmd.Parameters.AddWithValue("@FirstName", Fname);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1 = new StudentModule();
                s1.SubjID = Convert.ToInt32(reader[0]);
                s1.SubjName = reader[1].ToString();
                s1.Tname = reader[2].ToString();
                s1.Fname = reader[2].ToString();


                list.Add(s1);



            }
            reader.Close();
            return list;




        }

        public List<StudentModule> SubjectsSHow(int id)
        {
            StudentModule s1;

            List<StudentModule> list = new List<StudentModule>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("StudenDet", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 2);
            cmd.Parameters.AddWithValue("@sid", id);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1 = new StudentModule();
                s1.SubjID = Convert.ToInt32(reader[0]);
                s1.SubjName = reader[1].ToString();
                s1.Tname = reader[2].ToString();
                s1.Fname = reader[3].ToString();

                list.Add(s1);



            }
            reader.Close();
            return list;




        }
    }
}