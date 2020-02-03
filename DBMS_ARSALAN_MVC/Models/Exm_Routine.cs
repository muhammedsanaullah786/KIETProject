using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DBMS_ARSALAN_MVC.Models
{
    public class Exm_Routine
    {
        public int RoomNo { get; set; }
        public TimeSpan? Timing { get; set; }
        public DateTime? Date { get; set; }
        public int? ExamID { get; set; }

        public void Insert(Exm_Routine s)
        {
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("",Connectivity.conn);



            cmd.ExecuteNonQuery();
         



        }
        public IEnumerable<Exm_Routine> GetExamDetaile()
        {
            Exm_Routine er;

            List<Exm_Routine> list = new List<Exm_Routine>();
                     Connectivity.GetConnect();
                     SqlCommand cmd = new SqlCommand("select * from Exm_Routine", Connectivity.conn);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                          er = new Exm_Routine();

                        er.RoomNo = Convert.ToInt32(reader[0]);
                        //er.Timing = Convert( reader[1]);
                        er.Date =Convert.ToDateTime( reader[2]);
                        er.ExamID =Convert.ToInt32( reader[3]);
                       




                        list.Add(er);
                

                    }
                 
                    return list;
                }
        public void Update(Exm_Routine s1)
        {
            Connectivity.GetConnect();
          SqlCommand cmd = new SqlCommand("",Connectivity.conn);
           cmd.ExecuteNonQuery();
         


        }

    }
           
        
    
   
    
    public class Exam
    {
        public int ExamID { get; set; }
        public int SubjID { get; set; }

        public IEnumerable<Exam> GetExm()
        {


            List<Exam> list = new List<Exam>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandTimeout = 10;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Exam d1 = new Exam();
                d1.ExamID = Convert.ToInt32(reader[0]);
                d1.SubjID = Convert.ToInt32(reader[1]);



                list.Add(d1);



            }

            return list;




        }

        public Exam ExmByID(int id)
        {

            return GetExm().FirstOrDefault(x => x.ExamID == id);

        }
        public void Update(Exam D1)
        {
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpUpdDep", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptID", D1.ExamID);
            cmd.Parameters.AddWithValue("@DeptName", D1.SubjID);
            cmd.ExecuteNonQuery();

        }

    }
}

 