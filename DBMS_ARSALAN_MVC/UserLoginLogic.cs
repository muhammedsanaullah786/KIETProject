using DBMS_ARSALAN_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBMS_ARSALAN_MVC
{
    public class UserLoginLogic
    {

        public static User user
        {
            get
            {

                if (HttpContext.Current.Session["user"] != null)
                {
                    return (User)HttpContext.Current.Session["user"];
                }
                return null;


            }
            set
            {

                HttpContext.Current.Session["user"] = value;
            }
        }
    }
}