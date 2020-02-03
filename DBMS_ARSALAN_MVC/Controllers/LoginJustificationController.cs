using DBMS_ARSALAN_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class LoginJustificationController : Controller
    {
        // GET: Auth
        [HttpGet]

        [ActionName("Login")]
        public ActionResult Login_get()
        {

          
            if (UserLoginLogic.user == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Hom");

        }


        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_Post()
        {
           
            User usr = new User();
            UpdateModel(usr);
            BussinesProtectionLogi ubl = new BussinesProtectionLogi();
            usr = ubl.Getusers(usr);
            int a = ubl.a;


            if (usr != null )
            {
                if (a==3)
                {
                    UserLoginLogic.user = usr;
                    return RedirectToAction("AdminPanel", "LoginJustification");
                }
                if (a == 2)
                {
                    UserLoginLogic.user = usr;
                    return RedirectToAction("Index", "Hom");
                }
                else 
                {
                    UserLoginLogic.user = usr;
                    ubl.mth(usr.email.ToString());
                    // return RedirectToAction("StudentLMS", "StMod");
                    return RedirectToAction("StudentLMS", "StMod", new { area = "StudentArea" });

                }

            }
            return RedirectToAction("Login");

        }
        [HttpGet]
        [ActionName("Register")]


        public ActionResult Register_Get()
        {
            if (UserLoginLogic.user == null)
            {
                return View();

            }
            return RedirectToAction("Index", "Hom");


        }



        [HttpPost]
       [ActionName("Register")]


        public ActionResult Register_Post()
        {
            try
            {
                RegisterUser user = new RegisterUser();
                UpdateModel(user);
                BussinesProtectionLogi ubl = new BussinesProtectionLogi();
                ubl.Register(user);

               
            }
           
        
                catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Soory Data Is Not Correct! ');</script>");





            }

            return RedirectToAction("Create", "EnrollStudent");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            UserLoginLogic.user = null;
            return RedirectToAction("Login");

        }


       


        public ActionResult AdminPanel()
        {

            return View();
           // return RedirectToAction("Create", "EnrollStudent");
        }
    }
}