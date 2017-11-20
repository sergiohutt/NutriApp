using NutriApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriApp.Controllers
{
    public class MedidasAdminController : Controller
    {
        public ActionResult Index()
        {
            NutriAppsEntities db = new NutriAppsEntities();
            List<Measure> lstMeasures = db.Measures.ToList();
            return View(lstMeasures);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}