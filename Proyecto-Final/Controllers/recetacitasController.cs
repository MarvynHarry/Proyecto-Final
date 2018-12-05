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
    public class recetacitasController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: recetacitas
        public ActionResult Index()
        {
            var recetacita = db.recetacita.Include(r => r.paciente1);
            return View(recetacita.ToList());
        }

        // GET: recetacitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetacita recetacita = db.recetacita.Find(id);
            if (recetacita == null)
            {
                return HttpNotFound();
            }
            return View(recetacita);
        }

        // GET: recetacitas/Create
        public ActionResult Create()
        {
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: recetacitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,paciente,fecha,cita,medicamentos,observaciones")] recetacita recetacita)
        {
            if (ModelState.IsValid)
            {
                db.recetacita.Add(recetacita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", recetacita.paciente);
            return View(recetacita);
        }

        // GET: recetacitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetacita recetacita = db.recetacita.Find(id);
            if (recetacita == null)
            {
                return HttpNotFound();
            }
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", recetacita.paciente);
            return View(recetacita);
        }

        // POST: recetacitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,paciente,fecha,cita,medicamentos,observaciones")] recetacita recetacita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recetacita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", recetacita.paciente);
            return View(recetacita);
        }

        // GET: recetacitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetacita recetacita = db.recetacita.Find(id);
            if (recetacita == null)
            {
                return HttpNotFound();
            }
            return View(recetacita);
        }

        // POST: recetacitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recetacita recetacita = db.recetacita.Find(id);
            db.recetacita.Remove(recetacita);
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