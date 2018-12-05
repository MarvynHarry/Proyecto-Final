using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyecto_final.Models;

namespace proyecto_final.Controllers
{
    public class VisitasController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Visitas
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "caso")
            {
                return View(db.Visita.Where(x => x.caso.Contains(search) || search == null).ToList());
            }
            if (searchBy == "costo")
            {
                return View(db.Visita.Where(x => x.costo.Equals(search) || search == null).ToList());
            }
            if (searchBy == "paciente")
            {
                return View(db.Visita.Where(x => x.paciente.Equals(search) || search == null).ToList());
            }

            else { return View(db.Visita.ToList()); }
        }

        // GET: Visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: Visitas/Create
        public ActionResult Create()
        {
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: Visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,paciente,caso,Procedimientos,Inicio,Fin,Prioridad,costo")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Visita.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", visita.paciente);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", visita.paciente);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,paciente,caso,Procedimientos,Inicio,Fin,Prioridad,costo")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", visita.paciente);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visita visita = db.Visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visita visita = db.Visita.Find(id);
            db.Visita.Remove(visita);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
