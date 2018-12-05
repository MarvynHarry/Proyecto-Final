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
    public class visitasController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();


        // GET: visitas
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "paciente")
            {
                return View(db.visita.Where(x => x.paciente.ToString().Contains(search) || search == null).ToList());
            }
            if (searchBy == "fecha")
            {
                return View(db.visita.Where(x => x.fecha.ToString().Contains(search) || search == null).ToList());
            }
            if (searchBy == "proxima")
            {
                return View(db.visita.Where(x => x.proxima.ToString().Contains(search) || search == null).ToList());
            }
            if (searchBy == "motivo")
            {
                return View(db.visita.Where(x => x.motivo.ToString().Contains(search) || search == null).ToList());
            }
            if (searchBy == "comentario")
            {
                return View(db.visita.Where(x => x.comentario.ToString().Contains(search) || search == null).ToList());
            }
            if (searchBy == "receta")
            {
                return View(db.visita.Where(x => x.receta.ToString().Contains(search) || search == null).ToList());
            }

            else { return View(db.visita.ToList()); }
        }

        // GET: visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: visitas/Create
        public ActionResult Create()
        {
            ViewBag.paciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: visitas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,paciente,fecha,proxima,motivo,comentario,receta")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.visitas.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(visita);
        }

        // GET: visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: visitas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,paciente,fecha,proxima,motivo,comentario,receta")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(visita);
        }

        // GET: visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visitas.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visita visita = db.visitas.Find(id);
            db.visitas.Remove(visita);
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
