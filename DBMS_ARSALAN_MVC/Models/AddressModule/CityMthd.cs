using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models.AddressModule
{
    public class CityMthd
    {
        public IEnumerable<City> cities
        {
            get
            {

                Connectivity.GetConnect();
                SqlCommand cmd = new SqlCommand("Select * From city", Connectivity.conn);
              
                List<City> cities = new List<City>();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    City city = new City();
                    city.id = int.Parse(sdr["id"].ToString());
                    city.name = sdr["city"].ToString();
                    cities.Add(city);
                }
                return cities;
            }
        }

        public City CityByID(int City_ID)
        {
            return cities.FirstOrDefault(x => x.id == City_ID);
        }


    }
}