using NutriApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriApp.Controllers
{
    public class GroupAdminController : Controller
    {
        public ActionResult Index()
        {
            NutriAppsEntities db = new NutriAppsEntities();
            List<Group> lstGroups = db.Groups.ToList();

            ViewBag.Measures = db.Measures.ToList();
            return View(lstGroups);
        }

        [HttpPost]
        public ActionResult Buscar(int GroupId)
        {
            NutriAppsEntities db = new NutriAppsEntities();
            List<Group> lstGroups = db.Groups.SqlQuery("SELECT Topic,UserID,GroupID,Description,Group_Type FROM dbo.Groups WHERE GroupID = '" + GroupId + "'").ToList();

            ViewBag.Measures = db.Measures.SqlQuery("SELECT UserID,GroupID,Date,Weight,IMC,Fat_Percentage,Muscle_Percentage,Methabolic_Age,Viceral_Fat,Water_Percentage FROM dbo.Measures WHERE GroupID = '" + GroupId + "'").ToList();
            return View("Index", lstGroups);
        }

        public ActionResult Agregar(int GroupId, string Topic, string UserId, string Description, int GroupType)
        {
            NutriAppsEntities db = new NutriAppsEntities();

            string sql = "INSERT INTO dbo.Groups(Topic,UserID,GroupID,Description,Group_Type) VALUES(@Topic,@UserId,@GroupId,@Description,@GroupType)";
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(new SqlParameter("@Topic", Topic));
            parameterList.Add(new SqlParameter("@UserId", UserId));
            parameterList.Add(new SqlParameter("@GroupId", GroupId));
            parameterList.Add(new SqlParameter("@Description", Description));
            parameterList.Add(new SqlParameter("@GroupType", GroupType));
            SqlParameter[] parameters = parameterList.ToArray();
            int result = db.Database.ExecuteSqlCommand(sql, parameters);

            //db.Groups.SqlQuery("INSERT INTO dbo.Groups(Topic,UserID,GroupID,Description,Group_Type) VALUES('" + Topic + "','" + UserId + "','" + GroupId + "','" + Description + "','" + GroupType + "')");
            List<Group> lstGroups = db.Groups.ToList();
   
            ViewBag.Measures = db.Measures.ToList();
            return View("Index", lstGroups);
        }

        public ActionResult Eliminar(int GroupId)
        {
            NutriAppsEntities db = new NutriAppsEntities();

            string sql = "DELETE FROM dbo.Groups WHERE(GroupID = '" + GroupId + "')";
            int result = db.Database.ExecuteSqlCommand(sql);

            List<Group> lstGroups = db.Groups.ToList();

            ViewBag.Measures = db.Measures.ToList();
            return View("Index", lstGroups);
        }

        public ActionResult Chart(string Peso, string IMC, string Grasa, string Musculo, string Edad, string GrasaV, string Agua)
        {
            NutriAppsEntities db = new NutriAppsEntities();
            ViewBag.Measures = db.Measures.ToList();

            if (Peso != null)
            {
                ViewBag.Measures = db.Measures.SqlQuery("SELECT Date, Weight FROM dbo.Measures").ToList();
            }
            if (IMC != null)
            {
                ViewBag.Measures = db.Measures.SqlQuery("SELECT Date, IMC FROM dbo.Measures").ToList();
            }
            if (Grasa != null)
            {
                ViewBag.Measures = db.Measures.SqlQuery("SELECT Date, Fat_Percentage FROM dbo.Measures").ToList();
            }
            if (Musculo != null)
            {
                ViewBag.Measures = db.Measures.SqlQuery("SELECT Date, Muscle_Percentage FROM dbo.Measures").ToList();
            }
            if (Edad != null)
            {
                ViewBag.Measures = db.Measures.SqlQuery("SELECT Date, Methabolic_Age FROM dbo.Measures").ToList();
            }
            if (GrasaV != null)
            {
                ViewBag.Measures = db.Measures.SqlQuery("SELECT Date, Viceral_Fat FROM dbo.Measures").ToList();
            }
            if (Agua != null)
            {
                ViewBag.Measures = db.Measures.SqlQuery("SELECT Date, Water_Percentage FROM dbo.Measures").ToList();
                
            }
            return View("Index");
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