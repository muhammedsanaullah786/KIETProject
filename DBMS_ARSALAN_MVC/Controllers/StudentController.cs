using DBMS_ARSALAN_MVC.Models;
using DBMS_ARSALAN_MVC.Models.SM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Index(Student st)
        {
            StudentMTHD s1 = new StudentMTHD();
            if (ModelState.IsValid)
            {
                s1.Insert(st);
                ViewBag.mesg = "<script>alert('data Inserted')</script>";
               
            }
            return View();
        }



        [HttpGet]
        public ActionResult ALLStudent()
        {
            return View(new StudentMTHD().GetALLStudentDetaile());
        }

       // [HttpGet]
        //[ActionName("Update")]
        //public ActionResult Update(int sid)
        //{
        //    // Student s1 = new Student();
        //        StudentMTHD stuedit = new StudentMTHD();

        //        return View(new StudentMTHD().StudentByID(sid));

        //}
        [HttpGet]
        [ActionName("Update")]
        public ActionResult Update(int sid)
        {
            // Student s1 = new Student();
          //  StudentMTHD stuedit = new StudentMTHD();

            return View(new StudentMTHD().Single(sid));

        }
        [HttpPost]
        [ActionName("Update")]
        public ActionResult Update(Student ss)
        {
            if (ModelState.IsValid)
            {
                StudentMTHD edit = new StudentMTHD();
                edit.Update(ss);
               // edit.Update(ss);
                //return RedirectToAction("Index");
            }

            return View(ss);
        }
        [HttpGet]
        public ActionResult Delete(Student s1)
        {
            //StudentMTHD stuedit = new StudentMTHD();
            
            return View(new StudentMTHD().Single(s1.sid));
        }

        [HttpPost]
       [ActionName("DeleteP")]
        public ActionResult Delete(int sid)
        {
            //Student s1 = new Student();
           
                //StudentMTHD edit = new StudentMTHD();
               // edit.DeleteStudent(sid);
            
            return View(new StudentMTHD().DeleteStudent(sid));
           
        }
    }
}