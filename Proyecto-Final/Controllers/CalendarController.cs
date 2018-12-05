using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using proyecto_final.Models;
using System.Data;

using EntityState = System.Data.Entity.EntityState;
using DHTMLX.Scheduler.Controls;


namespace proyecto_final.Controllers
{
    public class CalendarController : Controller
    {
        private DatabaseEntities dc = new DatabaseEntities();

     

        public ActionResult Index(Visita visita)
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 20;
            scheduler.Data.Loader.PreventCache();
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            ViewBag.paciente = new SelectList(dc.paciente, "cedula", "nombre", visita.paciente);
            scheduler.Lightbox.Add(new LightboxText("Caso", "Caso"));

            var box = scheduler.Lightbox.SetExternalLightboxForm("../Visita/Form", 340, 700);
            box.ClassName = "custom_lightbox";
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

            public ContentResult Data()
        {
            var apps = dc.Visita.ToList();
            return new SchedulerAjaxData(apps);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dc.Dispose();
            }
            base.Dispose(disposing);
        }

        public ContentResult Data(DateTime from, DateTime to)
        {
            var apps = dc.Visita.Where(e => e.Inicio < to && e.Fin >= from).ToList();
            return new SchedulerAjaxData(apps);
        }







        public ActionResult Create()
        {
            
            return View("../Visitas/Create");
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,paciente,caso,Procedimientos,Inicio,Fin,Prioridad,costo,StatusENUM")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                dc.Visita.Add(visita);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paciente = new SelectList(dc.paciente, "cedula", "nombre", visita.paciente);
            return View(visita);
        }

    }
}

 