using DBMS_ARSALAN_MVC.Models.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class EnrollStudentController : Controller
    {
       
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Enroll());
        }
        [HttpPost]
        
        public ActionResult Create(Enroll en)
        {
          
                Enroll e1 = new Enroll();
                if (ModelState.IsValid)
                {
                    e1.Insert(en);
                    ViewBag.mesg = "Enroll Student";
                    return View();

                }

          
            
             return RedirectToAction("ListEnroll", "EnrollStudent");



        }



        [HttpGet]
        public ActionResult ListEnroll()
        {
            return View(new Enroll().EnrollSt());
        }




        [HttpGet]
        [ActionName("Update")]
        public ActionResult Update(int subid)
        {
            // Student s1 = new Student();
            //  StudentMTHD stuedit = new StudentMTHD();

            return View(new Enroll().Single(subid));

        }
        [HttpPost]
        [ActionName("Update")]
        public ActionResult Update(Enroll en)
        {
            Enroll pn = new Enroll();
            UpdateModel(pn);
            if (ModelState.IsValid)
            {
                Enroll edit = new Enroll();
              //  UpdateModel(en);
                edit.Update(en);
                // edit.Update(ss);
                //return RedirectToAction("Index");
            }

             return View(en);
            //return RedirectToAction("ListEnroll", "EnrollStudent");

        }
        [HttpGet]
        public ActionResult DropCourse(Enroll s1)
        {
            
            return View(new Enroll().Single(s1.Subjid));
        }

        [HttpPost]
       
        public ActionResult DropCourse(int Subjid)
        {
            Enroll en = new Enroll();
            en.DropCourse(Subjid);

            return RedirectToAction("ListEnroll", "EnrollStudent");

        }
    }
}