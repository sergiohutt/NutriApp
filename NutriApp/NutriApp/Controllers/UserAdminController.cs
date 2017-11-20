using NutriApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriApp.Controllers
{
    public class UserAdminController : Controller
    {
        public ActionResult Index()
        {
            NutriAppsEntities db = new NutriAppsEntities();
            List<User> lstUsers = db.Users.ToList();
            
            ViewBag.Measures = db.Measures.ToList();
            return View(lstUsers);
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