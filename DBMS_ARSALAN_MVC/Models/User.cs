using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DBMS_ARSALAN_MVC.Models
{
    public class User
    {
      //  public int id { get; set; }

        //public int LgTypeID { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}