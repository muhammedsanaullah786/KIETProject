using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DBMS_ARSALAN_MVC.Models
{
    public class Staff
    {

        public int Staffid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
  
        public string City { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }
        public string Hno { get; set; }
        public int? DeptID { get; set; }
        public string DeptName { get; set; }
        public decimal? salary { get; set; }

       
        public void Insert(Staff s)
        {

            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpStaffCrud", Connectivity.conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 2);
            cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
       
            cmd.Parameters.AddWithValue("@LastName", s.LastName);
            cmd.Parameters.AddWithValue("@DOB", s.DOB);
            cmd.Parameters.AddWithValue("@Gender", s.Gender);
           
            cmd.Parameters.AddWithValue("@City", s.City);
           
            cmd.Parameters.AddWithValue("@Area", s.Area);
          
            cmd.Parameters.AddWithValue("@Street", s.Street);
            
            cmd.Parameters.AddWithValue("@Hno", s.Hno);

            cmd.Parameters.AddWithValue("@DeptID", s.DeptID);

            cmd.Parameters.AddWithValue("@salary", s.salary);




            cmd.ExecuteNonQuery();




        }

        public IEnumerable<Staff> GetStaff()
        {
            Staff s1;

          List <Staff> list = new List<Staff>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("SpStaffCrud", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 1);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                s1= new Staff();
                s1.Staffid = Convert.ToInt32(reader[0]);
                s1.FirstName = reader[1].ToString();
                s1.LastName = reader[2].ToString();
                s1.DOB = Convert.ToDateTime(reader[3]);
                s1.Gender = reader[4].ToString();               
                s1.City = reader[5].ToString();
                s1.Area = reader[6].ToString();
                s1.Street = reader[7].ToString();
                s1.Hno = reader[8].ToString();
                s1.DeptID =Convert.ToInt32 (reader[9]);
                s1.DeptName = reader[10].ToString();
                s1.salary =Convert.ToDecimal( reader[11]);

                list.Add(s1);



            }
            reader.Close();

            return list;




        }

        public List<Staff> GetDepartments()
        {
            Connectivity.GetConnect();

            Staff c1;
            List<Staff> clist = new List<Staff>();

            //SqlCommand cmd = new SqlCommand("Select DeptID,DeptName From Department", Connectivity.conn);
            SqlCommand cmd = new SqlCommand("[SpCrudDep]", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 1);
            
            
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                c1 = new Staff();
                c1.DeptID = int.Parse(reader[0].ToString());
                c1.DeptName = reader[1].ToString();
                clist.Add(c1);
            }
            reader.Close();
            return clist;

        }

        public Staff StID(int id)
        {

            return GetStaff().FirstOrDefault(x => x.Staffid == id);

        }


        public string DeleteStaff(int Stid)
        {




            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpStaffCrud", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 4);

            cmd.Parameters.AddWithValue("@Staffid", Stid);
            string RowEffected = cmd.ExecuteScalar().ToString();

            return RowEffected;


        }

        public void Update(Staff s1)
        {



            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpStaffCrud", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Stype", 3);

            cmd.Parameters.AddWithValue("@Staffid", s1.Staffid);
            cmd.Parameters.AddWithValue("@FirstName", s1.FirstName);
            cmd.Parameters.AddWithValue("@LastName", s1.LastName);
            cmd.Parameters.AddWithValue("@DOB", s1.DOB);
            cmd.Parameters.AddWithValue("@Gender", s1.Gender);
            cmd.Parameters.AddWithValue("@City", s1.City);
            cmd.Parameters.AddWithValue("@Area", s1.Area);
            cmd.Parameters.AddWithValue("@Street", s1.Street);
            cmd.Parameters.AddWithValue("@Hno", s1.Hno);
            cmd.Parameters.AddWithValue("@DeptID", s1.DeptID);
            cmd.Parameters.AddWithValue("@salary", s1.salary);



            cmd.ExecuteNonQuery();






        }






    }
}
   