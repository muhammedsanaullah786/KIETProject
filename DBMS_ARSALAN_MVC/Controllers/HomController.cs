using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class HomController : Controller
    {
        // GET: Hom
        public ActionResult Index()
        {
            if (UserLoginLogic.user != null)
            {
               // return View();
                return RedirectToAction("ALLStudent", "Student");


            }
            return RedirectToAction("Logout", "LoginJustification");

        }
    }
}