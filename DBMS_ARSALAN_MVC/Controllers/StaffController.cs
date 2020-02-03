using DBMS_ARSALAN_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        
            
       
        [HttpGet]
            public ActionResult Index()
            {
                return View(new Staff());
            }
            [HttpPost]
            public ActionResult Index(Staff st)
            {
                Staff s1 = new Staff();
                if (ModelState.IsValid)
                {
                


                    s1.Insert(st);
                    ViewBag.mesg = "<script>alert('data Inserted')</script>";
                
                }
                return View();
            }



            [HttpGet]
            public ActionResult ALLStaff()
            {
                return View(new Staff().GetStaff());
            }

          
            [HttpGet]
            [ActionName("Update")]
            public ActionResult Update(int sid)
            {
               

                return View(new Staff().StID(sid));

            }
            [HttpPost]
            [ActionName("Update")]
            public ActionResult Update(Staff ss)
        {
            Staff edit = new Staff();
            if (ModelState.IsValid)
                {
               
                
                


                    edit.Update(ss);
                
                }

                return View(ss);
            }

        [HttpGet]
        public ActionResult Detaile(int id)
        {
            //StudentMTHD stuedit = new StudentMTHD();

            return View(new Staff().StID(id));
        }
        [HttpGet]
            public ActionResult Delete(Student s1)
            {
                //StudentMTHD stuedit = new StudentMTHD();

                return View(new Staff().StID(s1.sid));
            }

            [HttpPost]
            [ActionName("DeleteP")]
            public ActionResult Delete(int sid)
            {
             

                return View(new Staff().DeleteStaff(sid));

            }
        
    }
}