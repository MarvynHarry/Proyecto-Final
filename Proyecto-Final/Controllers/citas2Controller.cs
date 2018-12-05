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
    public class citas2Controller : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: citas2
        public ActionResult Index(string searchBy, string search)
        {
            var cita = db.cita.Include(c => c.paciente);

            if (searchBy == "fecha")
            {
                return View(db.cita.Where(x => x.fecha.ToString().Contains(search) || search == null).ToList());
            }
            if (searchBy == "costo")
            {
                return View(db.cita.Where(x => x.costo.ToString().Contains(search) || search == null).ToList());
            }
            if (searchBy == "cedula")
            {
                return View(db.cita.Where(x => x.cedula.ToString().Contains(search) || search == null).ToList());
            }

            else { return View(db.cita.ToList()); }

        }

        // GET: citas2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: citas2/Create
        public ActionResult Create()
        {
            ViewBag.cedula = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: citas2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cita,cedula,consulta,fecha,hora,duracion,costo")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cedula = new SelectList(db.paciente, "cedula", "nombre", cita.cedula);
            return View(cita);
        }

        // GET: citas2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.cedula = new SelectList(db.paciente, "cedula", "nombre", cita.cedula);
            return View(cita);
        }

        // POST: citas2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cita,cedula,consulta,fecha,hora,duracion,costo")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cedula = new SelectList(db.paciente, "cedula", "nombre", cita.cedula);
            return View(cita);
        }

        // GET: citas2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: citas2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cita cita = db.cita.Find(id);
            db.cita.Remove(cita);
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
