using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models.SM
{
    public class StudentMTHD
    {
        public void Insert(Student s)
        {

            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpInsertStud", Connectivity.conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", s.Fname);
            //cmd.Parameters["@FirstName"].Value = s.Fname;
            cmd.Parameters.AddWithValue("@LastName", s.Lname);
            //cmd.Parameters["@LastName"].Value = s.Lname;
            cmd.Parameters.AddWithValue("@DOB", s.Dob);
            //cmd.Parameters["@DOB"].Value = s.Dob;
            cmd.Parameters.AddWithValue("@Gender", s.Gender);
            //cmd.Parameters["@Gender"].Value = s.Gender;
            cmd.Parameters.AddWithValue("@semester", s.Semester);
            //cmd.Parameters["@semester"].Value = s.Semester;
            cmd.Parameters.AddWithValue("@addmissiondate", s.DOA);
            //cmd.Parameters["@addmissiondate"].Value = s.DOA;
            cmd.Parameters.AddWithValue("@City", s.City);
            //cmd.Parameters["@City"].Value = s.City;
            cmd.Parameters.AddWithValue("@Area", s.Area);
            //cmd.Parameters["@Area"].Value = s.Area;
            cmd.Parameters.AddWithValue("@Street", s.Strt);
            //cmd.Parameters["@Street"].Value = s.Strt;
            cmd.Parameters.AddWithValue("@Hno", s.Hno);
            //cmd.Parameters["@Hno"].Value = s.Hno;



            cmd.ExecuteNonQuery();




        }

        public IEnumerable<Student> GetALLStudentDetaile()
        {
            Student s1;

            List<Student> list = new List<Student>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("SpSt", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandTimeout = 10;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               s1 = new Student();
                s1.sid = Convert.ToInt32(reader[0]);
                s1.Fname = reader[1].ToString();
                s1.Lname = reader[2].ToString();
                s1.Dob = reader[3].ToString();
                s1.Gender = Convert.ToBoolean(reader[4]);
                s1.Semester = Convert.ToInt32(reader[5]);



                s1.DOA = reader[6].ToString();

                s1.City = reader[7].ToString();
                s1.Area = reader[8].ToString();
                s1.Strt = reader[9].ToString();
                s1.Hno = reader[10].ToString();

                list.Add(s1);



            }
            reader.Close();
            return list;




        }

        public Student Single(int id)
        {

            return GetALLStudentDetaile().FirstOrDefault(x => x.sid == id);

        }


        public string DeleteStudent(int sid)
        {




            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("deletST", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid", sid);
            string RowEffected = cmd.ExecuteScalar().ToString();

            return RowEffected;


        }




        public void Update(Student s1)
        {



            Connectivity.GetConnect();
            string q = "update Student Set FirstName='" + s1.Fname + "',LastName='" + s1.Lname + "',DOB='" + s1.Dob + "',Gender='" + s1.Gender + "',semester='" + s1.Semester + "',addmissiondate='" + s1.DOA + "',City='" + s1.City + "',Area='" + s1.Area + "',Street='" + s1.Strt + "',Hno='" + s1.Hno + "' where sid=" + s1.sid;
            SqlCommand cmd = new SqlCommand(q, Connectivity.conn);
           
            cmd.ExecuteNonQuery();






        }


        //public void Update(Student s1)
        //{


        //            List<Student> list = new List<Student>();
        //            Connectivity.GetConnect();
        //            SqlCommand cmd = new SqlCommand("UpdateStudent", Connectivity.conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@sid", s1.sid);
        //            cmd.Parameters.AddWithValue("@FirstName", s1.Fname);

        //            cmd.Parameters.AddWithValue("@LastName", s1.Lname);

        //            cmd.Parameters.AddWithValue("@DOB", s1.Dob);

        //            cmd.Parameters.AddWithValue("@Gender", s1.Gender);

        //            cmd.Parameters.AddWithValue("@semester", s1.Semester);

        //            cmd.Parameters.AddWithValue("@addmissiondate", s1.DOA);

        //            cmd.Parameters.AddWithValue("@City", s1.City);


        //            cmd.Parameters.AddWithValue("@Area", s1.Area);

        //            cmd.Parameters.AddWithValue("@Street", s1.Strt);

        //            cmd.Parameters.AddWithValue("@Hno", s1.Hno);

        //            //cmd.CommandType = CommandType.StoredProcedure;
        //            //cmd.Parameters.Add(s1.sid);
        //            //cmd.Parameters.Add(s1.Fname);

        //            //cmd.Parameters.Add(s1.Lname);

        //            //cmd.Parameters.AddWithValue("@DOB", s1.Dob);

        //            //cmd.Parameters.AddWithValue("@Gender", s1.Gender);

        //            //cmd.Parameters.AddWithValue("@semester", s1.Semester);

        //            //cmd.Parameters.AddWithValue("@addmissiondate", s1.DOA);

        //            //cmd.Parameters.AddWithValue("@@City", s1.City);


        //            //cmd.Parameters.AddWithValue("@Area", s1.Area);

        //            //cmd.Parameters.AddWithValue("@Street", s1.Strt);

        //            //cmd.Parameters.AddWithValue("@Hno", s1.Hno);

        //            //cmd.ExecuteNonQuery();









        //}








    }



}