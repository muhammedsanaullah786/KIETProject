using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models
{
    public class Fee
    {
        [Display(Name = "Serial #")]
        public int Serial { get; set; }

        [Display(Name = "Amount")]
        public decimal amount { get; set; }

        [Display(Name = "Student ID")]
        public int SID { get; set; }



        [Display(Name = "Fee Type")]
        public int ft { get; set; }



        public IEnumerable<Fee> GetFee()
        {

            Fee fe = new Fee();
            List<Fee> list = new List<Fee>();

            Connectivity.GetConnect();
             
                    SqlCommand cmd = new SqlCommand("select SerialNO,Amount,SID,FeeTypeID from Fee", Connectivity.conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        fe.Serial = Convert.ToInt32(reader[0]);
                        fe.SID = Convert.ToInt32(reader[1]);
                        fe.amount = Convert.ToDecimal(reader[2]);
                        fe.ft = Convert.ToInt32(reader[3]);

                        list.Add(fe);

                       

                    }
                   
                    return list;
                

            
        }
        public void InsertFee(Fee s)
        {
            Connectivity.GetConnect();

        
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO[dbo].[Fee]([Amount],[SID],[FeeTypeID] VALUES ('{0}','{1}','{2}')", s.amount, s.SID, s.ft), Connectivity.conn);




            cmd.ExecuteNonQuery();
            


        }

      
     
        public void Update(Fee s1)
        {
               Connectivity.GetConnect();
               string q = "update Fee Set Amount='" + s1.amount + "',SID='" +s1.SID + "',FeeTypeID='" + s1.ft + "' where SerialNO=" + s1.Serial;
               SqlCommand cmd = new SqlCommand(q, Connectivity.conn);
               cmd.ExecuteNonQuery();

        }


    }
}