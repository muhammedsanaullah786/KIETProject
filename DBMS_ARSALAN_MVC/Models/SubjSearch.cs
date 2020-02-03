using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models
{
    public class SubjSearch
    {


        [Display(Name = "Student ID")]
        public int sid { get; set; }
        

        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Display(Name = "Subject ID")]
        public int SubjID { get; set; }
        [Display(Name = "Subject Name")]
        public string SubjName { get; set; }

        public IEnumerable<SubjSearch> Get(string SUbj)
        {
            SubjSearch s1;

            List<SubjSearch> list = new List<SubjSearch>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("SubSearch", Connectivity.conn);
            cmd.Parameters.AddWithValue("@SubjName", SUbj);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1 = new SubjSearch();
                s1.sid = Convert.ToInt32(reader[0]);
                s1.Fname = reader[1].ToString();
                s1.SubjID = Convert.ToInt32(reader[2]);
                s1.SubjName = reader[3].ToString();
             



               

                list.Add(s1);



            }
            reader.Close();
            return list;




        }

        //public SubjSearch Single(int id)
        //{

        //    return Get().FirstOrDefault(x => x.sid == id);

        //}

    }
}