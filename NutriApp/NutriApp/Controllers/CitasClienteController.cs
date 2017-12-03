using NutriApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NutriApp.Controllers
{
    public class CitasClienteController : Controller
    {
        public ActionResult Index()
        {
            NutriAppsEntities db = new NutriAppsEntities();
            List<Appointment> lstAppointments = db.Appointments.ToList();
            return View(lstAppointments);
        }
        
        public ActionResult Agregar(DateTime Date, DateTime Time, int IDApp)
        {
            NutriAppsEntities db = new NutriAppsEntities();
            Appointment appoint = null;
            string DateTime = Date.ToString("yyyy-MM-dd") + " " + Time.ToString("HH:mm:ss");
            DateTime DateTime2 = Convert.ToDateTime(DateTime);
            appoint = db.Appointments.Single(x => x.Date == DateTime2);

            if (appoint != null)
            {
                return View("<script language='javascript' type='text/javascript'>alert('There is already appointment for the selected date and time');</script>", "Register");
            }else
            {
                string sql = "INSERT INTO dbo.Appointments(UserID,Date,IDApp) VALUES(@UserId,@Date,@IDApp)";
                List<SqlParameter> parameterList = new List<SqlParameter>();
                parameterList.Add(new SqlParameter("@UserId", UserId));
                parameterList.Add(new SqlParameter("@Date", DateTime2));
                parameterList.Add(new SqlParameter("@IDApp", IDApp));
                SqlParameter[] parameters = parameterList.ToArray();
                int result = db.Database.ExecuteSqlCommand(sql, parameters);

                //db.Groups.SqlQuery("INSERT INTO dbo.Groups(Topic,UserID,GroupID,Description,Group_Type) VALUES('" + Topic + "','" + UserId + "','" + GroupId + "','" + Description + "','" + GroupType + "')");
                List<Appointment> lstAppointments = db.Appointments.SqlQuery("SELECT UserID,Date,IDApp FROM dbo.Appointments WHERE UserID = '" + UserId + "'").ToList();

                return View("Index", lstAppointments);
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
