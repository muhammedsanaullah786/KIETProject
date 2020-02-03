using DBMS_ARSALAN_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class SubController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Subject());
        }
        [HttpPost]
        public ActionResult Index([Bind(Exclude = "SubjID")]Subject st)
        {
            Subject s1 = new Subject();
            if (ModelState.IsValid)
            {
                s1.Insert(st);
                ViewBag.mesg = "data Inserted";

            }
            return View();
        }



        [HttpGet]
        public ActionResult ALLSubjects()
        {

            return View(new Subject().SubjectsSHow());
        }

        [HttpGet]
        public ActionResult Subjects(string SubjName)
        {

            return View(new SubjSearch().Get(SubjName));
        }


        [HttpGet]
        [ActionName("Update")]
        public ActionResult Update(int sid)
        {
            // Student s1 = new Student();
            //  StudentMTHD stuedit = new StudentMTHD();

            return View(new Subject().DepByID(sid));

        }
        [HttpPost]
        [ActionName("Update")]
        public ActionResult Update(Subject ss)
        {
            if (ModelState.IsValid)
            {
                Subject edit = new Subject();
                edit.Update(ss);

                //return RedirectToAction("Index");
            }

            return View(ss);
        }
    }
}