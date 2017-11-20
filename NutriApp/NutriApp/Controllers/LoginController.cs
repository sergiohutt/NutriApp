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

        public ActionResult Index()
        {
            NutriAppsEntities db = new NutriAppsEntities();
            List<Appointment> lstAppointments = db.Appointments.ToList();
            return View(lstAppointments);
        }

        public ActionResult Login(string Username, string Password)
        {
            string queryString =
            "SELECT UserID FROM dbo.Users WHERE UserID = " + Username + "";
            using (SqlConnection connection = new SqlConnection(
                       "Data Source = (local); Initial Catalog = NutriApps; Integrated Security = True"))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    List<String> table = new List<String>();
                    while (reader.Read())
                    {
                        string asd = reader[0].ToString();
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return View("Index");

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