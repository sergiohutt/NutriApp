using NutriApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriApp.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source = (local); Initial Catalog = NutriApps; Integrated Security = True");

        private NutriAppsEntities db = new NutriAppsEntities();
        public ActionResult Index()
        {
            //NutriAppsEntities db = new NutriAppsEntities();
            List<Appointment> lstAppointments = db.Appointments.ToList();
            return View(lstAppointments);
        }

        public ActionResult Login(string Username, string Password)
        {
            Session.Add("UserName", Username);
            //string queryString =
            //"SELECT UserID FROM dbo.Users  WHERE UserID = '" + Username + "'";
            //string DBUserID = string.Empty;
            //using (SqlConnection connection = new SqlConnection(
            //           "Data Source = (local); Initial Catalog = NutriApps; Integrated Security = True"))
            //{
            //    SqlCommand command = new SqlCommand("SELECT UserID FROM dbo.Users  WHERE UserID=@Username", 
            //        connection);
            //    command.Parameters.Add(new SqlParameter("@Username", Username));
            //    //queryString, connection);
            //    connection.Open();
            //    SqlDataReader reader = command.ExecuteReader();
            //    try
            //    {
            //        //List<String> table = new List<String>();
            //        while (reader.Read())
            //        {
            //            DBUserID = reader[0].ToString();
            //        }
            //    }
            //    finally
            //    {
            //        reader.Close();
            //    }
            //}
            User user = null;
            try
            {
                user = db.Users.Single(x => x.UserID == Username && x.Password == Password);
            }
            catch
            {
                return View();
            }
            if(user != null)
            {
                if (user.UserType == 1)
                {
                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
                    return RedirectToAction("Index", "ClientHome");
                }
            }
            return View();

            //List<User> lstUsers = db.Users.SqlQuery("SELECT UserID FROM dbo.Users WHERE UserID = " + Username + "").ToList();

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
