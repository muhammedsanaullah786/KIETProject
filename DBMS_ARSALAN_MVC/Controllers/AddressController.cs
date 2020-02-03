using DBMS_ARSALAN_MVC.Models.AddressModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBMS_ARSALAN_MVC.Controllers
{
    public class AddressController : Controller
    {
        public ActionResult Index()
        {
            CityMthd cbl = new CityMthd();

            return View(cbl.cities);
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            CityMthd cbl = new CityMthd();
            return Json(cbl.CityByID(id).towns, JsonRequestBehavior.AllowGet);
        }
    }
}