using DBMS_ARSALAN_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class FeeController : Controller
    {
        // GET: Fee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetFee()
        {

            return View(new Fee().GetFee());
        }
    }
}