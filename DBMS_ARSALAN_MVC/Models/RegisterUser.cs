using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC.Models
{
    public class RegisterUser
    {
         public int id { get; set; }
    
        public int LgTypeID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}