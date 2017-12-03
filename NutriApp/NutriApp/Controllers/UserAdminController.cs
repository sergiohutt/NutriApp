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
        
        public ActionResult Agregar(string UserId, string Email, string Name, string SurName)
        {
            NutriAppsEntities db = new NutriAppsEntities();

            string sql = "INSERT INTO dbo.Users(UserID,UserRole,UserType,Password,Email,Name,Surname) VALUES(@UserId,'Client','2','Temp!01',@Email,@Name,@SurName)";
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(new SqlParameter("@UserId", UserId));
            parameterList.Add(new SqlParameter("@Email", Email));
            parameterList.Add(new SqlParameter("@Name", Name));
            parameterList.Add(new SqlParameter("@SurName", SurName));
            SqlParameter[] parameters = parameterList.ToArray();
            int result = db.Database.ExecuteSqlCommand(sql, parameters);

            //db.Groups.SqlQuery("INSERT INTO dbo.Groups(Topic,UserID,GroupID,Description,Group_Type) VALUES('" + Topic + "','" + UserId + "','" + GroupId + "','" + Description + "','" + GroupType + "')");
            List<User> lstUsers = db.Users.ToList();

            ViewBag.Measures = db.Measures.ToList();
            return View("Index", lstUsers);
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
