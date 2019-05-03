using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using proyecto_final.Models;

namespace proyecto_final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios objUser)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseEntities db = new DatabaseEntities())
                {

                    var obj = db.Usuarios.Where(a => a.Nombre.Equals(objUser.Nombre) && a.clave.Equals(objUser.clave)).FirstOrDefault();
                    if (obj != null)
                    {


                        if (obj.tipo == "admin")
                        {
                            Session["id"] = obj.id.ToString();
                            Session["tipo"] = obj.tipo.ToString();
                            Session["Nombre"] = obj.Nombre.ToString();
                            return RedirectToAction("Index");
                        }
                        if (obj.tipo == "asistente")
                        {
                            Session["id"] = obj.id.ToString();
                            Session["tipo"] = obj.tipo.ToString();
                            Session["Nombre"] = obj.Nombre.ToString();
                            return RedirectToAction("AsistenteDashBoard");
                        }
                        if (obj.tipo == "medico")
                        {
                            Session["id"] = obj.id.ToString();
                            Session["tipo"] = obj.tipo.ToString();
                            Session["Nombre"] = obj.Nombre.ToString();
                            return RedirectToAction("MedicoDashBoard");
                        }
                    }
                    else
                    {
                        return View("Login");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult AdminDashBoard()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult AsistenteDashBoard()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult MedicoDashBoard()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return View("Login");
        }



        public ActionResult exportReport()
        {
            DatabaseEntities db = new DatabaseEntities();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CrystalReport1.rpt"));
            rd.SetDataSource(db.Usuarios.ToList());
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Usuarios.pdf");
            }
            catch
            {
                throw;
            }
        }
    }
}
