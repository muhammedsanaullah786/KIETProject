using DBMS_ARSALAN_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class DeptController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Index([Bind(Exclude = "DeptID")]Department st)
        {
            try
            {
                Department s1 = new Department();
                if (ModelState.IsValid)
                {
                    s1.Insert(st);
                    ViewBag.mesg = "<script>alert('data Inserted')</script>";
                    return View();
                }
            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Soory Data Is Not Correct! ');</script>");





            }

            return View();
        }



        [HttpGet]
        public ActionResult ALLDept()
        {
            return View(new Department().GetDept());
        }

     
        [HttpGet]
        [ActionName("Update")]
        public ActionResult Update(int sid)
        {
            // Student s1 = new Student();
            //  StudentMTHD stuedit = new StudentMTHD();

            return View(new Department().DepByID(sid));

        }
        [HttpPost]
        [ActionName("Update")]
        public ActionResult Update(Department ss)
        {
            if (ModelState.IsValid)
            {
                Department edit = new Department();
                edit.Update(ss);
               
                //return RedirectToAction("Index");
            }

            return View(ss);
        }
    }
}