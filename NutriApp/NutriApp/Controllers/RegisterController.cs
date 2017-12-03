using NutriApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriApp.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            NutriAppsEntities db = new NutriAppsEntities();
            List<Appointment> lstAppointments = db.Appointments.ToList();
            return View(lstAppointments);
        }

        public ActionResult Register(string Username, string Password, string RePassword, string Name, string Surname, string Email)
        {
            NutriAppsEntities db = new NutriAppsEntities();
            User user = null;
            user = db.Users.Single(x => x.UserID == Username);

            if (user != null)
            {
                return View("<script language='javascript' type='text/javascript'>alert('Username already exist. Please select another username');</script>", "Register");
            }
            else
            {
                string UserRole = "Client";
                int UserType = 2;

                string sql = "INSERT INTO dbo.Users(UserID,UserRole,UserType,Password,Email,Name,Surname) VALUES(@UserID,@UserRole,@UserType,@Password,@Email,@Name,@Surname)";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                parameterList.Add(new SqlParameter("@UserID", Username));
                parameterList.Add(new SqlParameter("@UserRole", UserRole));
                parameterList.Add(new SqlParameter("@UserType", UserType));
                parameterList.Add(new SqlParameter("@Password", Password));
                parameterList.Add(new SqlParameter("@Email", Email));
                parameterList.Add(new SqlParameter("@Name", Name));
                parameterList.Add(new SqlParameter("@Surname", Surname));
                SqlParameter[] parameters = parameterList.ToArray();
                int result = db.Database.ExecuteSqlCommand(sql, parameters);
                return View("Index", "Login");
            }
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
