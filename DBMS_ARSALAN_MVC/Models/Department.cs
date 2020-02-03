using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models
{


    public class Department
    {

        public int DeptID { get; set; }
        public string DeptName { get; set; }

        public void Insert(Department d)
        {

            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SPinsDep", Connectivity.conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptName", d.DeptName);




            cmd.ExecuteNonQuery();




        }

        public IEnumerable<Department> GetDept()
        {


            List<Department> list = new List<Department>();
            Connectivity.GetConnect();

            SqlCommand cmd = new SqlCommand("SpDept", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.CommandTimeout = 10;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Department d1 = new Department();
                d1.DeptID = Convert.ToInt32(reader[0]);
                d1.DeptName = reader[1].ToString();


                list.Add(d1);



            }
            reader.Close();
            return list;




        }

        public Department DepByID(int id)
        {

            return GetDept().FirstOrDefault(x => x.DeptID == id);

        }


        







        public void Update(Department D1)
        {
            Connectivity.GetConnect();
            SqlCommand cmd = new SqlCommand("SpUpdDep", Connectivity.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DeptID", D1.DeptID);
            cmd.Parameters.AddWithValue("@DeptName", D1.DeptName);
            cmd.ExecuteNonQuery();

        }




    }
}
