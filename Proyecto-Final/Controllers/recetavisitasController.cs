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
    public class recetavisitasController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: recetavisitas
        public ActionResult Index(string searchBy, string search)
        {
            var recetavisita = db.recetavisita.Include(r => r.paciente1);
            if (searchBy == "fecha")
            {
                return View(db.recetavisita.Where(x => x.fecha.Equals(search) || search == null).ToList());
            }
            if (searchBy == "medicamentos")
            {
                return View(db.recetavisita.Where(x => x.medicamentos.Contains(search) || search == null).ToList());
            }
            if (searchBy == "paciente")
            {
                return View(db.recetavisita.Where(x => x.paciente.Equals(search) || search == null).ToList());
            }
            if (searchBy == "observaciones")
            {
                return View(db.recetavisita.Where(x => x.observaciones.Contains(search) || search == null).ToList());
            }

            else { return View(db.recetavisita.ToList()); }
        }

        // GET: recetavisitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetavisita recetavisita = db.recetavisita.Find(id);
            if (recetavisita == null)
            {
                return HttpNotFound();
            }
            return View(recetavisita);
        }

        // GET: recetavisitas/Create
        public ActionResult Create()
        {
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: recetavisitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,paciente,fecha,cita,medicamentos,observaciones")] recetavisita recetavisita)
        {
            if (ModelState.IsValid)
            {
                db.recetavisita.Add(recetavisita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", recetavisita.paciente);
            return View(recetavisita);
        }

        // GET: recetavisitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetavisita recetavisita = db.recetavisita.Find(id);
            if (recetavisita == null)
            {
                return HttpNotFound();
            }
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", recetavisita.paciente);
            return View(recetavisita);
        }

        // POST: recetavisitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,paciente,fecha,cita,medicamentos,observaciones")] recetavisita recetavisita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recetavisita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre", recetavisita.paciente);
            return View(recetavisita);
        }

        // GET: recetavisitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recetavisita recetavisita = db.recetavisita.Find(id);
            if (recetavisita == null)
            {
                return HttpNotFound();
            }
            return View(recetavisita);
        }

        // POST: recetavisitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recetavisita recetavisita = db.recetavisita.Find(id);
            db.recetavisita.Remove(recetavisita);
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
