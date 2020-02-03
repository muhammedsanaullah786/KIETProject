using DBMS_ARSALAN_MVC.Areas.StudentArea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Areas.StudentArea.Controllers
{
    public class StModController : Controller
    {
        public static String id { get; set; }
        [HttpGet]
        public ActionResult StudentLMS()
        {
            return View(new StudentModule().SubjectsSHow(id));
        }
    }
}