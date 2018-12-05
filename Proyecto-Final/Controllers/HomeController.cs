using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}
