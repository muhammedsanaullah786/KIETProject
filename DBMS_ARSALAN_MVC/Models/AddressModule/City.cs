using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models.AddressModule
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
      
        public List<Towns> towns
        {
            get
            {
                TownsMthd TW = new TownsMthd();
                return TW.TownOfCity(id);
            }
        }

    }
}