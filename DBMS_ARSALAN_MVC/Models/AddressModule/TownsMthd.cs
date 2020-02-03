using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models.AddressModule
{
    public class TownsMthd
    {


        public IEnumerable<Towns> towns
        {
            get
            {
                Connectivity.GetConnect();
                SqlCommand cmd = new SqlCommand("Select * From towns", Connectivity.conn);
              
                List<Towns> towns = new List<Towns>();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Towns town = new Towns();
                    town.city_id = int.Parse(sdr["city_id"].ToString());
                    town.id = int.Parse(sdr["id"].ToString());
                    town.name = sdr["town"].ToString();
                    towns.Add(town);
                }
                return towns;
            }
        }

        public Towns TownByID(int Town_ID)
        {
            return towns.FirstOrDefault(x => x.id == Town_ID);
        }

        public List<Towns> TownOfCity(int City_ID)
        {
            return towns.Where(x => x.city_id == City_ID).ToList();

        }
    }
}